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
        private ArticuloCatalogo _insumoSeleccionado = null; // se declara a nivel de clase 
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
        // Ícono vectorial de preventa
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
        // Catálogo en memoria y autocompletado, para visualizar funcionalidad
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

            // 1. Enter en la caja de texto: selecciona el insumo y pasa el foco a la cantidad
            TBBuscarArticulo.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;

                    string texto = TBBuscarArticulo.Text.Trim();
                    if (string.IsNullOrWhiteSpace(texto)) return;

                    // Busca y guarda en la variable de clase
                    _insumoSeleccionado = _catalogoInsumos.FirstOrDefault(a =>
                        texto.StartsWith(a.Codigo, StringComparison.OrdinalIgnoreCase) ||
                        a.Descripcion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        a.Codigo.Equals(texto, StringComparison.OrdinalIgnoreCase));

                    if (_insumoSeleccionado == null)
                    {
                        MessageBox.Show("No se encontró ningún artículo que coincida con la búsqueda.",
                                        "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TBBuscarArticulo.Focus();
                        return;
                    }

                    // Calculamos cuánto ya se cargó de este ítem en la grilla
                    int yaEnGrilla = 0;
                    foreach (DataRow row in _dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["ColIdProducto"]) == _insumoSeleccionado.Id)
                        {
                            yaEnGrilla = Convert.ToInt32(row["ColCantidad"]);
                            break;
                        }
                    }

                    int stockDisponible = _insumoSeleccionado.Stock - yaEnGrilla;

                    if (stockDisponible <= 0)
                    {
                        MessageBox.Show($"Sin stock disponible. Ya se agregaron todas las unidades disponibles ({_insumoSeleccionado.Stock}) de '{_insumoSeleccionado.Descripcion}' a la venta.",
                                        "Stock Agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _insumoSeleccionado = null;
                        TBBuscarArticulo.Focus();
                        return;
                    }

                    // Limitamos el control numérico al stock real disponible
                    NUDCantidad.Minimum = 1;
                    NUDCantidad.Maximum = stockDisponible;
                    NUDCantidad.Value = 1;

                    NUDCantidad.Focus();
                    NUDCantidad.Select(0, NUDCantidad.Text.Length);
                }
            };

            // 2. Al dar Enter en el NumericUpDown de cantidad: agrega el ítem
            NUDCantidad.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BAgregarItem.PerformClick();
                }
            };
        }
        private ArticuloCatalogo ObtenerArticuloPorBusqueda(string texto)
        {
            return _catalogoInsumos.FirstOrDefault(a =>
                texto.StartsWith(a.Codigo, StringComparison.OrdinalIgnoreCase) ||
                a.Descripcion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 ||
                a.Codigo.Equals(texto, StringComparison.OrdinalIgnoreCase));
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
        // Adición y validación de ítems
        private void BAgregarItem_Click(object sender, EventArgs e)
        {
            // Si el usuario no presionó Enter en el buscador y dio clic directo al botón:
            if (_insumoSeleccionado == null)
            {
                string textoBusqueda = TBBuscarArticulo.Text.Trim();
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    MessageBox.Show("Ingrese el código o nombre del insumo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBBuscarArticulo.Focus();
                    return;
                }

                _insumoSeleccionado = _catalogoInsumos.FirstOrDefault(a =>
                    textoBusqueda.StartsWith(a.Codigo, StringComparison.OrdinalIgnoreCase) ||
                    a.Descripcion.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    a.Codigo.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase));

                if (_insumoSeleccionado == null)
                {
                    MessageBox.Show("No se encontró ningún artículo que coincida con la búsqueda.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TBBuscarArticulo.Focus();
                    return;
                }
            }

            int cantidadSolicitada = (int)NUDCantidad.Value;

            // Verificar si el producto ya está en la grilla para sumar cantidades
            DataRow filaExistente = null;
            foreach (DataRow row in _dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["ColIdProducto"]) == _insumoSeleccionado.Id)
                {
                    filaExistente = row;
                    break;
                }
            }

            int cantidadActualEnGrilla = filaExistente != null ? Convert.ToInt32(filaExistente["ColCantidad"]) : 0;
            int cantidadTotal = cantidadActualEnGrilla + cantidadSolicitada;

            // Validación de seguridad de stock
            if (cantidadTotal > _insumoSeleccionado.Stock)
            {
                MessageBox.Show($"Stock insuficiente. Solo hay {_insumoSeleccionado.Stock} unidades en almacén.",
                                "Stock Crítico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precioAplicado = RBPremioMayorista.Checked ? _insumoSeleccionado.PrecioMayorista : _insumoSeleccionado.PrecioMinorista;

            if (filaExistente != null)
            {
                filaExistente["ColCantidad"] = cantidadTotal;
                filaExistente["ColSubtotal"] = cantidadTotal * precioAplicado;
            }
            else
            {
                decimal subtotal = cantidadSolicitada * precioAplicado;
                _dtDetalle.Rows.Add(_insumoSeleccionado.Id, _insumoSeleccionado.Codigo, _insumoSeleccionado.Descripcion, _insumoSeleccionado.Stock, cantidadSolicitada, precioAplicado, subtotal);
            }

            // Resetear formulario para el siguiente ítem
            _insumoSeleccionado = null;
            TBBuscarArticulo.Clear();
            NUDCantidad.Maximum = 10000; // Restaurar tope genérico temporal
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
        // Cambio de lista de precios y totalizadores
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
        // Acciones de pedido y presupuesto
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
            // 1. Validación de renglones cargados
            if (_dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Cargue artículos antes de generar el presupuesto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Guardamos el presupuesto en la lista en memoria para poder recuperarlo luego
                string nroPresupuestoNuevo = $"PRE-{DateTime.Now:yyMMdd}-{new Random().Next(10, 99)}";
                var nuevoPresupuesto = new PresupuestoSimulado
                {
                    NroPresupuesto = nroPresupuestoNuevo,
                    FechaEmision = DateTime.Now,
                    Cliente = CBClientes.Text,
                    EsMayorista = RBPremioMayorista.Checked
                };

                foreach (DataRow row in _dtDetalle.Rows)
                {
                    nuevoPresupuesto.Items.Add(new ItemPresupuesto
                    {
                        IdProducto = Convert.ToInt32(row["ColIdProducto"]),
                        Codigo = row["ColCodigo"].ToString(),
                        Descripcion = row["ColDescripcion"].ToString(),
                        Cantidad = Convert.ToInt32(row["ColCantidad"]),
                        PrecioUnitario = Convert.ToDecimal(row["ColPrecioUnit"])
                    });
                }

                _presupuestosGuardados.Add(nuevoPresupuesto);

                // 3. Impresión / Vista Previa 
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

                MessageBox.Show($"Presupuesto #{nroPresupuestoNuevo} registrado correctamente con validez por 7 días.",
                    "Presupuesto Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar presupuesto:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _insumoSeleccionado = null;
            _dtDetalle.Rows.Clear();
            CBClientes.SelectedIndex = 0;
            TBBuscarArticulo.Clear();
            NUDCantidad.Maximum = 10000;
            NUDCantidad.Value = 1;
            RBPremioMinorista.Checked = true;
            ActualizarTotales();
        }
        // =========================================================================
        // 1. MODELOS DE PRESUPUESTO EN MEMORIA (DENTRO DE LA CLASE FormPreVenta)
        // =========================================================================
        private class ItemPresupuesto
        {
            public int IdProducto { get; set; }
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
        }

        private class PresupuestoSimulado
        {
            public string NroPresupuesto { get; set; }
            public DateTime FechaEmision { get; set; }
            public string Cliente { get; set; }
            public bool EsMayorista { get; set; }
            public List<ItemPresupuesto> Items { get; set; } = new List<ItemPresupuesto>();
        }

        private List<PresupuestoSimulado> _presupuestosGuardados = new List<PresupuestoSimulado>();

        // =========================================================================
        // 2. EN FormPreVenta_Load(): INICIALIZAR PRESUPUESTOS DE PRUEBA
        // =========================================================================
        // Agrega esta llamada dentro de FormPreVenta_Load:
        // CargarPresupuestosSimulados();

        private void CargarPresupuestosSimulados()
        {
            _presupuestosGuardados = new List<PresupuestoSimulado>
    {
        // Presupuesto Vigente (Emitido hace 3 días)
        new PresupuestoSimulado
        {
            NroPresupuesto = "PRE-260919-01",
            FechaEmision = DateTime.Now.AddDays(-3),
            Cliente = "Herrería San José (CUIT 20-35412890-4)",
            EsMayorista = true,
            Items = new List<ItemPresupuesto>
            {
                new ItemPresupuesto { IdProducto = 1, Codigo = "HI-014", Descripcion = "Hierro Ángulo 1 1/2 x 1/8", Cantidad = 4, PrecioUnitario = 12900m },
                new ItemPresupuesto { IdProducto = 4, Codigo = "DI-CUT", Descripcion = "Disco Corte Acero 115x1.0mm", Cantidad = 10, PrecioUnitario = 1500m }
            }
        },
        // Presupuesto Vencido (Emitido hace 10 días -> RECHAZADO POR REGLA > 7 DÍAS)
        new PresupuestoSimulado
        {
            NroPresupuesto = "PRE-260912-88",
            FechaEmision = DateTime.Now.AddDays(-10),
            Cliente = "Metalúrgica Del Nordeste (CUIT 30-71289012-8)",
            EsMayorista = true,
            Items = new List<ItemPresupuesto>
            {
                new ItemPresupuesto { IdProducto = 5, Codigo = "TU-4040", Descripcion = "Tubo Estructural 40x40x1.6mm (6m)", Cantidad = 6, PrecioUnitario = 22100m }
            }
        }
    };
        }

        // =========================================================================
        // 3. DIÁLOGO DE SELECCIÓN Y VALIDACIÓN DE LOS 7 DÍAS
        // =========================================================================
        private void BCargarPresupuesto_Click(object sender, EventArgs e)
        {
            if (_presupuestosGuardados == null || _presupuestosGuardados.Count == 0)
            {
                MessageBox.Show("No hay presupuestos registrados para cargar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Modal de selección de presupuestos
            using (Form selector = new Form())
            {
                selector.Text = "Seleccionar Presupuesto para Pasar a Caja";
                selector.Size = new Size(680, 360);
                selector.StartPosition = FormStartPosition.CenterParent;
                selector.FormBorderStyle = FormBorderStyle.FixedDialog;
                selector.MaximizeBox = false;
                selector.MinimizeBox = false;

                Label lbl = new Label
                {
                    Text = "Presupuestos registrados (Validez máxima permitida: 7 días corridos):",
                    Dock = DockStyle.Top,
                    Height = 30,
                    Padding = new Padding(10, 8, 0, 0),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    MultiSelect = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    BackgroundColor = Color.White,
                    RowHeadersVisible = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                dgv.Columns.Add("Nro", "N° Presupuesto");
                dgv.Columns.Add("Fecha", "Emisión");
                dgv.Columns.Add("Cliente", "Cliente");
                dgv.Columns.Add("Antiguedad", "Antigüedad");
                dgv.Columns.Add("Estado", "Estado");

                foreach (var p in _presupuestosGuardados)
                {
                    int dias = (int)(DateTime.Now - p.FechaEmision).TotalDays;
                    string estado = dias <= 7 ? "Válido" : "VENCIDO (+7 días)";

                    int idx = dgv.Rows.Add(p.NroPresupuesto, p.FechaEmision.ToString("dd/MM/yyyy HH:mm"), p.Cliente, $"{dias} días", estado);

                    if (dias > 7)
                    {
                        dgv.Rows[idx].DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                    }
                    else
                    {
                        dgv.Rows[idx].DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                    }
                }

                Panel pBotones = new Panel { Dock = DockStyle.Bottom, Height = 48 };
                Button btnCargar = new Button
                {
                    Text = "Importar a PreVenta",
                    DialogResult = DialogResult.OK,
                    BackColor = Color.FromArgb(39, 174, 96),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(160, 34),
                    Location = new Point(340, 7)
                };
                Button btnCancelar = new Button
                {
                    Text = "Cancelar",
                    DialogResult = DialogResult.Cancel,
                    Size = new Size(100, 34),
                    Location = new Point(510, 7)
                };

                pBotones.Controls.Add(btnCargar);
                pBotones.Controls.Add(btnCancelar);

                selector.Controls.Add(dgv);
                selector.Controls.Add(pBotones);
                selector.Controls.Add(lbl);

                if (selector.ShowDialog(this) == DialogResult.OK && dgv.CurrentRow != null)
                {
                    string nroPresupuesto = dgv.CurrentRow.Cells["Nro"].Value.ToString();
                    var presupuesto = _presupuestosGuardados.FirstOrDefault(p => p.NroPresupuesto == nroPresupuesto);

                    if (presupuesto == null) return;

                    // RESTRICCIÓN DE 7 DÍAS
                    double diasTranscurridos = (DateTime.Now - presupuesto.FechaEmision).TotalDays;
                    if (diasTranscurridos > 7)
                    {
                        MessageBox.Show(
                            $"El presupuesto #{presupuesto.NroPresupuesto} caducó.\n\n" +
                            $"Fecha de emisión: {presupuesto.FechaEmision:dd/MM/yyyy}\n" +
                            $"Antigüedad: {(int)diasTranscurridos} días.\n\n" +
                            "La validez máxima para congelar precios y pasar a cobro es de 7 días. Debe realizarse una nueva cotización.",
                            "Presupuesto Vencido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                        return;
                    }

                    // Advertir si hay ítems cargados
                    if (_dtDetalle.Rows.Count > 0)
                    {
                        var confirm = MessageBox.Show(
                            "Hay artículos cargados en la grilla actual. ¿Desea reemplazarlos con los ítems del presupuesto?",
                            "Reemplazar Ítems",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirm != DialogResult.Yes) return;
                    }

                    // Cargar en la pantalla de PreVenta
                    ImportarPresupuestoAFormulario(presupuesto);
                }
            }
        }

        private void ImportarPresupuestoAFormulario(PresupuestoSimulado presupuesto)
        {
            _dtDetalle.Rows.Clear();

            // Establecer Cliente
            int idxCliente = CBClientes.FindStringExact(presupuesto.Cliente);
            if (idxCliente >= 0)
                CBClientes.SelectedIndex = idxCliente;
            else
                CBClientes.Text = presupuesto.Cliente;

            // Establecer Lista de Precios
            if (presupuesto.EsMayorista)
                RBPremioMayorista.Checked = true;
            else
                RBPremioMinorista.Checked = true;

            // Poblar Grilla validando stock de cada producto
            foreach (var item in presupuesto.Items)
            {
                var art = _catalogoInsumos.FirstOrDefault(a => a.Id == item.IdProducto);
                int stockDisp = art != null ? art.Stock : item.Cantidad;

                decimal subtotal = item.Cantidad * item.PrecioUnitario;
                _dtDetalle.Rows.Add(
                    item.IdProducto,
                    item.Codigo,
                    item.Descripcion,
                    stockDisp,
                    item.Cantidad,
                    item.PrecioUnitario,
                    subtotal
                );
            }

            ActualizarTotales();

            MessageBox.Show(
                $"Presupuesto #{presupuesto.NroPresupuesto} importado correctamente.\nVerifique los artículos y presione 'Enviar Pedido a Caja'.",
                "Presupuesto Cargado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================================
        // 4. GUARDAR PRESUPUESTO ACTUALIZADO
        // =========================================================================
        // En BGuardarPresupuesto_Click, cuando se emita un presupuesto nuevo,
        // lo guardamos en la lista en memoria:
    }
}
