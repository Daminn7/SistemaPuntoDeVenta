using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormCompras : Form
    {
        private DataTable _dtDetalle = new DataTable();
        private bool _actualizandoNroFactura = false;

        // Catálogo simulado (reemplazable por llamadas a _productoLogica y _proveedorLogica)
        private class ItemCatalogo
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal UltimoCosto { get; set; }
            public string ProveedorAsociado { get; set; }
        }

        private List<ItemCatalogo> _catalogoDisponible = new List<ItemCatalogo>();

        public FormCompras()
        {
            InitializeComponent();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = GenerarIconoCompras(Color.FromArgb(212, 131, 53));

            AsignarEstiloEIconos();
            ConfigurarRestriccionesTeclado();
            ConfigurarFormatoNroComprobante();
            InicializarEstructuraDetalle();
            CargarDesplegables();
            CargarCatalogoSimulado();
            LimpiarFormularioCompleto();
        }

        private void AsignarEstiloEIconos()
        {
            try
            {
                BGuardarCompra.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BCancelar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch
            {
                // Fallback silencioso
            }
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

        private void CargarDesplegables()
        {
            CBTipoComprobante.Items.Clear();
            CBTipoComprobante.Items.AddRange(new object[] { "Factura A", "Factura B", "Factura C", "Remito de Compra" });
            CBTipoComprobante.SelectedIndex = 0;

            CBFormaPago.Items.Clear();
            CBFormaPago.Items.AddRange(new object[] { "Efectivo", "Transferencia / Débito", "Cuenta Corriente (30 días)", "Cheque Propio" });
            CBFormaPago.SelectedIndex = 0;

            string[] proveedores = { "Acindar S.A.", "Siderca Techint", "Distribuidora Metalúrgica S.R.L.", "Ferretería Industrial Mayorista" };
            CBProveedor.Items.Clear();
            CBProveedor.Items.AddRange(proveedores);
            CBProveedor.SelectedIndex = -1;
        }

        private void CargarCatalogoSimulado()
        {
            _catalogoDisponible = new List<ItemCatalogo>
            {
                new ItemCatalogo { Id = 1, Codigo = "AC-001", Nombre = "Hierro del 8 Nervado (Barra 12m)", UltimoCosto = 12500m, ProveedorAsociado = "Acindar S.A." },
                new ItemCatalogo { Id = 2, Codigo = "AC-002", Nombre = "Hierro del 10 Nervado (Barra 12m)", UltimoCosto = 19200m, ProveedorAsociado = "Acindar S.A." },
                new ItemCatalogo { Id = 3, Codigo = "TB-101", Nombre = "Caño Estructural 40x40x1.6mm", UltimoCosto = 15800m, ProveedorAsociado = "Siderca Techint" },
                new ItemCatalogo { Id = 4, Codigo = "TB-102", Nombre = "Caño Redondo 2 Pulgadas Calibre 16", UltimoCosto = 21400m, ProveedorAsociado = "Siderca Techint" },
                new ItemCatalogo { Id = 5, Codigo = "CH-501", Nombre = "Chapa Galvanizada N° 25 (1.10 x 3.00)", UltimoCosto = 34500m, ProveedorAsociado = "Distribuidora Metalúrgica S.R.L." },
                new ItemCatalogo { Id = 6, Codigo = "EL-009", Nombre = "Electrodos Punta Azul 2.5mm (Caja 5kg)", UltimoCosto = 28900m, ProveedorAsociado = "Ferretería Industrial Mayorista" },
                new ItemCatalogo { Id = 7, Codigo = "DC-045", Nombre = "Disco de Corte 115x1.0mm (Pack x 25)", UltimoCosto = 11200m, ProveedorAsociado = "Ferretería Industrial Mayorista" }
            };
        }

        private void CBProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBProducto.DataSource = null;
            CBProducto.Items.Clear();

            if (CBProveedor.SelectedIndex == -1) return;

            string proveedorSeleccionado = CBProveedor.Text;
            var productosFiltrados = _catalogoDisponible
                .Where(p => p.ProveedorAsociado == proveedorSeleccionado)
                .ToList();

            if (productosFiltrados.Count == 0)
                productosFiltrados = _catalogoDisponible;

            CBProducto.DataSource = productosFiltrados;
            CBProducto.DisplayMember = "Nombre";
            CBProducto.ValueMember = "Id";
            CBProducto.SelectedIndex = -1;
        }

        private void CBProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProducto.SelectedItem is ItemCatalogo item)
            {
                TBCostoUnitario.Text = item.UltimoCosto.ToString("0.00");
                NUDCantidad.Value = 1;
            }
            else
            {
                TBCostoUnitario.Clear();
            }
        }

        // =========================================================================
        // ACCIONES DE DETALLE (AGREGAR / QUITAR RENGLÓN)
        // =========================================================================
        private void BAgregarItem_Click(object sender, EventArgs e)
        {
            if (CBProducto.SelectedItem == null || !(CBProducto.SelectedItem is ItemCatalogo item))
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

            // Si ya existe en la lista, acumulamos la cantidad
            DataRow filaExistente = _dtDetalle.AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt32(r["ColIdProducto"]) == item.Id);

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
                    item.Id,
                    item.Codigo,
                    item.Nombre,
                    cantidad,
                    costo.ToString("0.00"),
                    subtotalRenglon.ToString("0.00")
                );
            }

            RecalcularLiquidacion();

            // Limpiamos los campos del ítem
            CBProducto.SelectedIndex = -1;
            TBCostoUnitario.Clear();
            NUDCantidad.Value = 1;
            CBProducto.Focus();
        }

        private void DGVDetalleCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Clic en la columna "Quitar"
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

        // =========================================================================
        // CONFIRMACIÓN Y CANCELACIÓN DEL COMPROBANTE
        // =========================================================================
        private void BGuardarCompra_Click(object sender, EventArgs e)
        {
            if (CBProveedor.SelectedIndex == -1)
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

            // Aquí se conecta con _compraLogica.RegistrarCompra(dto) cuando esté disponible
            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea asentar la factura {TBNroComprobante.Text} por un total de $ {TBTotalCompra.Text}?\n\nLos {_dtDetalle.Rows.Count} artículos ingresarán inmediatamente al stock.",
                "Confirmar Recepción de Compra",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                MessageBox.Show("Compra registrada correctamente. El stock y los costos fueron actualizados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioCompleto();
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
        }
    }
}
