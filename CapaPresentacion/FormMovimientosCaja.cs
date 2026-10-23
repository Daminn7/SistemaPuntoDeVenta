using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDatos.DTOs;
using CapaDatos.Helpers;

namespace CapaPresentacion
{
    public partial class FormMovimientosCaja : Form
    {
        private readonly CajaLogica _cajaLogica = new CajaLogica();
        private readonly MovimientoCajaLogica _movimientoLogica = new MovimientoCajaLogica();

        private List<MovimientoCajaDto> _todosLosMovimientos = new List<MovimientoCajaDto>();
        private List<MovimientoCajaDto> _movimientosFiltrados = new List<MovimientoCajaDto>();
        private List<CajaDto> _todasLasCajas = new List<CajaDto>();
        private Dictionary<int, CajaDto> _cajasCache = new Dictionary<int, CajaDto>();

        private decimal _fondoInicialFiltrado = 0m;
        private decimal _totalIngresosFiltrado = 0m;
        private decimal _totalEgresosFiltrado = 0m;

        private CancellationTokenSource _ctsCarga;

        public FormMovimientosCaja()
        {
            InitializeComponent();
        }

        private async void FormMovimientosCaja_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();

            if (pbIconoTitulo != null)
                pbIconoTitulo.Image = GenerarIconoCaja(Color.FromArgb(212, 131, 53));

            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            if (cboTipoMovimiento.Items.Count > 0) cboTipoMovimiento.SelectedIndex = 0;
            if (cboMedioPago.Items.Count > 0) cboMedioPago.SelectedIndex = 0;

            btnBuscar.Click += async (s, ev) => await AplicarFiltrosYRecargarAsync();
            btnLimpiar.Click += async (s, ev) => await LimpiarFiltrosAsync();
            btnArqueo.Click += btnArqueo_Click;
            btnImprimirInforme.Click += btnImprimirInforme_Click;

            ActualizarBalance(0m, 0m, 0m);

            await CargarTodosLosMovimientosAsync(_ctsCarga.Token);
        }

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

        private async Task CargarTodosLosMovimientosAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                var cajas = await _cajaLogica.ObtenerTodos();

                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                if (cajas == null || cajas.Count == 0)
                {
                    _todasLasCajas = new List<CajaDto>();
                    _cajasCache = new Dictionary<int, CajaDto>();
                    _todosLosMovimientos = new List<MovimientoCajaDto>();
                    _movimientosFiltrados = new List<MovimientoCajaDto>();
                    MostrarMovimientos(_movimientosFiltrados);
                    ActualizarBalance(0m, 0m, 0m);
                    return;
                }

                _todasLasCajas = cajas;
                _cajasCache = cajas.ToDictionary(c => c.Id, c => c);

                // ✅ Filtramos por fecha de apertura comparando con hora local
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1);

                var cajasDelRango = cajas
                    .Where(c =>
                    {
                        DateTime aperturaLocal = FechaHelper.ToArgentina(c.FechaApertura);
                        return aperturaLocal >= desde && aperturaLocal < hasta;
                    })
                    .ToList();

                var todosMovimientos = new List<MovimientoCajaDto>();

                foreach (var caja in cajasDelRango)
                {
                    if (token.IsCancellationRequested) return;

                    try
                    {
                        var movimientosRaw = await _movimientoLogica.ObtenerPorCajaId(caja.Id);
                        var movimientos = ConvertirAMovimientoDto(movimientosRaw);
                        todosMovimientos.AddRange(movimientos);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error al cargar movimientos de caja {caja.Id}: {ex.Message}");
                    }
                }

                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                _todosLosMovimientos = todosMovimientos
                    .OrderByDescending(m => m.FechaMovimiento)
                    .ToList();

                AplicarFiltrosUI();

                MostrarMovimientos(_movimientosFiltrados);
                RecalcularBalance(_movimientosFiltrados);
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

        private void AplicarFiltrosUI()
        {
            var lista = _todosLosMovimientos.AsEnumerable();

            string tipoFiltro = cboTipoMovimiento.Text;
            if (!string.IsNullOrEmpty(tipoFiltro) && tipoFiltro != "Todos")
            {
                lista = lista.Where(m =>
                    !string.IsNullOrEmpty(m.TipoMovimientoDescripcion) &&
                    m.TipoMovimientoDescripcion.Equals(tipoFiltro, StringComparison.OrdinalIgnoreCase));
            }

            string medioFiltro = cboMedioPago.Text;
            if (!string.IsNullOrEmpty(medioFiltro) && medioFiltro != "Todos")
            {
                lista = lista.Where(m =>
                {
                    try
                    {
                        var prop = m.GetType().GetProperty("MedioPagoDescripcion");
                        if (prop == null) return true;
                        var valor = prop.GetValue(m) as string;
                        return !string.IsNullOrEmpty(valor) &&
                               valor.Equals(medioFiltro, StringComparison.OrdinalIgnoreCase);
                    }
                    catch { return true; }
                });
            }

            _movimientosFiltrados = lista.ToList();
        }

        private async Task AplicarFiltrosYRecargarAsync()
        {
            await CargarTodosLosMovimientosAsync(_ctsCarga?.Token ?? CancellationToken.None);
        }

        private async Task LimpiarFiltrosAsync()
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            if (cboTipoMovimiento.Items.Count > 0) cboTipoMovimiento.SelectedIndex = 0;
            if (cboMedioPago.Items.Count > 0) cboMedioPago.SelectedIndex = 0;

            await CargarTodosLosMovimientosAsync(_ctsCarga?.Token ?? CancellationToken.None);
        }

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

                string cajaStr = mov.NumeroCaja.HasValue
                    ? $"Caja {mov.NumeroCaja.Value}"
                    : $"Caja (id {mov.CajaId})";

                string medioPagoStr = string.IsNullOrWhiteSpace(mov.MedioPagoDescripcion)
                    ? "—"
                    : mov.MedioPagoDescripcion;

                // ✅ Fecha convertida a hora local
                string fechaStr = FechaHelper.ToArgentinaString(mov.FechaMovimiento, "dd/MM/yyyy HH:mm");

                dgvMovimientos.Rows.Add(
                    mov.Id,
                    fechaStr,
                    cajaStr,
                    tipo,
                    mov.Descripcion ?? "",
                    medioPagoStr,
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

        private void RecalcularBalance(List<MovimientoCajaDto> movimientos)
        {
            decimal fondoTotal = 0m;
            decimal ingresos = 0m;
            decimal egresos = 0m;

            var cajasInvolucradas = movimientos.Select(m => m.CajaId).Distinct().ToList();
            foreach (var cajaId in cajasInvolucradas)
            {
                if (_cajasCache.TryGetValue(cajaId, out var caja))
                {
                    fondoTotal += caja.FondoInicial;
                }
            }

            foreach (var mov in movimientos)
            {
                string tipo = (mov.TipoMovimientoDescripcion ?? "").ToUpper();

                if (tipo.Contains("APERTURA"))
                    continue;
                else if (tipo.Contains("EGRESO") || tipo.Contains("RETIRO") || tipo.Contains("CIERRE"))
                    egresos += Math.Abs(mov.Monto);
                else
                    ingresos += Math.Abs(mov.Monto);
            }

            _fondoInicialFiltrado = fondoTotal;
            _totalIngresosFiltrado = ingresos;
            _totalEgresosFiltrado = egresos;

            ActualizarBalance(fondoTotal, ingresos, egresos);
        }

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

        private void btnArqueo_Click(object sender, EventArgs e)
        {
            decimal totalEsperado = _fondoInicialFiltrado + _totalIngresosFiltrado - _totalEgresosFiltrado;

            string rango = dtpDesde.Value.Date == dtpHasta.Value.Date
                ? dtpDesde.Value.ToString("dd/MM/yyyy")
                : $"{dtpDesde.Value:dd/MM/yyyy} al {dtpHasta.Value:dd/MM/yyyy}";

            string tipoFiltro = cboTipoMovimiento.Text == "Todos" ? "Todos" : cboTipoMovimiento.Text;

            string resumen =
                $"═══════════════════════════════════════\n" +
                $"   ARQUEO PARCIAL DE CAJA\n" +
                $"═══════════════════════════════════════\n\n" +
                $"📅 Período: {rango}\n" +
                $"🔍 Filtro Tipo: {tipoFiltro}\n" +
                $"📊 Movimientos analizados: {_movimientosFiltrados.Count}\n\n" +
                $"───────────────────────────────────────\n" +
                $"  DETALLE DEL ARQUEO\n" +
                $"───────────────────────────────────────\n" +
                $"Fondos iniciales:      {_fondoInicialFiltrado,15:C2}\n" +
                $"Ingresos (+):          {_totalIngresosFiltrado,15:C2}\n" +
                $"Egresos / Retiros (-): {_totalEgresosFiltrado,15:C2}\n" +
                $"───────────────────────────────────────\n" +
                $"TOTAL ESPERADO:        {totalEsperado,15:C2}\n\n" +
                $"═══════════════════════════════════════\n\n" +
                $"Este es un arqueo informativo del período filtrado.\n" +
                $"NO modifica el estado de las cajas.\n\n" +
                $"Operador: {SesionUsuario.Nombre ?? "—"}\n" +
                $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

            MessageBox.Show(resumen, "Arqueo de Caja",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimirInforme_Click(object sender, EventArgs e)
        {
            if (_movimientosFiltrados.Count == 0)
            {
                MessageBox.Show("No hay movimientos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = $"MovimientosCaja_{DateTime.Now:yyyyMMdd_HHmm}";
                pd.DefaultPageSettings.Landscape = true;
                pd.PrintPage += ImprimirMovimientos_PrintPage;

                PrintPreviewDialog prev = new PrintPreviewDialog
                {
                    Document = pd,
                    Width = 1100,
                    Height = 700,
                    StartPosition = FormStartPosition.CenterScreen
                };
                prev.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirMovimientos_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float x = 40;
            float y = 40;
            float ancho = e.PageBounds.Width - 80;

            using (Font fTitulo = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 9.5f))
            using (Font fHeader = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Font fRow = new Font("Segoe UI", 8.5f))
            using (Font fTotal = new Font("Segoe UI", 11, FontStyle.Bold))
            using (Brush bOcre = new SolidBrush(Color.FromArgb(212, 131, 53)))
            using (Brush bGrafito = new SolidBrush(Color.FromArgb(38, 40, 44)))
            using (Brush bGris = new SolidBrush(Color.Gray))
            using (Brush bVerde = new SolidBrush(Color.FromArgb(39, 174, 96)))
            using (Brush bRojo = new SolidBrush(Color.FromArgb(192, 57, 43)))
            using (Pen penLinea = new Pen(Color.FromArgb(180, 185, 190), 1))
            using (Pen penLineaFina = new Pen(Color.FromArgb(210, 215, 220), 1))
            {
                g.DrawString("HIERRO Y FORJA", fTitulo, bOcre, x, y);
                g.DrawString("MOVIMIENTOS DE CAJA - REPORTE GERENCIAL", fSub, bGrafito, x, y + 28);

                string rango = dtpDesde.Value.Date == dtpHasta.Value.Date
                    ? dtpDesde.Value.ToString("dd/MM/yyyy")
                    : $"{dtpDesde.Value:dd/MM/yyyy} al {dtpHasta.Value:dd/MM/yyyy}";

                g.DrawString($"Período: {rango}  |  Emitido: {DateTime.Now:dd/MM/yyyy HH:mm:ss}  |  Operador: {SesionUsuario.Nombre ?? "—"}",
                    fSub, bGris, x, y + 48);

                y += 75;
                g.DrawLine(penLinea, x, y, x + ancho, y);
                y += 12;

                float colFecha = x;
                float colCaja = x + 110;
                float colTipo = x + 155;
                float colConcepto = x + 240;
                float colMedio = x + 450;
                float colIngreso = x + 550;
                float colEgreso = x + 650;
                float colUsuario = x + 750;

                g.DrawString("Fecha / Hora", fHeader, bOcre, colFecha, y);
                g.DrawString("Caja", fHeader, bOcre, colCaja, y);
                g.DrawString("Tipo", fHeader, bOcre, colTipo, y);
                g.DrawString("Concepto / Detalle", fHeader, bOcre, colConcepto, y);
                g.DrawString("Medio Pago", fHeader, bOcre, colMedio, y);
                g.DrawString("Ingreso (+)", fHeader, bOcre, colIngreso, y);
                g.DrawString("Egreso (-)", fHeader, bOcre, colEgreso, y);
                g.DrawString("Usuario", fHeader, bOcre, colUsuario, y);

                y += 18;
                g.DrawLine(penLinea, x, y, x + ancho, y);
                y += 8;

                foreach (var mov in _movimientosFiltrados)
                {
                    string tipo = mov.TipoMovimientoDescripcion ?? "";
                    bool esEgresoPorTipo = tipo.Equals("Egreso", StringComparison.OrdinalIgnoreCase) ||
                                           tipo.Equals("Retiro", StringComparison.OrdinalIgnoreCase) ||
                                           tipo.Equals("Cierre", StringComparison.OrdinalIgnoreCase);
                    bool esIngreso = !esEgresoPorTipo && mov.Monto > 0;

                    if (y > e.PageBounds.Height - 100) break;

                    // ✅ Fecha convertida a hora local
                    string fechaStr = FechaHelper.ToArgentinaString(mov.FechaMovimiento, "dd/MM/yyyy HH:mm");
                    string cajaStr = mov.NumeroCaja.HasValue ? $"Caja {mov.NumeroCaja.Value}" : $"#{mov.CajaId}";

                    g.DrawString(fechaStr, fRow, bGrafito, colFecha, y);
                    g.DrawString(cajaStr, fRow, bGrafito, colCaja, y);
                    g.DrawString(tipo, fRow, bGrafito, colTipo, y);
                    g.DrawString(TruncarTexto(mov.Descripcion ?? "", 40), fRow, bGrafito, colConcepto, y);
                    g.DrawString("—", fRow, bGrafito, colMedio, y);

                    if (esIngreso)
                        g.DrawString(mov.Monto.ToString("C2"), fRow, bVerde, colIngreso, y);
                    else
                        g.DrawString(Math.Abs(mov.Monto).ToString("C2"), fRow, bRojo, colEgreso, y);

                    g.DrawString(mov.PersonalNombre ?? "", fRow, bGrafito, colUsuario, y);

                    y += 16;
                    g.DrawLine(penLineaFina, x, y - 4, x + ancho, y - 4);
                }

                y += 25;
                g.DrawLine(penLinea, x, y, x + ancho, y);
                y += 12;

                g.DrawString("RESUMEN DEL PERÍODO", fHeader, bOcre, x, y);
                y += 22;

                decimal totalEsperado = _fondoInicialFiltrado + _totalIngresosFiltrado - _totalEgresosFiltrado;

                g.DrawString($"Fondos iniciales:        {_fondoInicialFiltrado,15:C2}", fRow, bGrafito, x + 20, y); y += 18;
                g.DrawString($"Ingresos (+):            {_totalIngresosFiltrado,15:C2}", fRow, bVerde, x + 20, y); y += 18;
                g.DrawString($"Egresos / Retiros (-):   {_totalEgresosFiltrado,15:C2}", fRow, bRojo, x + 20, y); y += 22;

                g.DrawLine(penLinea, x + 20, y, x + 400, y);
                y += 8;

                g.DrawString($"TOTAL EN GAVETA:         {totalEsperado,15:C2}", fTotal, bOcre, x + 20, y);

                y = e.PageBounds.Height - 80;
                g.DrawLine(penLinea, x, y, x + ancho, y);
                y += 15;

                g.DrawString("_______________________________", fSub, bGrafito, x + 30, y);
                g.DrawString("Firma del Operador", fSub, bGris, x + 60, y + 20);

                g.DrawString("_______________________________", fSub, bGrafito, x + 400, y);
                g.DrawString("Firma del Contador", fSub, bGris, x + 440, y + 20);

                g.DrawString($"Documento oficial generado por el Sistema Hierro y Forja",
                    fSub, bGris, x + 700, y + 30);
            }
        }

        private string TruncarTexto(string texto, int max)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return texto.Length <= max ? texto : texto.Substring(0, max) + "…";
        }

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