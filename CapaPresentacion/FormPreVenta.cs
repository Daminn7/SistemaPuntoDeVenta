using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaPresentacion.FormPrincipal;

namespace CapaPresentacion
{
    public partial class FormPreVenta : Form
    {
        // Estructura interna para el catálogo de insumos
        private class ArticuloCatalogo
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
            public int Stock { get; set; }
            public decimal PrecioMinorista { get; set; }
            public decimal PrecioMayorista { get; set; }
        }

        private List<ArticuloCatalogo> _catalogoInsumos = new List<ArticuloCatalogo>();
        private DataTable _dtDetalle = new DataTable();

        public FormPreVenta()
        {
            InitializeComponent();
            InicializarCatalogoSimulado();
            ConfigurarBuscadorReactivo();
        }

        private void FormPreVenta_Load(object sender, EventArgs e)
        {
            AsignarIconoTitulo();
            CargarClientesSimulados();
            ConfigurarEstructuraDetalle();
            LimpiarFormulario();
        }

        // =========================================================================
        // 1. ÍCONO VECTORIAL DE PREVENTA
        // =========================================================================
        private Image DibujarIconoPreVenta(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Carro de compras simplificado
                    g.DrawLines(pen, new[] {
                        new Point(3, 7), new Point(8, 7), new Point(12, 21),
                        new Point(24, 21), new Point(27, 11), new Point(9, 11)
                    });
                    g.FillEllipse(brush, 12, 23, 3.5f, 3.5f);
                    g.FillEllipse(brush, 22, 23, 3.5f, 3.5f);
                }
            }
            return bmp;
        }

        private void AsignarIconoTitulo()
        {
            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = DibujarIconoPreVenta(Color.FromArgb(212, 131, 53));
        }

        // =========================================================================
        // 2. CATÁLOGO EN MEMORIA Y AUTOCOMPLETADO
        // =========================================================================
        private void InicializarCatalogoSimulado()
        {
            _catalogoInsumos = new List<ArticuloCatalogo>
            {
                new ArticuloCatalogo { Id = 1, Codigo = "HI-014", Descripcion = "Hierro Ángulo 1 1/2 x 1/8", Stock = 18, PrecioMinorista = 14500m, PrecioMayorista = 12900m },
                new ArticuloCatalogo { Id = 2, Codigo = "EL-6013", Descripcion = "Electrodo Punta Azul 2.5mm (Kg)", Stock = 45, PrecioMinorista = 9200m, PrecioMayorista = 8100m },
                new ArticuloCatalogo { Id = 3, Codigo = "CH-C20", Descripcion = "Chapa Negra Lisa C20 (1x2m)", Stock = 12, PrecioMinorista = 38500m, PrecioMayorista = 34900m },
                new ArticuloCatalogo { Id = 4, Codigo = "DI-CUT", Descripcion = "Disco Corte Acero 115x1.0mm", Stock = 120, PrecioMinorista = 1850m, PrecioMayorista = 1500m },
                new ArticuloCatalogo { Id = 5, Codigo = "TU-4040", Descripcion = "Tubo Estructural 40x40x1.6mm (6m)", Stock = 24, PrecioMinorista = 24800m, PrecioMayorista = 22100m },
                new ArticuloCatalogo { Id = 6, Codigo = "PL-114", Descripcion = "Planchuela 1 1/4 x 3/16 (6m)", Stock = 30, PrecioMinorista = 16900m, PrecioMayorista = 15200m }
            };
        }

        private void ConfigurarBuscadorReactivo()
        {
            AutoCompleteStringCollection autocompletar = new AutoCompleteStringCollection();
            foreach (var art in _catalogoInsumos)
            {
                autocompletar.Add($"{art.Codigo} - {art.Descripcion}");
            }

            TBBuscarArticulo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TBBuscarArticulo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TBBuscarArticulo.AutoCompleteCustomSource = autocompletar;

            // Enter directo agrega el ítem
            TBBuscarArticulo.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Evita el beep de Windows
                    BAgregarItem.PerformClick();
                }
            };
        }

        private void CargarClientesSimulados()
        {
            CBClientes.Items.Clear();
            CBClientes.Items.AddRange(new object[] {
                "Consumidor Final",
                "Herrería San José (CUIT 20-35412890-4)",
                "Metalúrgica Del Nordeste (CUIT 30-71289012-8)",
                "Carlos Romero (CUIT 27-28456123-2)"
            });
            CBClientes.SelectedIndex = 0;
        }

        private void ConfigurarEstructuraDetalle()
        {
            if (_dtDetalle.Columns.Count == 0)
            {
                _dtDetalle.Columns.Add("ColIdProducto", typeof(int));
                _dtDetalle.Columns.Add("ColCodigo", typeof(string));
                _dtDetalle.Columns.Add("ColDescripcion", typeof(string));
                _dtDetalle.Columns.Add("ColStockDisp", typeof(int));
                _dtDetalle.Columns.Add("ColCantidad", typeof(int));
                _dtDetalle.Columns.Add("ColPrecioUnit", typeof(decimal));
                _dtDetalle.Columns.Add("ColSubtotal", typeof(decimal));
            }

            DGVDetalle.AutoGenerateColumns = false;
            ColIdProducto.DataPropertyName = "ColIdProducto";
            ColCodigo.DataPropertyName = "ColCodigo";
            ColDescripcion.DataPropertyName = "ColDescripcion";
            ColStockDisp.DataPropertyName = "ColStockDisp";
            ColCantidad.DataPropertyName = "ColCantidad";
            ColPrecioUnit.DataPropertyName = "ColPrecioUnit";
            ColSubtotal.DataPropertyName = "ColSubtotal";

            // Formato de moneda para columnas de precio
            ColPrecioUnit.DefaultCellStyle.Format = "C2";
            ColSubtotal.DefaultCellStyle.Format = "C2";

            DGVDetalle.DataSource = _dtDetalle;
        }

        // =========================================================================
        // 3. ADICIÓN Y VALIDACIÓN DE ÍTEMS
        // =========================================================================
        private void BAgregarItem_Click(object sender, EventArgs e)
        {
            string textoBusqueda = TBBuscarArticulo.Text.Trim();
            if (string.IsNullOrEmpty(textoBusqueda))
            {
                MessageBox.Show("Ingrese el código o nombre del insumo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBBuscarArticulo.Focus();
                return;
            }

            // Buscar insumo por coincidencia de código o texto
            ArticuloCatalogo insumo = _catalogoInsumos.FirstOrDefault(a =>
                textoBusqueda.StartsWith(a.Codigo, StringComparison.OrdinalIgnoreCase) ||
                a.Descripcion.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                a.Codigo.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase));

            if (insumo == null)
            {
                MessageBox.Show("No se encontró ningún artículo que coincida con la búsqueda.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TBBuscarArticulo.Focus();
                return;
            }

            int cantidadSolicitada = (int)NUDCantidad.Value;

            // Verificar si el producto ya está en la grilla para sumar cantidades
            DataRow filaExistente = null;
            foreach (DataRow row in _dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["ColIdProducto"]) == insumo.Id)
                {
                    filaExistente = row;
                    break;
                }
            }

            int cantidadActualEnGrilla = filaExistente != null ? Convert.ToInt32(filaExistente["ColCantidad"]) : 0;
            int cantidadTotal = cantidadActualEnGrilla + cantidadSolicitada;

            // Validación estricta de stock
            if (cantidadTotal > insumo.Stock)
            {
                MessageBox.Show($"Stock insuficiente. Solo hay {insumo.Stock} unidades disponibles de este artículo en almacén.", "Stock Crítico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precioAplicado = RBPremioMayorista.Checked ? insumo.PrecioMayorista : insumo.PrecioMinorista;

            if (filaExistente != null)
            {
                filaExistente["ColCantidad"] = cantidadTotal;
                filaExistente["ColSubtotal"] = cantidadTotal * precioAplicado;
            }
            else
            {
                decimal subtotal = cantidadSolicitada * precioAplicado;
                _dtDetalle.Rows.Add(insumo.Id, insumo.Codigo, insumo.Descripcion, insumo.Stock, cantidadSolicitada, precioAplicado, subtotal);
            }

            TBBuscarArticulo.Clear();
            NUDCantidad.Value = 1;
            TBBuscarArticulo.Focus();

            ActualizarTotales();
        }

        private void DGVDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGVDetalle.Columns["ColEliminar"].Index)
            {
                _dtDetalle.Rows.RemoveAt(e.RowIndex);
                ActualizarTotales();
            }
        }

        // =========================================================================
        // 4. CAMBIO DE LISTA DE PRECIOS Y TOTALIZADORES
        // =========================================================================
        private void TipoPrecio_CheckedChanged(object sender, EventArgs e)
        {
            // Recalcula los precios unitarios de todos los renglones cargados
            foreach (DataRow row in _dtDetalle.Rows)
            {
                int idArt = Convert.ToInt32(row["ColIdProducto"]);
                var art = _catalogoInsumos.FirstOrDefault(a => a.Id == idArt);
                if (art != null)
                {
                    decimal nuevoPrecio = RBPremioMayorista.Checked ? art.PrecioMayorista : art.PrecioMinorista;
                    int cant = Convert.ToInt32(row["ColCantidad"]);
                    row["ColPrecioUnit"] = nuevoPrecio;
                    row["ColSubtotal"] = cant * nuevoPrecio;
                }
            }

            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            int totalItems = 0;
            decimal totalPagar = 0m;

            foreach (DataRow row in _dtDetalle.Rows)
            {
                totalItems += Convert.ToInt32(row["ColCantidad"]);
                totalPagar += Convert.ToDecimal(row["ColSubtotal"]);
            }

            LItemsCantidad.Text = $"{totalItems} ítems";
            LSubtotalMonto.Text = totalPagar.ToString("C2");
            LTotalMonto.Text = totalPagar.ToString("C2");

            DGVDetalle.ClearSelection();
            if (DGVDetalle.CurrentCell != null)
                DGVDetalle.CurrentCell = null;
        }

        // =========================================================================
        // 5. ACCIONES DE PEDIDO Y PRESUPUESTO
        // =========================================================================
        private void BEnviarACaja_Click(object sender, EventArgs e)
        {
            if (_dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe cargar al menos un artículo para enviar el pedido a Caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nroTicket = $"PV-{DateTime.Now:yyMMdd}-{new Random().Next(100, 999)}";

            DialogResult res = MessageBox.Show(
                $"¿Confirmar envío a Caja?\n\nN° Pedido: {nroTicket}\nCliente: {CBClientes.Text}\nTotal: {LTotalMonto.Text}",
                "Enviar a Cobro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.Yes)
            {
                MessageBox.Show($"Pedido #{nroTicket} transmitido a Caja de forma exitosa.", "PreVenta Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
        }

        private void BGuardarPresupuesto_Click(object sender, EventArgs e)
        {
            if (_dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Cargue artículos antes de generar el presupuesto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = $"Presupuesto_{CBClientes.Text.Replace(" ", "_")}";
                pd.PrintPage += ImprimirPresupuesto_PrintPage;

                PrintPreviewDialog prev = new PrintPreviewDialog
                {
                    Document = pd,
                    Width = 850,
                    Height = 650,
                    StartPosition = FormStartPosition.CenterScreen
                };
                prev.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar presupuesto:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirPresupuesto_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = 50;
            float y = 50;

            using (Font fTitulo = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 9.5f))
            using (Font fHeader = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Font fRow = new Font("Segoe UI", 9))
            using (Brush bOcre = new SolidBrush(Color.FromArgb(212, 131, 53)))
            using (Brush bGrafito = new SolidBrush(Color.FromArgb(38, 40, 44)))
            using (Brush bGris = new SolidBrush(Color.Gray))
            using (Pen penLinea = new Pen(Color.FromArgb(210, 215, 220), 1))
            {
                g.DrawString("HIERRO Y FORJA", fTitulo, bOcre, x, y);
                g.DrawString("PRESUPUESTO COMERCIAL VALIDEZ: 15 DÍAS", fSub, bGrafito, x, y + 28);
                g.DrawString($"Cliente: {CBClientes.Text}  |  Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}  |  Operador: {SesionUsuario.Nombre}", fSub, bGris, x, y + 48);

                y += 75;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 15;

                // Cabeceras
                g.DrawString("Cód.", fHeader, bOcre, x, y);
                g.DrawString("Descripción", fHeader, bOcre, x + 80, y);
                g.DrawString("Cant.", fHeader, bOcre, x + 400, y);
                g.DrawString("Precio Unit.", fHeader, bOcre, x + 480, y);
                g.DrawString("Subtotal", fHeader, bOcre, x + 600, y);

                y += 22;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 10;

                foreach (DataRow row in _dtDetalle.Rows)
                {
                    g.DrawString(row["ColCodigo"].ToString(), fRow, bGrafito, x, y);
                    g.DrawString(row["ColDescripcion"].ToString(), fRow, bGrafito, x + 80, y);
                    g.DrawString(row["ColCantidad"].ToString(), fRow, bGrafito, x + 400, y);
                    g.DrawString(Convert.ToDecimal(row["ColPrecioUnit"]).ToString("C2"), fRow, bGrafito, x + 480, y);
                    g.DrawString(Convert.ToDecimal(row["ColSubtotal"]).ToString("C2"), fRow, bGrafito, x + 600, y);

                    y += 24;
                }

                y += 25;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 12;

                g.DrawString($"TOTAL PRESUPUESTADO: {LTotalMonto.Text}", fTitulo, bOcre, x + 350, y);
            }
        }

        private void BCancelarVenta_Click(object sender, EventArgs e)
        {
            if (_dtDetalle.Rows.Count > 0)
            {
                DialogResult res = MessageBox.Show("¿Desea limpiar todos los ítems cargados?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    LimpiarFormulario();
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            _dtDetalle.Rows.Clear();
            CBClientes.SelectedIndex = 0;
            TBBuscarArticulo.Clear();
            NUDCantidad.Value = 1;
            RBPremioMinorista.Checked = true;
            ActualizarTotales();
        }
    }
}
