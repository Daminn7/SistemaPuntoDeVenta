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
    public partial class FormHistorialVentas : Form
    {
        private readonly OrdenVentaLogica _ordenVentaLogica = new OrdenVentaLogica();
        private List<OrdenVentaDto> _ordenesOriginales = new List<OrdenVentaDto>();
        private int _idOrdenSeleccionada = 0;
        private OrdenVentaDto _ordenDetalleActual = null;
        private CancellationTokenSource _ctsCarga;

        public FormHistorialVentas()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private async void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            pbIconoTitulo.Image = GenerarIconoHistorial(Color.FromArgb(212, 131, 53));
            ConfigurarFechas();
            CargarDesplegableEstados();

            try
            {
                await CargarOrdenesAsync(token);
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (!this.IsDisposed)
            {
                dgvVentas.ClearSelection();
                dgvVentas.CurrentCell = null;
                dgvDetalle.Rows.Clear();
                lblTotalMonto.Text = "$ 0,00";
            }
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

        private void InicializarComportamiento()
        {
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            cboEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            dtpDesde.ValueChanged += (s, e) => AplicarFiltros();
            dtpHasta.ValueChanged += (s, e) => AplicarFiltros();
            btnBuscar.Click += (s, e) => AplicarFiltros();

            btnLimpiar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                cboEstado.SelectedIndex = 0;
                ConfigurarFechas();
                AplicarFiltros();
            };

            dgvVentas.CellFormatting += (s, e) =>
            {
                if (dgvVentas.Columns[e.ColumnIndex].Name == "colEstado" && e.Value != null)
                {
                    string estado = e.Value.ToString();
                    switch (estado)
                    {
                        case "Pendiente": e.CellStyle.ForeColor = Color.FromArgb(212, 131, 53); break;
                        case "Confirmada": e.CellStyle.ForeColor = Color.FromArgb(41, 128, 185); break;
                        case "Finalizada": e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96); break;
                        case "Cancelada": e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34); break;
                        case "Anulada": e.CellStyle.ForeColor = Color.FromArgb(192, 57, 43); break;
                        default: e.CellStyle.ForeColor = Color.FromArgb(30, 30, 30); break;
                    }
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            };

            dgvVentas.CellClick += async (s, e) =>
            {
                if (e.RowIndex < 0) return;
                await CargarDetalleOrdenAsync(e.RowIndex);
            };

            btnReimprimir.Click += async (s, e) => await ReimprimirOrdenAsync();
            btnAnular.Click += async (s, e) => await AnularOrdenAsync();
        }

        private void ConfigurarFechas()
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
        }

        private async Task CargarOrdenesAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                var todas = await _ordenVentaLogica.ObtenerTodas();
                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                _ordenesOriginales = todas?.OrderByDescending(o => o.FechaCreacion).ToList() ?? new List<OrdenVentaDto>();
                MostrarOrdenes(_ordenesOriginales);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                    MessageBox.Show($"Error al cargar órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarOrdenes(List<OrdenVentaDto> ordenes)
        {
            dgvVentas.SuspendLayout();
            dgvVentas.Rows.Clear();

            foreach (var orden in ordenes)
            {
                string fechaStr = FechaHelper.ToArgentinaString(orden.FechaCreacion, "dd/MM/yyyy HH:mm");
                dgvVentas.Rows.Add(orden.IdOrden, orden.NumeroPresupuesto ?? $"#{orden.IdOrden}", fechaStr,
                    orden.ClienteNombre ?? "Consumidor Final", orden.PersonalNombre ?? "",
                    orden.FormaPago ?? "", orden.Total, orden.EstadoVentaDescripcion ?? "");
            }
            dgvVentas.ResumeLayout();
        }

        private async Task CargarDetalleOrdenAsync(int rowIndex)
        {
            var token = _ctsCarga?.Token ?? CancellationToken.None;
            try
            {
                var idValue = dgvVentas.Rows[rowIndex].Cells["colIdVenta"].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int idOrden = Convert.ToInt32(idValue);
                _idOrdenSeleccionada = idOrden;

                var orden = await _ordenVentaLogica.ObtenerPorId(idOrden);
                if (token.IsCancellationRequested || this.IsDisposed) return;

                _ordenDetalleActual = orden;
                dgvDetalle.SuspendLayout();
                dgvDetalle.Rows.Clear();

                if (orden?.Detalles != null)
                {
                    foreach (var d in orden.Detalles)
                        dgvDetalle.Rows.Add(d.Cantidad, d.ProductoNombre ?? "", d.PrecioUnitario.ToString("N2"), d.Subtotal.ToString("N2"));
                }
                dgvDetalle.ResumeLayout();
                lblTotalMonto.Text = orden?.Total.ToString("C2") ?? "$ 0,00";
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                    MessageBox.Show($"Error al cargar detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDesplegableEstados()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "Confirmada", "Finalizada", "Cancelada", "Anulada" });
            cboEstado.SelectedIndex = 0;
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim().ToLower();
            string estadoFiltro = cboEstado.SelectedIndex > 0 ? cboEstado.Text : "";
            DateTime fechaDesde = dtpDesde.Value.Date;
            DateTime fechaHasta = dtpHasta.Value.Date.AddDays(1);

            dgvVentas.SuspendLayout();
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.IsNewRow) continue;
                string ticket = row.Cells["colNroTicket"].Value?.ToString().ToLower() ?? "";
                string cliente = row.Cells["colCliente"].Value?.ToString().ToLower() ?? "";
                string vendedor = row.Cells["colVendedor"].Value?.ToString().ToLower() ?? "";
                string estado = row.Cells["colEstado"].Value?.ToString() ?? "";
                string fechaStr = row.Cells["colFecha"].Value?.ToString() ?? "";

                DateTime.TryParse(fechaStr, out DateTime fecha);
                bool coincideFecha = fecha >= fechaDesde && fecha < fechaHasta;
                bool coincideTexto = string.IsNullOrEmpty(texto) || ticket.Contains(texto) || cliente.Contains(texto) || vendedor.Contains(texto);
                bool coincideEstado = string.IsNullOrEmpty(estadoFiltro) || estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase);
                row.Visible = coincideTexto && coincideEstado && coincideFecha;
            }
            dgvVentas.ResumeLayout();

            dgvDetalle.Rows.Clear();
            _idOrdenSeleccionada = 0;
            _ordenDetalleActual = null;
            lblTotalMonto.Text = "$ 0,00";
        }

        private async Task ReimprimirOrdenAsync()
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para reimprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int idOrden = Convert.ToInt32(dgvVentas.CurrentRow.Cells["colIdVenta"].Value ?? 0);
                var orden = await _ordenVentaLogica.ObtenerPorId(idOrden);
                if (orden == null) return;
                _ordenDetalleActual = orden;

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += ImprimirTicket_PrintPage;
                new PrintPreviewDialog { Document = pd, Width = 850, Height = 650 }.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show($"Error al reimprimir:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ImprimirTicket_PrintPage(object sender, PrintPageEventArgs e)
        {
            // El mismo código de impresión que tenías...
        }

        private async Task AnularOrdenAsync()
        {
            // ✅ NUEVO: Validar que no sea Cajero
            string rol = (SesionUsuario.Rol ?? "").Trim().ToUpper();
            if (rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                MessageBox.Show("El perfil de Cajero no tiene permisos para anular ventas.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvVentas.CurrentRow == null) return;

            try
            {
                int idOrden = Convert.ToInt32(dgvVentas.CurrentRow.Cells["colIdVenta"].Value ?? 0);
                string estado = dgvVentas.CurrentRow.Cells["colEstado"].Value?.ToString() ?? "";

                if (estado == "Anulada" || estado == "Cancelada") return;

                if (estado == "Pendiente" || estado == "Confirmada")
                    await _ordenVentaLogica.Cancelar(idOrden);
                else if (estado == "Finalizada")
                    await _ordenVentaLogica.Anular(idOrden);

                MessageBox.Show("Orden procesada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarOrdenesAsync(_ctsCarga?.Token ?? CancellationToken.None);
            }
            catch (Exception ex) { MessageBox.Show($"Error al anular: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private Image GenerarIconoHistorial(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawEllipse(pen, 3.5f, 3.5f, 24f, 24f);
                    g.DrawLine(pen, 15.5f, 9f, 15.5f, 15.5f);
                    g.DrawLine(pen, 15.5f, 15.5f, 21f, 15.5f);
                    g.FillEllipse(brush, 14f, 14f, 3.5f, 3.5f);
                }
            }
            return bmp;
        }
    }
}