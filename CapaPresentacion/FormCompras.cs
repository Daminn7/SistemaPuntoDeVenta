using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.DTOs;
using CapaLogica;
using static CapaPresentacion.FormPrincipal;

namespace CapaPresentacion
{
    public partial class FormCompras : Form
    {
        private DataTable _dtDetalle = new DataTable();
        private bool _actualizandoNroFactura = false;
        private CancellationTokenSource _ctsCarga;

        private readonly CompraLogica _compraLogica = new CompraLogica();
        private readonly ProveedorLogica _proveedorLogica = new ProveedorLogica();
        private readonly ProductoLogica _productoLogica = new ProductoLogica();

        private List<ProveedorDto> _proveedoresReales = new List<ProveedorDto>();
        private List<ProductoDto> _productosReales = new List<ProductoDto>();

        public FormCompras()
        {
            InitializeComponent();
        }

        private async void FormCompras_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = GenerarIconoCompras(Color.FromArgb(212, 131, 53));

            AsignarEstiloEIconos();
            ConfigurarRestriccionesTeclado();
            ConfigurarFormatoNroComprobante();
            InicializarEstructuraDetalle();
            ConfigurarFiltrosDetalle();
            CargarDesplegablesFijos();

            try
            {
                await Task.WhenAll(
                    CargarProveedoresAsync(token),
                    CargarProductosAsync(token)
                );
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (!this.IsDisposed)
                LimpiarFormularioCompleto();
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

        private async Task CargarProveedoresAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                var proveedores = await _proveedorLogica.ObtenerTodos();
                if (token.IsCancellationRequested || this.IsDisposed) return;

                _proveedoresReales = proveedores?.Where(p => p.Estado).ToList() ?? new List<ProveedorDto>();

                CBProveedor.DataSource = null;
                CBProveedor.DisplayMember = "Nombre";
                CBProveedor.ValueMember = "Id";
                CBProveedor.DataSource = _proveedoresReales;
                CBProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CargarProductosAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                var productos = await _productoLogica.ObtenerTodos();
                if (token.IsCancellationRequested || this.IsDisposed) return;

                _productosReales = productos?.Where(p => p.Estado).ToList() ?? new List<ProductoDto>();

                // ✅ Cargar el combo con todos los productos
                CargarProductosEnCombo(_productosReales);
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarProductosEnCombo(List<ProductoDto> productos)
        {
            if (productos == null || productos.Count == 0)
            {
                CBProducto.DataSource = null;
                CBProducto.Items.Clear();
                CBProducto.Enabled = false;
                return;
            }

            CBProducto.DataSource = null;
            CBProducto.DisplayMember = "Nombre";
            CBProducto.ValueMember = "Id";
            CBProducto.DataSource = productos;
            CBProducto.SelectedIndex = -1;
            CBProducto.Enabled = true;
        }

        private void CBProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_productosReales == null || _productosReales.Count == 0) return;

            // Si no hay proveedor seleccionado, mostrar todos
            if (CBProveedor.SelectedIndex == -1 || CBProveedor.SelectedValue == null)
            {
                CargarProductosEnCombo(_productosReales);
                return;
            }

            int idProveedor = (int)CBProveedor.SelectedValue;

            // Filtrar productos de ese proveedor
            var productosDelProveedor = _productosReales
                .Where(p => p.ProveedorId.HasValue && p.ProveedorId.Value == idProveedor)
                .ToList();

            if (productosDelProveedor.Count > 0)
            {
                CargarProductosEnCombo(productosDelProveedor);
            }
            else
            {
                CargarProductosEnCombo(_productosReales);
            }
        }

        private void CBProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProducto.SelectedItem is ProductoDto prod)
            {
                TBCostoUnitario.Text = prod.Costo.ToString("0.00");
                NUDCantidad.Value = 1;
            }
            else
            {
                TBCostoUnitario.Clear();
            }
        }

        // ============================================================
        // ICONOS Y ESTILOS
        // ============================================================
        private void AsignarEstiloEIconos()
        {
            try
            {
                BGuardarCompra.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BCancelar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch { }
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

        private Image GenerarIconoCompras(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    PointF[] canasta = new PointF[]
                    {
                        new PointF(4.5f, 7.5f),
                        new PointF(7.5f, 7.5f),
                        new PointF(10.5f, 19.5f),
                        new PointF(25.5f, 19.5f),
                        new PointF(27.5f, 10.5f),
                        new PointF(8.5f, 10.5f)
                    };
                    g.DrawLines(pen, canasta);
                    g.DrawLine(pen, 15.5f, 11.5f, 14.5f, 18.5f);
                    g.DrawLine(pen, 21.5f, 11.5f, 20.5f, 18.5f);
                    g.FillEllipse(brush, 10f, 22f, 4.5f, 4.5f);
                    g.FillEllipse(brush, 22f, 22f, 4.5f, 4.5f);
                }
            }
            return bmp;
        }

        // ============================================================
        // FILTROS Y ESTRUCTURA DE LA GRILLA
        // ============================================================
        private void ConfigurarFiltrosDetalle()
        {
            TBBuscar.TextChanged += (s, e) => FiltrarComboProductos();
        }

        private void FiltrarComboProductos()
        {
            string texto = TBBuscar.Text.Trim().ToLower();

            var baseProductos = _productosReales;
            if (CBProveedor.SelectedIndex != -1 && CBProveedor.SelectedValue != null)
            {
                int idProveedor = (int)CBProveedor.SelectedValue;
                var delProveedor = _productosReales
                    .Where(p => p.ProveedorId.HasValue && p.ProveedorId.Value == idProveedor)
                    .ToList();

                if (delProveedor.Count > 0)
                    baseProductos = delProveedor;
            }

            if (string.IsNullOrEmpty(texto))
            {
                CargarProductosEnCombo(baseProductos);
                return;
            }

            var filtrados = baseProductos
                .Where(p =>
                    (!string.IsNullOrEmpty(p.Nombre) && p.Nombre.ToLower().Contains(texto)) ||
                    (!string.IsNullOrEmpty(p.CodigoInterno) && p.CodigoInterno.ToLower().Contains(texto)) ||
                    (!string.IsNullOrEmpty(p.CodBarras) && p.CodBarras.ToLower().Contains(texto)))
                .ToList();

            CargarProductosEnCombo(filtrados);
        }

        private void InicializarEstructuraDetalle()
        {
            if (_dtDetalle.Columns.Count == 0)
            {
                _dtDetalle.Columns.Add("ColIdProducto", typeof(int));
                _dtDetalle.Columns.Add("ColCodigo", typeof(string));
                _dtDetalle.Columns.Add("ColDescripcion", typeof(string));
                _dtDetalle.Columns.Add("ColCantidad", typeof(int));
                _dtDetalle.Columns.Add("ColCostoUnitario", typeof(string));
                _dtDetalle.Columns.Add("ColSubtotal", typeof(string));
            }

            DGVDetalleCompra.AutoGenerateColumns = false;
            ColIdProducto.DataPropertyName = "ColIdProducto";
            ColCodigo.DataPropertyName = "ColCodigo";
            ColDescripcion.DataPropertyName = "ColDescripcion";
            ColCantidad.DataPropertyName = "ColCantidad";
            ColCostoUnitario.DataPropertyName = "ColCostoUnitario";
            ColSubtotal.DataPropertyName = "ColSubtotal";

            DGVDetalleCompra.DataSource = _dtDetalle;
        }

        private void ConfigurarRestriccionesTeclado()
        {
            TBNroComprobante.MaxLength = 20;
            TBCostoUnitario.KeyPress += PermitirDecimales_KeyPress;
            TBCostoUnitario.Leave += (s, e) =>
            {
                if (decimal.TryParse(TBCostoUnitario.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                {
                    TBCostoUnitario.Text = valor.ToString("0.00");
                }
            };
        }

        private void PermitirDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            char sep = ',';

            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (txt.Text.Contains(",") || txt.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
                e.KeyChar = sep;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void ConfigurarFormatoNroComprobante()
        {
            TBNroComprobante.TextChanged += (s, e) =>
            {
                if (_actualizandoNroFactura) return;

                string digitos = new string(TBNroComprobante.Text.Where(char.IsDigit).ToArray());
                if (digitos.Length > 12) digitos = digitos.Substring(0, 12);

                string formateado = digitos;
                if (digitos.Length > 4)
                {
                    formateado = $"{digitos.Substring(0, 4)}-{digitos.Substring(4)}";
                }

                _actualizandoNroFactura = true;
                TBNroComprobante.Text = formateado;
                TBNroComprobante.SelectionStart = TBNroComprobante.Text.Length;
                _actualizandoNroFactura = false;
            };
        }

        private void CargarDesplegablesFijos()
        {
            CBTipoComprobante.Items.Clear();
            CBTipoComprobante.Items.AddRange(new object[] { "Factura A", "Factura B", "Factura C", "Remito de Compra" });
            CBTipoComprobante.SelectedIndex = 0;

            CBFormaPago.Items.Clear();
            CBFormaPago.Items.AddRange(new object[] { "Efectivo", "Transferencia / Débito", "Cuenta Corriente (30 días)", "Cheque Propio" });
            CBFormaPago.SelectedIndex = 0;
        }

        // ============================================================
        // AGREGAR / QUITAR RENGLÓN
        // ============================================================
        private void BAgregarItem_Click(object sender, EventArgs e)
        {
            if (!(CBProducto.SelectedItem is ProductoDto prod))
            {
                MessageBox.Show("Seleccione un producto para agregar a la compra.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBProducto.Focus();
                return;
            }

            if (!decimal.TryParse(TBCostoUnitario.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal costo) || costo <= 0)
            {
                MessageBox.Show("Ingrese un costo unitario válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBCostoUnitario.Focus();
                return;
            }

            int cantidad = (int)NUDCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotalRenglon = costo * cantidad;

            DataRow filaExistente = _dtDetalle.AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt32(r["ColIdProducto"]) == prod.Id);

            if (filaExistente != null)
            {
                int cantActual = Convert.ToInt32(filaExistente["ColCantidad"]);
                int nuevaCantidad = cantActual + cantidad;
                decimal nuevoSubtotal = nuevaCantidad * costo;

                filaExistente["ColCantidad"] = nuevaCantidad;
                filaExistente["ColCostoUnitario"] = costo.ToString("0.00");
                filaExistente["ColSubtotal"] = nuevoSubtotal.ToString("0.00");
            }
            else
            {
                _dtDetalle.Rows.Add(
                    prod.Id,
                    prod.CodigoInterno ?? "",
                    prod.Nombre,
                    cantidad,
                    costo.ToString("0.00"),
                    subtotalRenglon.ToString("0.00")
                );
            }

            RecalcularLiquidacion();

            CBProducto.SelectedIndex = -1;
            TBCostoUnitario.Clear();
            NUDCantidad.Value = 1;
            CBProducto.Focus();
        }

        private void DGVDetalleCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DGVDetalleCompra.Columns[e.ColumnIndex].Name == "ColAccionEliminar")
            {
                _dtDetalle.Rows.RemoveAt(e.RowIndex);
                RecalcularLiquidacion();
            }
        }

        private void RecalcularLiquidacion()
        {
            decimal sumaSubtotales = 0m;

            foreach (DataRow row in _dtDetalle.Rows)
            {
                if (decimal.TryParse(row["ColSubtotal"].ToString().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal sub))
                {
                    sumaSubtotales += sub;
                }
            }

            decimal iva = sumaSubtotales * 0.21m;
            decimal totalFinal = sumaSubtotales + iva;

            TBSubtotal.Text = sumaSubtotales.ToString("N2");
            TBIva.Text = iva.ToString("N2");
            TBTotalCompra.Text = totalFinal.ToString("N2");
        }

        // ============================================================
        // GUARDAR COMPRA (CONECTADO A LA API)
        // ============================================================
        private async void BGuardarCompra_Click(object sender, EventArgs e)
        {
            if (CBProveedor.SelectedIndex == -1 || CBProveedor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBProveedor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TBNroComprobante.Text) || TBNroComprobante.Text.Length < 6)
            {
                MessageBox.Show("Ingrese un número de comprobante válido (formato ####-########).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNroComprobante.Focus();
                return;
            }

            if (_dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un insumo en el detalle de la compra.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBProducto.Focus();
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea asentar la factura {TBNroComprobante.Text} por un total de $ {TBTotalCompra.Text}?\n\nLos {_dtDetalle.Rows.Count} artículos ingresarán inmediatamente al stock.",
                "Confirmar Recepción de Compra",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                BGuardarCompra.Enabled = false;

                var nuevaCompra = new CrearCompraDto
                {
                    NumeroFactura = TBNroComprobante.Text.Trim(),
                    ProveedorId = (int)CBProveedor.SelectedValue,
                    PersonalId = SesionUsuario.IdPersonal,
                    TipoComprobante = CBTipoComprobante.Text,
                    FormaPago = CBFormaPago.Text,
                    FechaEmision = DTPFechaEmision.Value,
                    Detalles = new List<CrearDetalleCompraDto>()
                };

                foreach (DataRow row in _dtDetalle.Rows)
                {
                    nuevaCompra.Detalles.Add(new CrearDetalleCompraDto
                    {
                        ProductoId = Convert.ToInt32(row["ColIdProducto"]),
                        Cantidad = Convert.ToInt32(row["ColCantidad"]),
                        CostoUnitario = decimal.Parse(row["ColCostoUnitario"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture)
                    });
                }

                var resultado = await _compraLogica.Crear(nuevaCompra);

                MessageBox.Show(
                    $"Compra registrada correctamente.\n\n" +
                    $"Factura: {nuevaCompra.NumeroFactura}\n" +
                    $"Total: {TBTotalCompra.Text}\n" +
                    "El stock de los productos fue actualizado.",
                    "Compra Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormularioCompleto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar compra:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BGuardarCompra.Enabled = true;
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            if (_dtDetalle.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de descartar la compra en curso y vaciar la lista?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            LimpiarFormularioCompleto();
        }

        private void LimpiarFormularioCompleto()
        {
            CBProveedor.SelectedIndex = -1;
            CBTipoComprobante.SelectedIndex = 0;
            TBNroComprobante.Clear();
            DTPFechaEmision.Value = DateTime.Now;
            CBFormaPago.SelectedIndex = 0;

            CBProducto.DataSource = null;
            CBProducto.Items.Clear();
            TBCostoUnitario.Clear();
            NUDCantidad.Value = 1;

            _dtDetalle.Rows.Clear();
            TBSubtotal.Text = "0,00";
            TBIva.Text = "0,00";
            TBTotalCompra.Text = "0,00";

            DGVDetalleCompra.ClearSelection();
            if (DGVDetalleCompra.CurrentCell != null)
                DGVDetalleCompra.CurrentCell = null;

            CargarProductosEnCombo(_productosReales);
        }

        // ============================================================
        // ALTA RÁPIDA DE PROVEEDOR / PRODUCTO
        // ============================================================
        private async void BNuevoProveedor_Click(object sender, EventArgs e)
        {
            using (FormProveedores frmProv = new FormProveedores())
            {
                frmProv.StartPosition = FormStartPosition.CenterParent;
                frmProv.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmProv.ShowInTaskbar = false;

                if (frmProv.ShowDialog(this) == DialogResult.OK || frmProv.DialogResult == DialogResult.Cancel)
                {
                    var proveedorPrevio = CBProveedor.SelectedValue;
                    await CargarProveedoresAsync(_ctsCarga?.Token ?? CancellationToken.None);

                    if (proveedorPrevio != null)
                    {
                        CBProveedor.SelectedValue = proveedorPrevio;
                    }
                }
            }
        }

        private async void BNuevoProducto_Click(object sender, EventArgs e)
        {
            using (FormProductos frmProd = new FormProductos())
            {
                frmProd.StartPosition = FormStartPosition.CenterParent;
                frmProd.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmProd.ShowInTaskbar = false;

                if (frmProd.ShowDialog(this) == DialogResult.OK || frmProd.DialogResult == DialogResult.Cancel)
                {
                    await CargarProductosAsync(_ctsCarga?.Token ?? CancellationToken.None);
                }
            }
        }
    }
}