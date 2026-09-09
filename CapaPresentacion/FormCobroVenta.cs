using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormCobroVenta : Form
    {
        private DataTable _dtPendientes = new DataTable();
        private DataTable _dtDetalle = new DataTable();
        private decimal _totalActual = 0m;
        private int _idPedidoSeleccionado = 0;

        public FormCobroVenta()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private void FormCobroVenta_Load(object sender, EventArgs e)
        {
            AsignarIconoTitulo();
            CargarDesplegables();
            CargarPedidosPendientesSimulados();
            LimpiarFormularioCobro();
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
                    // Billetes / Terminal de caja
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
                // Reutiliza los íconos blancos oficiales de recursos a 32x32 px
                BConfirmarCobro.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BAnularPedido.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch
            {
                // Fallback silencioso si no encuentra el recurso
            }
        }

        private void InicializarComportamiento()
        {
            // Restricción: solo números y coma en "Paga con"
            TBPagaCon.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
                    e.Handled = true;
            };

            // Cálculo reactivo del vuelto
            TBPagaCon.TextChanged += (s, e) =>
            {
                if (decimal.TryParse(TBPagaCon.Text.Trim(), out decimal pago))
                {
                    decimal vuelto = pago - _totalActual;
                    if (vuelto >= 0)
                    {
                        LValorVuelto.Text = vuelto.ToString("C2");
                        LValorVuelto.ForeColor = Color.FromArgb(39, 174, 96); // Verde
                    }
                    else
                    {
                        LValorVuelto.Text = "Monto insuficiente";
                        LValorVuelto.ForeColor = Color.FromArgb(192, 57, 43); // Rojo
                    }
                }
                else
                {
                    LValorVuelto.Text = "$ 0,00";
                    LValorVuelto.ForeColor = Color.FromArgb(39, 174, 96);
                }
            };
        }

        private void CargarDesplegables()
        {
            CBMedioPago.Items.Clear();
            CBMedioPago.Items.AddRange(new object[] { "Efectivo", "Transferencia / QR", "Tarjeta Débito", "Tarjeta Crédito", "Cuenta Corriente" });
            CBMedioPago.SelectedIndex = 0;

            CBComprobante.Items.Clear();
            CBComprobante.Items.AddRange(new object[] { "Ticket / Recibo X", "Factura B (Consumidor Final)", "Factura A (Responsable Inscripto)" });
            CBComprobante.SelectedIndex = 0;
        }

        private void CargarPedidosPendientesSimulados()
        {
            if (_dtPendientes.Columns.Count == 0)
            {
                _dtPendientes.Columns.Add("ColIdPedido", typeof(int));
                _dtPendientes.Columns.Add("ColNroPedido", typeof(string));
                _dtPendientes.Columns.Add("ColHora", typeof(string));
                _dtPendientes.Columns.Add("ColVendedor", typeof(string));
                _dtPendientes.Columns.Add("ColCliente", typeof(string));
                _dtPendientes.Columns.Add("ColTotalPedido", typeof(decimal));

                _dtPendientes.Rows.Add(101, "PV-260908-114", "11:42", "Gastón Vendedor", "Herrería San José", 38500m);
                _dtPendientes.Rows.Add(102, "PV-260908-115", "11:58", "Gastón Vendedor", "Consumidor Final", 14500m);
                _dtPendientes.Rows.Add(103, "PV-260908-116", "12:01", "Gastón Vendedor", "Metalúrgica Del Nordeste", 72400m);
            }

            DGVPendientes.AutoGenerateColumns = false;
            ColIdPedido.DataPropertyName = "ColIdPedido";
            ColNroPedido.DataPropertyName = "ColNroPedido";
            ColHora.DataPropertyName = "ColHora";
            ColVendedor.DataPropertyName = "ColVendedor";
            ColCliente.DataPropertyName = "ColCliente";
            ColTotalPedido.DataPropertyName = "ColTotalPedido";

            ColTotalPedido.DefaultCellStyle.Format = "C2";
            DGVPendientes.DataSource = _dtPendientes;

            ConfigurarDetalle();
        }

        private void ConfigurarDetalle()
        {
            if (_dtDetalle.Columns.Count == 0)
            {
                _dtDetalle.Columns.Add("ColDetCodigo", typeof(string));
                _dtDetalle.Columns.Add("ColDetDesc", typeof(string));
                _dtDetalle.Columns.Add("ColDetCant", typeof(int));
                _dtDetalle.Columns.Add("ColDetPrecio", typeof(decimal));
                _dtDetalle.Columns.Add("ColDetSubtotal", typeof(decimal));
            }

            DGVDetalle.AutoGenerateColumns = false;
            ColDetCodigo.DataPropertyName = "ColDetCodigo";
            ColDetDesc.DataPropertyName = "ColDetDesc";
            ColDetCant.DataPropertyName = "ColDetCant";
            ColDetPrecio.DataPropertyName = "ColDetPrecio";
            ColDetSubtotal.DataPropertyName = "ColDetSubtotal";

            ColDetPrecio.DefaultCellStyle.Format = "C2";
            ColDetSubtotal.DefaultCellStyle.Format = "C2";
            DGVDetalle.DataSource = _dtDetalle;
        }

        private void DGVPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = DGVPendientes.Rows[e.RowIndex];
            _idPedidoSeleccionado = Convert.ToInt32(fila.Cells["ColIdPedido"].Value);
            _totalActual = Convert.ToDecimal(fila.Cells["ColTotalPedido"].Value);

            LTotalMonto.Text = _totalActual.ToString("C2");

            // Cargar renglones simulados del pedido seleccionado
            _dtDetalle.Rows.Clear();
            if (_idPedidoSeleccionado == 101)
            {
                _dtDetalle.Rows.Add("CH-C20", "Chapa Negra Lisa C20 (1x2m)", 1, 38500m, 38500m);
            }
            else if (_idPedidoSeleccionado == 102)
            {
                _dtDetalle.Rows.Add("HI-014", "Hierro Ángulo 1 1/2 x 1/8", 1, 14500m, 14500m);
            }
            else
            {
                _dtDetalle.Rows.Add("TU-4040", "Tubo Estructural 40x40x1.6mm (6m)", 2, 24800m, 49600m);
                _dtDetalle.Rows.Add("EL-6013", "Electrodo Punta Azul 2.5mm (Kg)", 2, 11400m, 22800m);
            }

            TBPagaCon.Text = _totalActual.ToString("0.00");
        }

        private void BConfirmarCobro_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un pedido pendiente de la lista para cobrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(TBPagaCon.Text.Trim(), out decimal pago) && pago < _totalActual && CBMedioPago.Text == "Efectivo")
            {
                MessageBox.Show("El monto abonado no puede ser inferior al total de la compra.", "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBPagaCon.Focus();
                return;
            }

            string compEmitido = $"{CBComprobante.Text.Split(' ')[0]} 0001-{new Random().Next(100000, 999999)}";

            DialogResult res = MessageBox.Show(
                $"¿Confirmar cobro y registrar en Caja?\n\nComprobante: {compEmitido}\nTotal: {_totalActual:C2}\nMedio: {CBMedioPago.Text}",
                "Cobro Exitoso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.Yes)
            {
                // Quitar de la lista de pendientes
                DataRow filaBorrar = null;
                foreach (DataRow row in _dtPendientes.Rows)
                {
                    if (Convert.ToInt32(row["ColIdPedido"]) == _idPedidoSeleccionado)
                    {
                        filaBorrar = row;
                        break;
                    }
                }
                if (filaBorrar != null) _dtPendientes.Rows.Remove(filaBorrar);

                MessageBox.Show($"Comprobante #{compEmitido} emitido con éxito. Registrado en Movimientos de Caja.", "Venta Facturada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioCobro();
            }
        }

        private void BAnularPedido_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un pedido para anular.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult res = MessageBox.Show("¿Está seguro de descartar este pedido de PreVenta? Los insumos volverán a estar disponibles.", "Anular Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                DataRow filaBorrar = null;
                foreach (DataRow row in _dtPendientes.Rows)
                {
                    if (Convert.ToInt32(row["ColIdPedido"]) == _idPedidoSeleccionado)
                    {
                        filaBorrar = row;
                        break;
                    }
                }
                if (filaBorrar != null) _dtPendientes.Rows.Remove(filaBorrar);

                LimpiarFormularioCobro();
            }
        }
        private void LimpiarFormularioCobro()
        {
            _idPedidoSeleccionado = 0;
            _totalActual = 0m;
            _dtDetalle.Rows.Clear();
            LTotalMonto.Text = "$ 0,00";
            TBPagaCon.Clear();
            LValorVuelto.Text = "$ 0,00";
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
