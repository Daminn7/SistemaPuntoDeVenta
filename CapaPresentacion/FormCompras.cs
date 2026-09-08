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
        private DataTable _dtCompras = new DataTable();
        private int _idCompraSeleccionada = 0;
        private bool _actualizandoNroFactura = false;
        private bool _calculandoTotales = false;

        public FormCompras()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            if (PBIconoTitulo != null)
            {
                // Color Ocre (#D48335) para mantener la identidad visual del título
                PBIconoTitulo.Image = GenerarIconoCompras(Color.FromArgb(212, 131, 53));
            }
            AsignarEstiloEIconos();
            CargarDesplegablesSimulados();
            CargarHistorialComprasSimulado();

            // 1. Limpia los campos del panel lateral para que arranque listo para una nueva carga
            LimpiarFormulario();

            // 2. Desmarca cualquier fila para que no se pinte la franja naranja al abrir
            DGVCompras.ClearSelection();
            DGVCompras.CurrentCell = null;
        }

        private void InicializarComportamiento()
        {
            ConfigurarRestriccionesTeclado();
            ConfigurarFechaEmision();
            ConfigurarCalculoTotalesEnVivo();
            ConfigurarFiltrosDinamicos();
        }
        // =========================================================================
        // ÍCONO VECTORIAL: COMPRAS (Carro / Canasta de compras comercial)
        // =========================================================================
        private Image GenerarIconoCompras(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Canasta / canasto del carro
                    PointF[] canasta = new PointF[]
                    {
                new PointF(4.5f, 7.5f),   // Manija / Inicio
                new PointF(7.5f, 7.5f),   // Quiebre manija
                new PointF(10.5f, 19.5f), // Bajada frontal
                new PointF(25.5f, 19.5f), // Base inferior
                new PointF(27.5f, 10.5f), // Subida trasera
                new PointF(8.5f, 10.5f)   // Línea superior del canasto
                    };
                    g.DrawLines(pen, canasta);

                    // Rejilla interna vertical del carro
                    g.DrawLine(pen, 15.5f, 11.5f, 14.5f, 18.5f);
                    g.DrawLine(pen, 21.5f, 11.5f, 20.5f, 18.5f);

                    // Ruedas del carro (círculos rellenos)
                    g.FillEllipse(brush, 10f, 22f, 4.5f, 4.5f);
                    g.FillEllipse(brush, 22f, 22f, 4.5f, 4.5f);
                }
            }
            return bmp;
        }


        // Método para reescalar las imágenes sin que pierdan nitidez
        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            if (imagenOriginal == null) return null;

            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return nuevoBitmap;
        }

        // Asignación de iconos con los nombres exactos de Properties.Resources
        private void AsignarEstiloEIconos()
        {
                 BNuevaCompra.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);
                BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BVerDetalle.Image = EscalarIcono(Properties.Resources.boton_editar_blanco, 32, 32);
                BAnular.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
                BLimpiar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
        }
        private void ConfigurarRestriccionesTeclado()
        {
            TBNroComprobante.MaxLength = 20; 
            
            TBSubtotal.KeyPress += PermitirDecimales_KeyPress;
            TBIva.KeyPress += PermitirDecimales_KeyPress;

            TBTotalCompra.ReadOnly = true;
        }

        private void PermitirDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            char separador = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            // Permite teclas de control (BackSpace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Convierte punto a coma si la cultura lo requiere
            if (e.KeyChar == '.' || e.KeyChar == ',')
                e.KeyChar = separador;

            // Si es dígito, se acepta
            if (char.IsDigit(e.KeyChar))
                return;

            // Validación estricta del separador decimal:
            // 1. Solo se permite un separador decimal
            // 2. No se permite como primer carácter (ej: ",50" inválido)
            if (e.KeyChar == separador)
            {
                if (txt.Text.Contains(separador.ToString()) || txt.SelectionStart == 0)
                {
                    e.Handled = true;
                    return;
                }
                return;
            }

            // Cualquier otro carácter queda bloqueado
            e.Handled = true;
        }
        // =========================================================================
        // 1. CONFIGURACIÓN DEL DATETIMEPICKER PARA QUE INICIE EN BLANCO
        // =========================================================================
        private bool _fechaSeleccionada = false;

        private void ConfigurarFechaEmision()
        {
            // Al iniciar, se muestra en blanco
            ResetearFechaEmision();

            // Cuando el usuario interactúa con el calendario, se activa el formato de fecha normal
            DTPFechaEmision.DropDown += (s, e) => ActivarFechaEmision();
            DTPFechaEmision.ValueChanged += (s, e) => ActivarFechaEmision();
        }

        private void ResetearFechaEmision()
        {
            _fechaSeleccionada = false;
            DTPFechaEmision.Format = DateTimePickerFormat.Custom;
            DTPFechaEmision.CustomFormat = " "; // Se muestra visualmente vacío
        }

        private void ActivarFechaEmision()
        {
            if (!_fechaSeleccionada)
            {
                _fechaSeleccionada = true;
                DTPFechaEmision.Format = DateTimePickerFormat.Short;
                DTPFechaEmision.CustomFormat = null;
                DTPFechaEmision.Value = DateTime.Now;
            }
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

        private void ConfigurarCalculoTotalesEnVivo()
        {
            TBSubtotal.TextChanged += (s, e) => RecalcularTotal();
            TBIva.TextChanged += (s, e) => RecalcularTotal();
        }

        private void RecalcularTotal()
        {
            if (_calculandoTotales) return;

            decimal subtotal = ParsearDecimalSeguro(TBSubtotal.Text);
            decimal iva = ParsearDecimalSeguro(TBIva.Text);
            decimal total = subtotal + iva;

            _calculandoTotales = true;
            TBTotalCompra.Text = total.ToString("N2");
            _calculandoTotales = false;
        }

        private decimal ParsearDecimalSeguro(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0m;
            string limpio = texto.Trim().Replace("$", "").Trim();
            if (decimal.TryParse(limpio, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal res))
                return res;
            if (decimal.TryParse(limpio, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
                return res;
            return 0m;
        }

        private void CargarDesplegablesSimulados()
        {
            CBTipoComprobante.Items.Clear();
            CBTipoComprobante.Items.AddRange(new object[] { "Factura A", "Factura B", "Factura C", "Remito", "Nota de Crédito" });
            CBTipoComprobante.SelectedIndex = 0;

            CBFormaPago.Items.Clear();
            CBFormaPago.Items.AddRange(new object[] { "Efectivo", "Transferencia / Débito", "Cuenta Corriente (30 días)", "Cheque" });
            CBFormaPago.SelectedIndex = 0;

            string[] proveedores = { "Acindar S.A.", "Siderca Techint", "Distribuidora Metalúrgica S.R.L.", "Ferretería Industrial Mayorista" };

            CBProveedor.Items.Clear();
            CBProveedor.Items.AddRange(proveedores);
            CBProveedor.SelectedIndex = -1;

            CBFiltroProveedor.Items.Clear();
            CBFiltroProveedor.Items.AddRange(proveedores);
            CBFiltroProveedor.SelectedIndex = -1;
        }

        private void CargarHistorialComprasSimulado()
        {
            if (_dtCompras.Columns.Count == 0)
            {
                _dtCompras.Columns.Add("ColIdCompra", typeof(int));
                _dtCompras.Columns.Add("ColFecha", typeof(string));
                _dtCompras.Columns.Add("ColTipoComprobante", typeof(string));
                _dtCompras.Columns.Add("ColNroComprobante", typeof(string));
                _dtCompras.Columns.Add("ColProveedor", typeof(string));
                _dtCompras.Columns.Add("ColFormaPago", typeof(string));
                _dtCompras.Columns.Add("ColTotal", typeof(string));
                _dtCompras.Columns.Add("ColEstado", typeof(string));

                _dtCompras.Rows.Add(1, "05/09/2026", "Factura A", "0001-00045120", "Acindar S.A.", "Transferencia", "$ 450.200,00", "Recibida");
                _dtCompras.Rows.Add(2, "04/09/2026", "Factura A", "0002-00012890", "Distribuidora Metalúrgica S.R.L.", "Cuenta Corriente", "$ 185.000,00", "Recibida");
                _dtCompras.Rows.Add(3, "02/09/2026", "Remito", "0001-00000841", "Siderca Techint", "Efectivo", "$ 92.400,00", "Pendiente");
            }

            DGVCompras.AutoGenerateColumns = false;
            ColIdCompra.DataPropertyName = "ColIdCompra";
            ColFecha.DataPropertyName = "ColFecha";
            ColTipoComprobante.DataPropertyName = "ColTipoComprobante";
            ColNroComprobante.DataPropertyName = "ColNroComprobante";
            ColProveedor.DataPropertyName = "ColProveedor";
            ColFormaPago.DataPropertyName = "ColFormaPago";
            ColTotal.DataPropertyName = "ColTotal";
            ColEstado.DataPropertyName = "ColEstado";

            DGVCompras.DataSource = _dtCompras;
        }

        private void ConfigurarFiltrosDinamicos()
        {
            TBBuscar.TextChanged += (s, e) => AplicarFiltroGrilla();
            CBFiltroProveedor.SelectedIndexChanged += (s, e) => AplicarFiltroGrilla();
            BLimpiarFiltros.Click += (s, e) =>
            {
                TBBuscar.Clear();
                CBFiltroProveedor.SelectedIndex = -1;
                AplicarFiltroGrilla();
            };
        }
        private void AplicarFiltroGrilla()
        {
            if (_dtCompras == null || _dtCompras.DefaultView == null) return;

            string texto = TBBuscar.Text.Trim().Replace("'", "''");
            string filtro = "";

            if (!string.IsNullOrEmpty(texto))
            {
                filtro += $"(ColNroComprobante LIKE '%{texto}%' OR ColProveedor LIKE '%{texto}%')";
            }

            if (CBFiltroProveedor.SelectedIndex != -1 && !string.IsNullOrEmpty(CBFiltroProveedor.Text))
            {
                string prov = CBFiltroProveedor.Text.Replace("'", "''");
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"ColProveedor = '{prov}'";
            }

            _dtCompras.DefaultView.RowFilter = filtro;
        }

        private bool ValidarFormularioCompra(out string mensajeError)
        {
            mensajeError = string.Empty;

            if (CBProveedor.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar un Proveedor.";
                CBProveedor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBNroComprobante.Text) || TBNroComprobante.Text.Length < 6)
            {
                mensajeError = "Debe ingresar un número de comprobante válido (formato ####-########).";
                TBNroComprobante.Focus();
                return false;
            }

            decimal total = ParsearDecimalSeguro(TBTotalCompra.Text);
            if (total <= 0)
            {
                mensajeError = "El monto total de la factura debe ser mayor a cero.";
                TBSubtotal.Focus();
                return false;
            }

            return true;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioCompra(out string error))
            {
                MessageBox.Show(error, "Validación de Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _dtCompras.Rows.Add(
                _dtCompras.Rows.Count + 1,
                DTPFechaEmision.Value.ToString("dd/MM/yyyy"),
                CBTipoComprobante.Text,
                TBNroComprobante.Text.Trim(),
                CBProveedor.Text,
                CBFormaPago.Text,
                $"$ {TBTotalCompra.Text}",
                "Recibida"
            );

            MessageBox.Show("Comprobante registrado con éxito en la vista previa.", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private void BNuevaCompra_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            CBProveedor.Focus();
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void BAnular_Click(object sender, EventArgs e)
        {
            if (_idCompraSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una compra de la grilla para anular.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de anular el comprobante seleccionado?",
                "Anular Compra",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                foreach (DataRow fila in _dtCompras.Rows)
                {
                    if (Convert.ToInt32(fila["ColIdCompra"]) == _idCompraSeleccionada)
                    {
                        fila["ColEstado"] = "Anulada";
                        break;
                    }
                }
                LimpiarFormulario();
            }
        }

        private void BVerDetalle_Click(object sender, EventArgs e)
        {
            if (DGVCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra de la grilla para ver sus detalles.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Visualizando detalles del comprobante: {TBNroComprobante.Text}", "Detalle de Artículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DGVCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = DGVCompras.Rows[e.RowIndex];
            _idCompraSeleccionada = Convert.ToInt32(fila.Cells["ColIdCompra"].Value ?? 0);

            CBTipoComprobante.Text = fila.Cells["ColTipoComprobante"].Value?.ToString() ?? "";
            TBNroComprobante.Text = fila.Cells["ColNroComprobante"].Value?.ToString() ?? "";
            CBProveedor.Text = fila.Cells["ColProveedor"].Value?.ToString() ?? "";
            CBFormaPago.Text = fila.Cells["ColFormaPago"].Value?.ToString() ?? "";
            TBTotalCompra.Text = fila.Cells["ColTotal"].Value?.ToString()?.Replace("$", "").Trim() ?? "0,00";

            if (DateTime.TryParse(fila.Cells["ColFecha"].Value?.ToString(), out DateTime f))
            {
                _fechaSeleccionada = true;
                DTPFechaEmision.Format = DateTimePickerFormat.Short;
                DTPFechaEmision.CustomFormat = null;
                DTPFechaEmision.Value = f;
            }
            else
            {
                ResetearFechaEmision();
            }
        }

        private void LimpiarFormulario()
        {
            _idCompraSeleccionada = 0;
            CBProveedor.SelectedIndex = -1;
            CBTipoComprobante.SelectedIndex = -1;
            TBNroComprobante.Clear();

            // Campo de fecha en blanco
            ResetearFechaEmision();

            CBFormaPago.SelectedIndex = -1;
            TBSubtotal.Clear();
            TBIva.Clear();
            TBTotalCompra.Clear();
            ChBCompraRegistrada.Checked = true;

            // Deselección de grilla
            DGVCompras.ClearSelection();
            if (DGVCompras.CurrentCell != null)
                DGVCompras.CurrentCell = null;
        }
    }
}
