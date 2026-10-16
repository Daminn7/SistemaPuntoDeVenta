using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDatos.DTOs;

namespace CapaPresentacion
{
    public partial class FormMovimientosCaja : Form
    {
        // ============================================================
        // LÓGICA DE LA API
        // ============================================================
        private readonly CajaLogica _cajaLogica = new CajaLogica();
        private readonly MovimientoCajaLogica _movimientoLogica = new MovimientoCajaLogica();

        // ============================================================
        // ESTADO
        // ============================================================
        private int _cajaActivaId = 0;
        private decimal _fondoInicial = 0m;
        private decimal _totalIngresos = 0m;
        private decimal _totalEgresos = 0m;
        private List<MovimientoCajaDto> _movimientosOriginales = new List<MovimientoCajaDto>();

        // ✅ Cancelación de cargas al cerrar el form
        private CancellationTokenSource _ctsCarga;

        public FormMovimientosCaja()
        {
            InitializeComponent();
        }

        // ============================================================
        // LOAD
        // ============================================================
        private async void FormMovimientosCaja_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();

            if (pbIconoTitulo != null)
                pbIconoTitulo.Image = GenerarIconoCaja(Color.FromArgb(212, 131, 53));

            InicializarTablaBalance();
            await CargarMovimientosAsync(_ctsCarga.Token);
        }

        // ============================================================
        // CANCELAR AL CERRAR
        // ============================================================
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                _ctsCarga?.Cancel();
                _ctsCarga?.Dispose();
                _ctsCarga = null;
            }
            catch { }

            base.OnFormClosing(e);
        }

        // ============================================================
        // ✅ Carga los movimientos de la caja activa
        // ============================================================
        private async Task CargarMovimientosAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                // 1. Obtener la caja activa
                var cajaActiva = await _cajaLogica.ObtenerActiva();

                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                if (cajaActiva == null)
                {
                    dgvMovimientos.Rows.Clear();
                    _cajaActivaId = 0;
                    _movimientosOriginales = new List<MovimientoCajaDto>();
                    ActualizarBalance(0m, 0m, 0m);
                    return;
                }

                _cajaActivaId = cajaActiva.Id;
                _fondoInicial = cajaActiva.FondoInicial;

                // 2. Obtener los movimientos de esa caja
                var movimientosRaw = await _movimientoLogica.ObtenerPorCajaId(_cajaActivaId);

                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                // 3. Castear a lista tipada
                var movimientos = ConvertirAMovimientoDto(movimientosRaw);
                _movimientosOriginales = movimientos;

                // 4. Cargar la grilla
                MostrarMovimientos(movimientos);

                // 5. Calcular balance
                CalcularBalanceDesdeMovimientos(movimientos);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar movimientos: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // ✅ Convertir dynamic → List<MovimientoCajaDto>
        // ============================================================
        private List<MovimientoCajaDto> ConvertirAMovimientoDto(dynamic movimientosRaw)
        {
            var resultado = new List<MovimientoCajaDto>();

            if (movimientosRaw == null) return resultado;

            try
            {
                if (movimientosRaw is List<MovimientoCajaDto> listaDirecta)
                    return listaDirecta;

                if (movimientosRaw is Newtonsoft.Json.Linq.JArray jArray)
                {
                    foreach (var item in jArray)
                    {
                        var mov = item.ToObject<MovimientoCajaDto>();
                        if (mov != null) resultado.Add(mov);
                    }
                    return resultado;
                }

                if (movimientosRaw is System.Collections.IEnumerable enumerable)
                {
                    foreach (var item in enumerable)
                    {
                        try
                        {
                            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                            var mov = Newtonsoft.Json.JsonConvert.DeserializeObject<MovimientoCajaDto>(json);
                            if (mov != null) resultado.Add(mov);
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al convertir movimientos: {ex.Message}");
            }

            return resultado;
        }

        // ============================================================
        // ✅ Mostrar movimientos en la grilla
        // ============================================================
        private void MostrarMovimientos(List<MovimientoCajaDto> movimientos)
        {
            dgvMovimientos.SuspendLayout();
            dgvMovimientos.Rows.Clear();

            foreach (var mov in movimientos)
            {
                bool esIngreso = mov.Monto > 0;

                string tipo = mov.TipoMovimientoDescripcion ?? "";
                bool esEgresoPorTipo = tipo.Equals("Egreso", StringComparison.OrdinalIgnoreCase) ||
                                       tipo.Equals("Retiro", StringComparison.OrdinalIgnoreCase) ||
                                       tipo.Equals("Cierre", StringComparison.OrdinalIgnoreCase);

                string ingresoStr = (!esEgresoPorTipo && esIngreso) ? mov.Monto.ToString("C2") : "";
                string egresoStr = (esEgresoPorTipo || !esIngreso) ? Math.Abs(mov.Monto).ToString("C2") : "";

                dgvMovimientos.Rows.Add(
                    mov.Id,                                                        // ✅ Id (no IdMovimiento)
                    mov.FechaMovimiento.ToString("dd/MM/yyyy HH:mm"),
                    tipo,
                    mov.Descripcion ?? "",
                    "—",                                                            // Medio Pago (no viene en el DTO)
                    ingresoStr,
                    egresoStr,
                    mov.PersonalNombre ?? ""
                );
            }

            dgvMovimientos.ResumeLayout();
            dgvMovimientos.ClearSelection();
            if (dgvMovimientos.CurrentCell != null)
                dgvMovimientos.CurrentCell = null;
        }

        // ============================================================
        // ✅ Calcular balance
        // ============================================================
        private void CalcularBalanceDesdeMovimientos(List<MovimientoCajaDto> movimientos)
        {
            decimal ingresos = 0m;
            decimal egresos = 0m;

            foreach (var mov in movimientos)
            {
                string tipo = (mov.TipoMovimientoDescripcion ?? "").ToUpper();

                if (tipo.Contains("APERTURA"))
                {
                    continue;   // Ya está contado como fondo inicial
                }
                else if (tipo.Contains("EGRESO") || tipo.Contains("RETIRO") || tipo.Contains("CIERRE"))
                {
                    egresos += Math.Abs(mov.Monto);
                }
                else
                {
                    ingresos += Math.Abs(mov.Monto);
                }
            }

            _totalIngresos = ingresos;
            _totalEgresos = egresos;

            ActualizarBalance(_fondoInicial, ingresos, egresos);
        }

        // ============================================================
        // ✅ Actualizar el panel de balance
        // ============================================================
        private void ActualizarBalance(decimal fondoInicial, decimal ingresos, decimal egresos)
        {
            dgvBalance.SuspendLayout();
            dgvBalance.Rows.Clear();

            int idxInicial = dgvBalance.Rows.Add("Fondo Inicial", fondoInicial.ToString("C2"));
            int idxIngreso = dgvBalance.Rows.Add("Ingresos (+)", ingresos.ToString("C2"));
            int idxEgreso = dgvBalance.Rows.Add("Egresos / Retiros (-)", egresos.ToString("C2"));

            dgvBalance.Rows[idxIngreso].Cells[1].Style.ForeColor = Color.FromArgb(39, 174, 96);
            dgvBalance.Rows[idxEgreso].Cells[1].Style.ForeColor = Color.FromArgb(192, 57, 43);

            decimal totalGaveta = fondoInicial + ingresos - egresos;
            int idxTotal = dgvBalance.Rows.Add("TOTAL EN GAVETA", totalGaveta.ToString("C2"));

            dgvBalance.Rows[idxTotal].DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBalance.Rows[idxTotal].DefaultCellStyle.BackColor = Color.FromArgb(245, 240, 235);
            dgvBalance.Rows[idxTotal].Cells[1].Style.ForeColor = totalGaveta >= 0
                ? Color.FromArgb(39, 174, 96)
                : Color.FromArgb(192, 57, 43);

            dgvBalance.ResumeLayout();
            dgvBalance.ClearSelection();
            if (dgvBalance.CurrentCell != null)
                dgvBalance.CurrentCell = null;
        }

        // ============================================================
        // Inicializar el balance en cero
        // ============================================================
        private void InicializarTablaBalance()
        {
            dgvBalance.Rows.Clear();
            int idxInicial = dgvBalance.Rows.Add("Fondo Inicial", "$ 0,00");
            int idxIngreso = dgvBalance.Rows.Add("Ingresos (+)", "$ 0,00");
            int idxEgreso = dgvBalance.Rows.Add("Egresos / Retiros (-)", "$ 0,00");

            dgvBalance.Rows[idxIngreso].Cells[1].Style.ForeColor = Color.FromArgb(39, 174, 96);
            dgvBalance.Rows[idxEgreso].Cells[1].Style.ForeColor = Color.FromArgb(192, 57, 43);

            int idxTotal = dgvBalance.Rows.Add("TOTAL EN GAVETA", "$ 0,00");
            dgvBalance.Rows[idxTotal].DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBalance.Rows[idxTotal].DefaultCellStyle.BackColor = Color.FromArgb(245, 240, 235);

            dgvBalance.ClearSelection();
        }

        // ============================================================
        // Ícono vectorial del título
        // ============================================================
        private Image GenerarIconoCaja(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 3.5f, 6.5f, 25f, 18f);
                    g.DrawLine(pen, 3.5f, 19.5f, 28.5f, 19.5f);
                    g.FillEllipse(brush, 13.5f, 10.5f, 5f, 5f);
                    g.FillRectangle(brush, 5.5f, 24.5f, 4f, 2f);
                    g.FillRectangle(brush, 22.5f, 24.5f, 4f, 2f);
                }
            }
            return bmp;
        }
    }
}