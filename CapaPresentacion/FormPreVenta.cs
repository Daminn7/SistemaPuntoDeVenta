using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaPresentacion.FormPrincipal;
using CapaLogica;
using CapaDatos.DTOs;
using CapaDatos.Helpers;

namespace CapaPresentacion
{
    public partial class FormPreVenta : Form
    {
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
        private ArticuloCatalogo _insumoSeleccionado = null;
        private readonly ClienteLogica _clienteLogica = new ClienteLogica();
        private List<ClienteResponseDto> _clientes;
        private readonly ProductoLogica _productoLogica = new ProductoLogica();
        private List<ProductoDto> _productos;
        private readonly OrdenVentaLogica _ordenVentaLogica = new OrdenVentaLogica();
        private int _ordenIdCargado = 0;
        private string _tituloOriginal = "PREVENTA Y ATENCIÓN A CLIENTES";
        private CancellationTokenSource _ctsCarga;

        public FormPreVenta()
        {
            InitializeComponent();
            ConfigurarBuscadorReactivo();
        }
        private async void FormPreVenta_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            AsignarIconoTitulo();
            _tituloOriginal = LTituloPrincipal.Text;

            try
            {
                await CancelarPresupuestosVencidosAsync();
                if (token.IsCancellationRequested) return;

                await CargarClientesAsync();
                if (token.IsCancellationRequested) return;

                await CargarProductosAsync();
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (this.IsDisposed || this.Disposing) return;

            ConfigurarEstructuraDetalle();
            LimpiarFormulario();
            ActualizarBotonGuardar();
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
        private async Task CancelarPresupuestosVencidosAsync()
        {
            try
            {
                var resultado = await _ordenVentaLogica.CancelarVencidos();

                if (resultado != null)
                {
                    int cancelados = (int)(resultado.cancelados ?? 0);
                    if (cancelados > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"Se cancelaron {cancelados} presupuestos vencidos.");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cancelar vencidos: {ex.Message}");
            }
        }
        private Image DibujarIconoPreVenta(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
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
        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productoLogica.ObtenerTodos();
                _productos = productos ?? new List<ProductoDto>();

                _catalogoInsumos = _productos
                    .Where(p => p.Estado)
                    .Select(p => new ArticuloCatalogo
                    {
                        Id = p.Id,
                        Codigo = p.CodigoInterno ?? p.CodBarras ?? "",
                        Descripcion = p.Nombre,
                        Stock = p.StockActual,
                        PrecioMinorista = p.PrecioMinorista,
                        PrecioMayorista = p.PrecioMayorista ?? p.PrecioMinorista
                    })
                    .ToList();

                CargarArticulosEnCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarArticulosEnCombo()
        {
            CBArticulos.Items.Clear();

            foreach (var art in _catalogoInsumos)
            {
                CBArticulos.Items.Add(new ArticuloItem
                {
                    IdProducto = art.Id,
                    Codigo = art.Codigo,
                    Descripcion = art.Descripcion,
                    Stock = art.Stock,
                    PrecioMinorista = art.PrecioMinorista,
                    PrecioMayorista = art.PrecioMayorista
                });
            }

            CBArticulos.SelectedIndex = -1;
            CBArticulos.Text = "";
        }
        private void CBArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBArticulos.SelectedItem is ArticuloItem item)
            {
                _insumoSeleccionado = new ArticuloCatalogo
                {
                    Id = item.IdProducto,
                    Codigo = item.Codigo,
                    Descripcion = item.Descripcion,
                    Stock = item.Stock,
                    PrecioMinorista = item.PrecioMinorista,
                    PrecioMayorista = item.PrecioMayorista
                };

                int yaEnGrilla = 0;
                foreach (DataRow row in _dtDetalle.Rows)
                {
                    if (Convert.ToInt32(row["ColIdProducto"]) == item.IdProducto)
                    {
                        yaEnGrilla = Convert.ToInt32(row["ColCantidad"]);
                        break;
                    }
                }

                int stockDisponible = item.Stock - yaEnGrilla;

                if (stockDisponible <= 0)
                {
                    MessageBox.Show(
                        $"Sin stock disponible.\n\n" +
                        $"Producto: {item.Descripcion}\n" +
                        $"Stock total: {item.Stock}\n" +
                        $"Ya en el detalle: {yaEnGrilla}\n\n" +
                        "No se puede agregar más unidades.",
                        "Stock Agotado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    _insumoSeleccionado = null;
                    CBArticulos.SelectedIndex = -1;
                    LStockDisponible.Text = "";
                    return;
                }

                NUDCantidad.Minimum = 1;
                NUDCantidad.Maximum = stockDisponible;
                NUDCantidad.Value = 1;

                LStockDisponible.Text = $"Stock disp: {stockDisponible}";
                LStockDisponible.ForeColor = stockDisponible <= 3
                    ? Color.FromArgb(192, 57, 43)
                    : Color.FromArgb(39, 174, 96);

                NUDCantidad.Focus();
                NUDCantidad.Select(0, NUDCantidad.Text.Length);
            }
        }
        private void ConfigurarBuscadorReactivo()
        {
            NUDCantidad.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BAgregarItem.PerformClick();
                }
            };

            NUDCantidad.ValueChanged += (s, e) =>
            {
                if (_insumoSeleccionado == null) return;

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

                if (NUDCantidad.Value > stockDisponible && stockDisponible > 0)
                {
                    NUDCantidad.Value = stockDisponible;
                    MessageBox.Show(
                        $"Solo quedan {stockDisponible} unidades de '{_insumoSeleccionado.Descripcion}' disponibles.",
                        "Stock insuficiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            };
        }
        private async Task CargarClientesAsync()
        {
            try
            {
                var clientes = await _clienteLogica.ObtenerTodos();
                _clientes = clientes ?? new List<ClienteResponseDto>();

                CBClientes.Items.Clear();

                var consumidorFinal = _clientes.FirstOrDefault(c => c.Dni == "00000000");
                if (consumidorFinal != null)
                {
                    CBClientes.Items.Add(new ClienteItem
                    {
                        IdCliente = consumidorFinal.IdCliente,
                        Display = "Consumidor Final"
                    });
                }

                var otros = _clientes
                    .Where(c => c.Estado && c.Dni != "00000000")
                    .OrderBy(c => c.Apellido)
                    .ThenBy(c => c.Nombre)
                    .ToList();

                foreach (var cliente in otros)
                {
                    string nombreCompleto = $"{cliente.Nombre} {cliente.Apellido}".Trim();
                    string documento = cliente.Dni ?? cliente.CuilCuit ?? "";
                    string display = $"{nombreCompleto} ({documento})";

                    CBClientes.Items.Add(new ClienteItem
                    {
                        IdCliente = cliente.IdCliente,
                        Display = display
                    });
                }

                if (CBClientes.Items.Count > 0)
                    CBClientes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int ObtenerIdClienteSeleccionado()
        {
            if (CBClientes.SelectedItem is ClienteItem item)
                return item.IdCliente;

            return 0;
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

            ColPrecioUnit.DefaultCellStyle.Format = "C2";
            ColSubtotal.DefaultCellStyle.Format = "C2";

            DGVDetalle.DataSource = _dtDetalle;
        }
        private void BAgregarItem_Click(object sender, EventArgs e)
        {
            if (_insumoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un artículo del desplegable.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBArticulos.Focus();
                return;
            }

            int cantidadSolicitada = (int)NUDCantidad.Value;

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

            if (cantidadTotal > _insumoSeleccionado.Stock)
            {
                int stockDisponible = _insumoSeleccionado.Stock - cantidadActualEnGrilla;
                MessageBox.Show(
                    $"Stock insuficiente.\n\n" +
                    $"Producto: {_insumoSeleccionado.Descripcion}\n" +
                    $"Stock total: {_insumoSeleccionado.Stock}\n" +
                    $"Ya en el detalle: {cantidadActualEnGrilla}\n" +
                    $"Disponible: {stockDisponible}\n\n" +
                    $"Solo quedan {stockDisponible} unidades disponibles.",
                    "Stock Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal precioAplicado = RBPremioMayorista.Checked
                ? _insumoSeleccionado.PrecioMayorista
                : _insumoSeleccionado.PrecioMinorista;

            if (filaExistente != null)
            {
                filaExistente["ColCantidad"] = cantidadTotal;
                filaExistente["ColSubtotal"] = cantidadTotal * precioAplicado;
            }
            else
            {
                decimal subtotal = cantidadSolicitada * precioAplicado;
                _dtDetalle.Rows.Add(
                    _insumoSeleccionado.Id,
                    _insumoSeleccionado.Codigo,
                    _insumoSeleccionado.Descripcion,
                    _insumoSeleccionado.Stock,
                    cantidadSolicitada,
                    precioAplicado,
                    subtotal);
            }

            _insumoSeleccionado = null;
            CBArticulos.SelectedIndex = -1;
            CBArticulos.Text = "";
            LStockDisponible.Text = "";
            NUDCantidad.Maximum = 10000;
            NUDCantidad.Value = 1;
            CBArticulos.Focus();

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
        private void TipoPrecio_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in _dtDetalle.Rows)
            {
                int idArt = Convert.ToInt32(row["ColIdProducto"]);
                var art = _catalogoInsumos.FirstOrDefault(a => a.Id == idArt);
                if (art != null)
                {
                    decimal nuevoPrecio = RBPremioMayorista.Checked
                        ? art.PrecioMayorista
                        : art.PrecioMinorista;
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
        private void ActualizarBotonGuardar()
        {
            if (_ordenIdCargado > 0)
            {
                BGuardarPresupuesto.Enabled = false;
                BGuardarPresupuesto.BackColor = Color.FromArgb(180, 180, 180);
            }
            else
            {
                BGuardarPresupuesto.Enabled = true;
                BGuardarPresupuesto.BackColor = Color.FromArgb(41, 128, 185);
            }
        }
        private async void BCargarPresupuesto_Click(object sender, EventArgs e)
        {
            try
            {
                var todas = await _ordenVentaLogica.ObtenerTodas();

                var ahora = DateTime.Now;
                var pendientes = todas?
                    .Where(o => o.EstadoVentaId == 1 && o.FechaValidez.HasValue && o.FechaValidez.Value >= ahora)
                    .OrderByDescending(o => o.FechaCreacion)
                    .ToList() ?? new List<OrdenVentaDto>();

                if (pendientes.Count == 0)
                {
                    MessageBox.Show("No hay presupuestos pendientes y vigentes para cargar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var modal = CrearModalSeleccionPresupuesto(pendientes))
                {
                    if (modal.ShowDialog(this) != DialogResult.OK) return;

                    var seleccionado = modal.Tag as OrdenVentaDto;
                    if (seleccionado == null) return;

                    if (_dtDetalle.Rows.Count > 0)
                    {
                        var res = MessageBox.Show(
                            "Hay artículos cargados en la grilla actual. ¿Desea reemplazarlos con los del presupuesto?",
                            "Reemplazar Ítems",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (res != DialogResult.Yes) return;
                    }

                    await CargarPresupuestoEnFormularioAsync(seleccionado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar presupuestos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Form CrearModalSeleccionPresupuesto(List<OrdenVentaDto> pendientes)
        {
            var modal = new Form
            {
                Text = "Seleccionar Presupuesto Pendiente",
                Size = new Size(820, 500),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblTitulo = new Label
            {
                Text = "Presupuestos Pendientes vigentes (seleccione uno para cargar):",
                Dock = DockStyle.Top,
                Height = 32,
                Padding = new Padding(12, 10, 0, 0),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(212, 131, 53)
            };

            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.FixedSingle
            };

            dgv.Columns.Add("Nro", "N° Presupuesto");
            dgv.Columns.Add("Fecha", "Fecha");
            dgv.Columns.Add("Cliente", "Cliente");
            dgv.Columns.Add("Items", "Ítems");
            dgv.Columns.Add("Total", "Total ($)");
            dgv.Columns.Add("Vendedor", "Vendedor");

            dgv.Columns["Nro"].FillWeight = 90;
            dgv.Columns["Fecha"].FillWeight = 80;
            dgv.Columns["Cliente"].FillWeight = 180;
            dgv.Columns["Items"].FillWeight = 60;
            dgv.Columns["Total"].FillWeight = 80;
            dgv.Columns["Vendedor"].FillWeight = 120;

            foreach (var orden in pendientes)
            {
                int cantItems = orden.Detalles?.Sum(d => d.Cantidad) ?? 0;

                string fechaStr = FechaHelper.ToArgentinaString(orden.FechaCreacion, "dd/MM/yyyy HH:mm");

                dgv.Rows.Add(
                    orden.NumeroPresupuesto ?? $"#{orden.IdOrden}",
                    fechaStr,
                    orden.ClienteNombre ?? "Consumidor Final",
                    cantItems,
                    orden.Total.ToString("N2"),
                    orden.PersonalNombre ?? ""
                );
            }

            if (dgv.Rows.Count > 0)
                dgv.Rows[0].Selected = true;

            dgv.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    modal.DialogResult = DialogResult.OK;
            };

            var pnlBotones = new Panel { Dock = DockStyle.Bottom, Height = 52 };

            var btnCargar = new Button
            {
                Text = "📂 Cargar Presupuesto",
                BackColor = Color.FromArgb(212, 131, 53),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 36),
                Location = new Point(420, 8),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnCargar.FlatAppearance.BorderSize = 0;

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 36),
                Location = new Point(610, 8),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };
            btnCancelar.FlatAppearance.BorderSize = 0;

            pnlBotones.Controls.Add(btnCargar);
            pnlBotones.Controls.Add(btnCancelar);

            modal.Controls.Add(dgv);
            modal.Controls.Add(pnlBotones);
            modal.Controls.Add(lblTitulo);

            modal.AcceptButton = btnCargar;
            modal.CancelButton = btnCancelar;

            modal.FormClosing += (s, e) =>
            {
                if (modal.DialogResult == DialogResult.OK && dgv.SelectedRows.Count > 0)
                {
                    int index = dgv.SelectedRows[0].Index;
                    modal.Tag = pendientes[index];
                }
            };

            return modal;
        }
        private async Task CargarPresupuestoEnFormularioAsync(OrdenVentaDto orden)
        {
            try
            {
                _dtDetalle.Rows.Clear();

                bool clienteEncontrado = false;
                for (int i = 0; i < CBClientes.Items.Count; i++)
                {
                    if (CBClientes.Items[i] is ClienteItem item && item.IdCliente == orden.ClienteId)
                    {
                        CBClientes.SelectedIndex = i;
                        clienteEncontrado = true;
                        break;
                    }
                }

                if (!clienteEncontrado)
                {
                    MessageBox.Show(
                        $"El cliente '{orden.ClienteNombre}' no está disponible.\n\n" +
                        "Se asignará 'Consumidor Final' por defecto.",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CBClientes.SelectedIndex = 0;
                }

                var ordenCompleta = await _ordenVentaLogica.ObtenerPorId(orden.IdOrden);

                if (ordenCompleta?.Detalles == null || ordenCompleta.Detalles.Count == 0)
                {
                    MessageBox.Show("El presupuesto no tiene ítems.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool esMayorista = false;
                foreach (var detalle in ordenCompleta.Detalles)
                {
                    var articulo = _catalogoInsumos.FirstOrDefault(a => a.Id == detalle.ProductoId);
                    if (articulo != null
                        && detalle.PrecioUnitario == articulo.PrecioMayorista
                        && detalle.PrecioUnitario != articulo.PrecioMinorista)
                    {
                        esMayorista = true;
                        break;
                    }
                }

                RBPremioMayorista.Checked = esMayorista;
                RBPremioMinorista.Checked = !esMayorista;

                foreach (var detalle in ordenCompleta.Detalles)
                {
                    var articulo = _catalogoInsumos.FirstOrDefault(a => a.Id == detalle.ProductoId);
                    int stockActual = articulo?.Stock ?? 0;

                    _dtDetalle.Rows.Add(
                        detalle.ProductoId,
                        detalle.ProductoCodigo ?? "",
                        detalle.ProductoNombre ?? "",
                        stockActual,
                        detalle.Cantidad,
                        detalle.PrecioUnitario,
                        detalle.Subtotal
                    );
                }

                ActualizarTotales();

                _ordenIdCargado = orden.IdOrden;
                LTituloPrincipal.Text = $"EDITANDO PRESUPUESTO {orden.NumeroPresupuesto}";
                ActualizarBotonGuardar();

                MessageBox.Show(
                    $"Presupuesto #{orden.NumeroPresupuesto} cargado correctamente.\n\n" +
                    $"Cliente: {orden.ClienteNombre}\n" +
                    $"Ítems: {ordenCompleta.Detalles.Count}\n" +
                    $"Total: {orden.Total:C2}\n\n" +
                    "Modifique si es necesario y presione 'Enviar Pedido a Caja'.",
                    "Presupuesto Cargado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el presupuesto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BGuardarPresupuesto_Click(object sender, EventArgs e)
        {
            if (_ordenIdCargado > 0)
            {
                MessageBox.Show(
                    "Está editando un presupuesto existente. Use 'Enviar Pedido a Caja' para confirmarlo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Cargue artículos antes de guardar el presupuesto.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = ObtenerIdClienteSeleccionado();
            if (idCliente <= 0)
            {
                MessageBox.Show("Seleccione un cliente válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BGuardarPresupuesto.Enabled = false;

                var nuevaOrden = new CrearOrdenVentaDto
                {
                    ClienteId = idCliente,
                    PersonalId = SesionUsuario.IdPersonal,
                    TipoDocumentoId = 5,
                    EstadoVentaId = 1,
                    FechaValidez = DateTime.Now.AddDays(7),
                    Detalles = new List<CrearDetalleOrdenDto>()
                };

                foreach (DataRow row in _dtDetalle.Rows)
                {
                    nuevaOrden.Detalles.Add(new CrearDetalleOrdenDto
                    {
                        ProductoId = Convert.ToInt32(row["ColIdProducto"]),
                        Cantidad = Convert.ToInt32(row["ColCantidad"]),
                        PrecioUnitario = Convert.ToDecimal(row["ColPrecioUnit"])
                    });
                }

                var respuesta = await _ordenVentaLogica.Crear(nuevaOrden);

                GenerarPDFPresupuesto(respuesta.NumeroPresupuesto);

                MessageBox.Show(
                    $"Presupuesto #{respuesta.NumeroPresupuesto} guardado correctamente.\n" +
                    $"Total: {respuesta.Total:C2}\n" +
                    "Quedó registrado como Pendiente.",
                    "Presupuesto Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar presupuesto:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BGuardarPresupuesto.Enabled = true;
                ActualizarBotonGuardar();
            }
        }
        private void BImprimirPresupuesto_Click(object sender, EventArgs e)
        {
            if (_dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Cargue artículos antes de imprimir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                GenerarPDFPresupuesto(_ordenIdCargado > 0 ? $"EDIT-{_ordenIdCargado}" : "BORRADOR");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BEnviarACaja_Click(object sender, EventArgs e)
        {
            if (_dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe cargar al menos un artículo para enviar a Caja.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = ObtenerIdClienteSeleccionado();
            if (idCliente <= 0)
            {
                MessageBox.Show("Seleccione un cliente válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res = MessageBox.Show(
                $"¿Confirmar envío a Caja?\n\nCliente: {CBClientes.Text}\nTotal: {LTotalMonto.Text}",
                "Enviar a Cobro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            try
            {
                BEnviarACaja.Enabled = false;

                var dto = new CrearOrdenVentaDto
                {
                    ClienteId = idCliente,
                    PersonalId = SesionUsuario.IdPersonal,
                    TipoDocumentoId = 5,
                    EstadoVentaId = 1,
                    FechaValidez = DateTime.Now.AddDays(7),
                    Detalles = new List<CrearDetalleOrdenDto>()
                };

                foreach (DataRow row in _dtDetalle.Rows)
                {
                    dto.Detalles.Add(new CrearDetalleOrdenDto
                    {
                        ProductoId = Convert.ToInt32(row["ColIdProducto"]),
                        Cantidad = Convert.ToInt32(row["ColCantidad"]),
                        PrecioUnitario = Convert.ToDecimal(row["ColPrecioUnit"])
                    });
                }

                int idOrden;

                if (_ordenIdCargado > 0)
                {
                    await _ordenVentaLogica.ActualizarDetalles(_ordenIdCargado, dto);
                    idOrden = _ordenIdCargado;
                }
                else
                {
                    var respuesta = await _ordenVentaLogica.Crear(dto);
                    idOrden = respuesta.IdOrden;
                }

                await _ordenVentaLogica.Confirmar(idOrden);

                MessageBox.Show(
                    "Pedido enviado a Caja correctamente.\n\n" +
                    "El cajero ya puede procesar el cobro.",
                    "Enviado a Caja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar a Caja:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                BEnviarACaja.Enabled = true;
            }
        }
        private void BCancelarVenta_Click(object sender, EventArgs e)
        {
            if (_dtDetalle.Rows.Count > 0 || _ordenIdCargado > 0)
            {
                DialogResult res = MessageBox.Show("¿Desea limpiar todos los ítems cargados?", "Limpiar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            _ordenIdCargado = 0;
            _dtDetalle.Rows.Clear();

            if (CBClientes.Items.Count > 0)
                CBClientes.SelectedIndex = 0;

            CBArticulos.SelectedIndex = -1;
            CBArticulos.Text = "";
            LStockDisponible.Text = "";

            NUDCantidad.Maximum = 10000;
            NUDCantidad.Value = 1;
            RBPremioMinorista.Checked = true;

            LTituloPrincipal.Text = _tituloOriginal;
            ActualizarBotonGuardar();
            ActualizarTotales();
        }
        private void GenerarPDFPresupuesto(string numeroPresupuesto)
        {
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = $"Presupuesto_{numeroPresupuesto}";
            pd.PrintPage += (s, args) => ImprimirPresupuesto_PrintPage(s, args, numeroPresupuesto);

            PrintPreviewDialog prev = new PrintPreviewDialog
            {
                Document = pd,
                Width = 850,
                Height = 650,
                StartPosition = FormStartPosition.CenterScreen
            };
            prev.ShowDialog();
        }
        private void ImprimirPresupuesto_PrintPage(object sender, PrintPageEventArgs e, string numeroPresupuesto = "")
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
                g.DrawString($"PRESUPUESTO N° {numeroPresupuesto} - VALIDEZ: 7 DÍAS", fSub, bGrafito, x, y + 28);
                g.DrawString($"Cliente: {CBClientes.Text}  |  Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}  |  Operador: {SesionUsuario.Nombre}", fSub, bGris, x, y + 48);

                y += 75;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 15;

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
        private class ClienteItem
        {
            public int IdCliente { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }
        private class ArticuloItem
        {
            public int IdProducto { get; set; }
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
            public int Stock { get; set; }
            public decimal PrecioMinorista { get; set; }
            public decimal PrecioMayorista { get; set; }
            public override string ToString() =>
                $"{Codigo} - {Descripcion} (Stock: {Stock})";
        }
    }
}