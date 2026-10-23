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
using static CapaPresentacion.FormPrincipal;

namespace CapaPresentacion
{
    public partial class FormCobroVenta : Form
    {
        private readonly OrdenVentaLogica _ordenVentaLogica = new OrdenVentaLogica();
        private readonly VentaLogica _ventaLogica = new VentaLogica();
        private readonly CajaLogica _cajaLogica = new CajaLogica();
        private readonly TablasMaestrasLogica _tablasLogica = new TablasMaestrasLogica();

        private int _idPedidoSeleccionado = 0;
        private decimal _totalActual = 0m;
        private int _cajaActivaId = 0;
        private bool _cajaAbierta = false;
        private List<MedioPagoDto> _mediosPago = new List<MedioPagoDto>();
        private DateTime? _fechaAperturaCaja = null;

        private CancellationTokenSource _ctsCarga;

        public FormCobroVenta()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private async void FormCobroVenta_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            AsignarIconoTitulo();
            CargarIconosPestanas();

            try
            {
                await Task.WhenAll(
                    CargarCajaActivaAsync(),
                    CargarMediosPagoAsync()
                );
                if (token.IsCancellationRequested) return;

                await CargarPedidosPendientesAsync();
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (this.IsDisposed || this.Disposing) return;

            ConfigurarDetalle();
            DGVMisCobros.CellClick += DGVMisCobros_CellClick;
            LimpiarFormularioCobro();

            if (!_cajaAbierta)
            {
                MessageBox.Show(
                    "No hay una caja abierta.\n\n" +
                    "Debe abrir la caja antes de poder cobrar pedidos.\n" +
                    "Vaya al módulo 'Caja' para abrir un turno.",
                    "Caja Cerrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

        private Image DibujarIconoCobro(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 4f, 7f, 24f, 15f);
                    g.FillEllipse(brush, 12.5f, 11.5f, 7f, 7f);
                    g.DrawLine(pen, 6f, 26f, 26f, 26f);
                }
            }
            return bmp;
        }

        private void AsignarIconoTitulo()
        {
            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = DibujarIconoCobro(Color.FromArgb(212, 131, 53));

            try
            {
                BConfirmarCobro.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BAnularPedido.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch { }
        }

        private void CargarIconosPestanas()
        {
            try
            {
                var il = new ImageList
                {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(24, 24),
                    TransparentColor = Color.Transparent
                };

                il.Images.Add("pedidos", GenerarIconoPedidos(Color.FromArgb(212, 131, 53)));
                il.Images.Add("cobros", GenerarIconoCobros(Color.FromArgb(39, 174, 96)));

                TCArriba.ImageList = il;

                if (TPPedidos != null) TPPedidos.ImageKey = "pedidos";
                if (TPMisCobros != null) TPMisCobros.ImageKey = "cobros";
            }
            catch { }
        }

        private Image GenerarIconoPedidos(Color color)
        {
            Bitmap bmp = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 4f, 3f, 16f, 18f);
                    g.DrawLine(pen, 7f, 8f, 17f, 8f);
                    g.DrawLine(pen, 7f, 12f, 17f, 12f);
                    g.DrawLine(pen, 7f, 16f, 13f, 16f);
                    g.FillEllipse(brush, 17f, 17f, 4f, 4f);
                }
            }
            return bmp;
        }

        private Image GenerarIconoCobros(Color color)
        {
            Bitmap bmp = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 3f, 7f, 18f, 11f);
                    g.FillEllipse(brush, 9.5f, 10.5f, 5f, 5f);
                    g.DrawLine(pen, 15f, 18f, 18f, 21f);
                    g.DrawLine(pen, 18f, 21f, 22f, 16f);
                }
            }
            return bmp;
        }

        private void InicializarComportamiento()
        {
            TBPagaCon.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
                    e.Handled = true;
            };

            TBPagaCon.TextChanged += (s, e) =>
            {
                if (decimal.TryParse(TBPagaCon.Text.Trim(), out decimal pago))
                {
                    decimal vuelto = pago - _totalActual;
                    if (vuelto >= 0)
                    {
                        LValorVuelto.Text = vuelto.ToString("C2");
                        LValorVuelto.ForeColor = Color.FromArgb(39, 174, 96);
                    }
                    else
                    {
                        LValorVuelto.Text = "Monto insuficiente";
                        LValorVuelto.ForeColor = Color.FromArgb(192, 57, 43);
                    }
                }
                else
                {
                    LValorVuelto.Text = "$ 0,00";
                    LValorVuelto.ForeColor = Color.FromArgb(39, 174, 96);
                }
            };
        }

        private async Task CargarCajaActivaAsync()
        {
            try
            {
                var cajaActiva = await _cajaLogica.ObtenerActiva();

                if (cajaActiva != null && cajaActiva.Id > 0)
                {
                    _cajaActivaId = cajaActiva.Id;
                    _fechaAperturaCaja = cajaActiva.FechaApertura;
                    _cajaAbierta = true;
                }
                else
                {
                    _cajaActivaId = 0;
                    _fechaAperturaCaja = null;
                    _cajaAbierta = false;
                }
            }
            catch
            {
                _cajaActivaId = 0;
                _fechaAperturaCaja = null;
                _cajaAbierta = false;
            }
        }

        private async Task CargarMediosPagoAsync()
        {
            try
            {
                _mediosPago = await _tablasLogica.GetMedioPagos();
                if (this.IsDisposed || this.Disposing) return;

                CBMedioPago.DataSource = null;
                CBMedioPago.DataSource = _mediosPago;
                CBMedioPago.DisplayMember = "Descripcion";
                CBMedioPago.ValueMember = "Id";
                CBMedioPago.SelectedIndex = -1;

                CBComprobante.Items.Clear();
                CBComprobante.Items.AddRange(new object[]
                {
                    "Ticket / Recibo X",
                    "Factura B (Consumidor Final)",
                    "Factura A (Responsable Inscripto)"
                });
                CBComprobante.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar medios de pago: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CargarPedidosPendientesAsync()
        {
            var token = _ctsCarga?.Token ?? CancellationToken.None;
            try
            {
                var todas = await _ordenVentaLogica.ObtenerTodas();
                if (token.IsCancellationRequested || this.IsDisposed) return;

                var pendientes = todas?
                    .Where(o => o.EstadoVentaId == 1 || o.EstadoVentaId == 2)
                    .OrderBy(o => o.EstadoVentaId)
                    .ThenBy(o => o.FechaCreacion)
                    .ToList() ?? new List<OrdenVentaDto>();

                DGVPendientes.SuspendLayout();
                DGVPendientes.Rows.Clear();

                if (pendientes.Count == 0)
                {
                    DGVPendientes.ResumeLayout();
                    DGVPendientes.ClearSelection();
                    return;
                }

                foreach (var orden in pendientes)
                {
                    string numPresupuesto = orden.NumeroPresupuesto ?? $"#{orden.IdOrden}";
                    string estadoTexto = orden.EstadoVentaId == 1 ? "Pendiente"
                        : orden.EstadoVentaId == 2 ? "Confirmada" : "—";

                    DGVPendientes.Rows.Add(
                        orden.IdOrden,
                        numPresupuesto,
                        orden.FechaCreacion.ToString("HH:mm"),
                        orden.PersonalNombre ?? "",
                        orden.ClienteNombre ?? "Consumidor Final",
                        estadoTexto,
                        orden.Total
                    );
                }

                DGVPendientes.ResumeLayout();
                DGVPendientes.ClearSelection();
                if (DGVPendientes.CurrentCell != null)
                    DGVPendientes.CurrentCell = null;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar pedidos: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarDetalle()
        {
            DGVDetalle.Rows.Clear();
        }

        private async void DGVPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var token = _ctsCarga?.Token ?? CancellationToken.None;

            try
            {
                var fila = DGVPendientes.Rows[e.RowIndex];
                _idPedidoSeleccionado = Convert.ToInt32(fila.Cells["ColIdPedido"].Value);
                _totalActual = Convert.ToDecimal(fila.Cells["ColTotalPedido"].Value);

                LTotalMonto.Text = _totalActual.ToString("C2");

                var orden = await _ordenVentaLogica.ObtenerPorId(_idPedidoSeleccionado);
                if (token.IsCancellationRequested || this.IsDisposed) return;

                DGVDetalle.SuspendLayout();
                DGVDetalle.Rows.Clear();

                if (orden?.Detalles != null)
                {
                    foreach (var det in orden.Detalles)
                    {
                        DGVDetalle.Rows.Add(
                            det.ProductoCodigo ?? "",
                            det.ProductoNombre ?? "",
                            det.Cantidad,
                            det.PrecioUnitario,
                            det.Subtotal
                        );
                    }
                }
                DGVDetalle.ResumeLayout();

                if (orden != null)
                {
                    LSubtituloDetalle.Text = $"DETALLE DEL PEDIDO ({orden.EstadoVentaDescripcion?.ToUpper()}):";
                }

                TBPagaCon.Text = _totalActual.ToString("0.00");
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar el detalle: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void DGVMisCobros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var token = _ctsCarga?.Token ?? CancellationToken.None;

            try
            {
                var fila = DGVMisCobros.Rows[e.RowIndex];
                string comprobante = fila.Cells["ColCobroComprobante"].Value?.ToString() ?? "";

                int ventaId = ExtraerVentaIdDeComprobante(comprobante);
                if (ventaId <= 0) return;

                var ventas = await _ventaLogica.ObtenerTodas();
                if (token.IsCancellationRequested || this.IsDisposed) return;

                var venta = ventas?.FirstOrDefault(v => v.Id == ventaId);
                if (venta == null) return;

                var orden = await _ordenVentaLogica.ObtenerPorId(venta.OrdenId);
                if (token.IsCancellationRequested || this.IsDisposed) return;
                if (orden?.Detalles == null) return;

                DGVDetalle.SuspendLayout();
                DGVDetalle.Rows.Clear();

                foreach (var det in orden.Detalles)
                {
                    DGVDetalle.Rows.Add(
                        det.ProductoCodigo ?? "",
                        det.ProductoNombre ?? "",
                        det.Cantidad,
                        det.PrecioUnitario,
                        det.Subtotal
                    );
                }
                DGVDetalle.ResumeLayout();

                decimal total = venta.TotalCobrado;
                LSubtituloDetalle.Text = $"DETALLE DEL COBRO ({comprobante}) - Total: {total:C2}";
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar el detalle del cobro: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int ExtraerVentaIdDeComprobante(string comprobante)
        {
            if (string.IsNullOrWhiteSpace(comprobante)) return 0;

            int guion = comprobante.LastIndexOf('-');
            if (guion < 0 || guion == comprobante.Length - 1) return 0;

            string ultimo = comprobante.Substring(guion + 1);
            return int.TryParse(ultimo, out int id) ? id : 0;
        }

        private async void TCArriba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TCArriba.SelectedTab == TPMisCobros)
            {
                await CargarMisCobrosAsync();
            }
        }

        private async Task CargarMisCobrosAsync()
        {
            var token = _ctsCarga?.Token ?? CancellationToken.None;
            try
            {
                var ventas = await _ventaLogica.ObtenerTodas();
                if (token.IsCancellationRequested || this.IsDisposed) return;

                DGVMisCobros.SuspendLayout();
                DGVMisCobros.Rows.Clear();

                if (ventas == null || ventas.Count == 0)
                {
                    DGVMisCobros.ResumeLayout();
                    return;
                }

                int personalIdActual = SesionUsuario.IdPersonal;

                var misCobros = ventas
                    .Where(v => v.PersonalId == personalIdActual)
                    .Where(v => _fechaAperturaCaja == null || v.FechaCobro >= _fechaAperturaCaja.Value)
                    .OrderByDescending(v => v.FechaCobro)
                    .ToList();

                foreach (var venta in misCobros)
                {
                    string cliente = string.IsNullOrWhiteSpace(venta.ClienteNombre) ? "—" : venta.ClienteNombre;
                    string formaPago = string.IsNullOrWhiteSpace(venta.FormaPago) ? "—" : venta.FormaPago;

                    DGVMisCobros.Rows.Add(
                        venta.FechaCobro.ToString("HH:mm:ss"),
                        $"VTA-0001-{venta.Id:D6}",
                        cliente,
                        formaPago,
                        venta.TotalCobrado.ToString("C2")
                    );
                }

                DGVMisCobros.ResumeLayout();
                DGVMisCobros.ClearSelection();
                if (DGVMisCobros.CurrentCell != null)
                    DGVMisCobros.CurrentCell = null;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar tus cobros: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BConfirmarCobro_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un pedido pendiente de la lista para cobrar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_cajaAbierta || _cajaActivaId <= 0)
            {
                MessageBox.Show(
                    "No hay una caja abierta.\n\n" +
                    "Debe abrir la caja antes de cobrar.\n" +
                    "Vaya al módulo 'Caja' para abrir un turno.",
                    "Caja Cerrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (CBMedioPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un medio de pago.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var orden = await _ordenVentaLogica.ObtenerPorId(_idPedidoSeleccionado);

                if (orden == null)
                {
                    MessageBox.Show("No se pudo obtener la orden.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (orden.EstadoVentaId == 1)
                {
                    DialogResult resConf = MessageBox.Show(
                        "El pedido está PENDIENTE.\n\n" +
                        "Para cobrarlo, primero hay que CONFIRMARLO.\n" +
                        "Esto validará el stock disponible y lo descontará.\n\n" +
                        "¿Desea confirmarlo y cobrarlo?",
                        "Confirmar y Cobrar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resConf != DialogResult.Yes) return;

                    try
                    {
                        await _ordenVentaLogica.Confirmar(_idPedidoSeleccionado);
                    }
                    catch (Exception exConfirmar)
                    {
                        MessageBox.Show(
                            $"No se pudo confirmar el pedido:\n\n{exConfirmar.Message}\n\n" +
                            "Verifique el stock de los productos.",
                            "Stock Insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                decimal montoPagado = _totalActual;
                var medioPago = CBMedioPago.SelectedItem as MedioPagoDto;

                if (medioPago != null && medioPago.Descripcion == "Efectivo")
                {
                    if (!decimal.TryParse(TBPagaCon.Text.Trim(), out montoPagado))
                    {
                        MessageBox.Show("Ingrese un monto válido en 'Paga con'.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TBPagaCon.Focus();
                        return;
                    }

                    if (montoPagado < _totalActual)
                    {
                        MessageBox.Show("El monto abonado no puede ser inferior al total de la compra.",
                            "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TBPagaCon.Focus();
                        return;
                    }
                }

                if (medioPago == null) return;

                DialogResult res = MessageBox.Show(
                    $"¿Confirmar cobro y registrar en Caja?\n\n" +
                    $"Pedido: {DGVPendientes.CurrentRow?.Cells["ColNroPedido"].Value}\n" +
                    $"Total: {_totalActual:C2}\n" +
                    $"Medio: {medioPago.Descripcion}\n" +
                    $"Monto recibido: {montoPagado:C2}\n" +
                    $"Vuelto: {(montoPagado - _totalActual):C2}",
                    "Confirmar Cobro",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res != DialogResult.Yes) return;

                BConfirmarCobro.Enabled = false;

                var cobro = new CrearVentaCompletaDto
                {
                    OrdenId = _idPedidoSeleccionado,
                    PersonalId = SesionUsuario.IdPersonal,
                    CajaId = _cajaActivaId,
                    DescuentoAplicado = 0,
                    RecargoAplicado = 0,
                    Pagos = new List<PagoInputDto>
                    {
                        new PagoInputDto
                        {
                            MedioPagoId = medioPago.Id,
                            Monto = montoPagado,
                            Detalle = $"Pago con {medioPago.Descripcion}"
                        }
                    }
                };

                var resultado = await _ventaLogica.Cobrar(cobro);
                if (this.IsDisposed || this.Disposing) return;

                int ventaId = (int)(resultado?.ventaId ?? 0);
                string numPresupuesto = DGVPendientes.CurrentRow?.Cells["ColNroPedido"].Value?.ToString() ?? "";

                MessageBox.Show(
                    $"✅ Cobro registrado correctamente.\n\n" +
                    $"Comprobante: {numPresupuesto}\n" +
                    $"Venta N°: {ventaId}\n" +
                    $"Total cobrado: {_totalActual:C2}\n" +
                    $"Medio de pago: {medioPago.Descripcion}\n\n" +
                    "La orden fue marcada como Finalizada.",
                    "Venta Facturada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await CargarPedidosPendientesAsync();
                LimpiarFormularioCobro();

                if (TCArriba.SelectedTab == TPMisCobros)
                {
                    await CargarMisCobrosAsync();
                }
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    MessageBox.Show($"Error al registrar el cobro:\n{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                BConfirmarCobro.Enabled = true;
            }
        }

        private async void BAnularPedido_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un pedido para anular.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult res = MessageBox.Show(
                "¿Está seguro de anular este pedido?\n\n" +
                "La orden será CANCELADA.\n" +
                "(No se repondrá stock porque todavía no se descontó al confirmar.)",
                "Anular Pedido",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                try
                {
                    await _ordenVentaLogica.Cancelar(_idPedidoSeleccionado);
                    if (this.IsDisposed || this.Disposing) return;

                    MessageBox.Show("Pedido anulado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarPedidosPendientesAsync();
                    LimpiarFormularioCobro();
                }
                catch (Exception ex)
                {
                    if (!this.IsDisposed)
                    {
                        MessageBox.Show($"Error al anular pedido: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimpiarFormularioCobro()
        {
            _idPedidoSeleccionado = 0;
            _totalActual = 0m;
            DGVDetalle.Rows.Clear();
            LTotalMonto.Text = "$ 0,00";
            TBPagaCon.Clear();
            LValorVuelto.Text = "$ 0,00";
            CBMedioPago.SelectedIndex = -1;
            LSubtituloDetalle.Text = "DETALLE DE ARTÍCULOS DEL PEDIDO SELECCIONADO:";

            DGVPendientes.ClearSelection();
            if (DGVPendientes.CurrentCell != null)
                DGVPendientes.CurrentCell = null;
        }

        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            if (imagenOriginal == null) return null;

            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return nuevoBitmap;
        }
    }
}