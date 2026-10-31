using CapaDatos.DTOs;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormProductos : Form
    {
        private readonly ProductoLogica _productoLogica = new ProductoLogica();
        private readonly CategoriaLogica _categoriaLogica = new CategoriaLogica();
        private readonly ProveedorLogica _proveedorLogica = new ProveedorLogica();
        private int _productoId = 0;
        private bool _esEdicion = false;
        private List<CategoriaDto> _categorias;
        private List<ProveedorDto> _proveedores;
        private List<ProductoDto> _productosOriginales;
        private bool _mostrarSoloActivos = true;
        // NUEVO: CancellationTokenSource
        private CancellationTokenSource _ctsCarga;

        public FormProductos()
        {
            InitializeComponent();
            InicializarComportamiento();
        }
        private void InicializarComportamiento()
        {
            AsignarEstiloEIconos();
            ConfigurarFiltrosDinamicos();
        }
        private void CBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBCategoria.SelectedIndex == -1) return;
        }
        private async void FormProductos_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            AplicarRestriccionesPorRol();

            try
            {
                // Cargar todo en paralelo
                await Task.WhenAll(
                    CargarCategoriasAsync(token),
                    CargarProveedoresAsync(token),
                    CargarProductosAsync(token)
                );
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (this.IsDisposed || this.Disposing) return;

            LimpiarCampos();
            ActualizarBotonesSegunModo();

            BLimpiarFiltros.Text = "Inactivos";
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
        private void AplicarRestriccionesPorRol()
        {
            string rol = (SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();

            if (rol == "VENDEDOR" || rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                PTarjetaLateral.Visible = false;

                TLPContenido.ColumnStyles[0].SizeType = SizeType.Percent;
                TLPContenido.ColumnStyles[0].Width = 100F;
                TLPContenido.ColumnStyles[1].SizeType = SizeType.Percent;
                TLPContenido.ColumnStyles[1].Width = 0F;

                DGVProductos.ReadOnly = true;
                DGVProductos.AllowUserToAddRows = false;
                DGVProductos.AllowUserToDeleteRows = false;
                DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVProductos.MultiSelect = false;

                DGVProductos.ClearSelection();
                DGVProductos.CurrentCell = null;

                if (LTituloPrincipal != null)
                    LTituloPrincipal.Text = "CATÁLOGO DE PRODUCTOS";
            }
        }
        private async Task CargarCategoriasAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                _categorias = await _categoriaLogica.ObtenerTodos();
                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                if (_categorias == null || _categorias.Count == 0) return;

                CBCategoria.DataSource = _categorias;
                CBCategoria.DisplayMember = "Descripcion";
                CBCategoria.ValueMember = "Id";
                CBCategoria.SelectedIndex = -1;

                var categoriasFiltro = new List<CategoriaDto>();
                categoriasFiltro.Add(new CategoriaDto { Id = 0, Descripcion = "(Todas)" });
                categoriasFiltro.AddRange(_categorias);

                CBFiltroCategoria.DataSource = categoriasFiltro;
                CBFiltroCategoria.DisplayMember = "Descripcion";
                CBFiltroCategoria.ValueMember = "Id";
                CBFiltroCategoria.SelectedIndex = 0;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async Task CargarProveedoresAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                var proveedores = await _proveedorLogica.ObtenerTodos();
                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                _proveedores = proveedores?.Where(p => p.Estado).ToList() ?? new List<ProveedorDto>();

                var proveedoresCombo = new List<ProveedorDto>();
                proveedoresCombo.Add(new ProveedorDto { Id = 0, Nombre = "(Sin proveedor)" });
                proveedoresCombo.AddRange(_proveedores);

                CBProveedor.DataSource = proveedoresCombo;
                CBProveedor.DisplayMember = "Nombre";
                CBProveedor.ValueMember = "Id";
                CBProveedor.SelectedIndex = 0;
            }
            catch (OperationCanceledException) { }
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
                _productosOriginales = await _productoLogica.ObtenerTodos();
                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                if (_productosOriginales == null || _productosOriginales.Count == 0)
                {
                    DGVProductos.Rows.Clear();
                    return;
                }

                MostrarProductos(_productosOriginales);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void MostrarProductos(List<ProductoDto> productos)
        {
            DGVProductos.SuspendLayout();
            DGVProductos.Rows.Clear();

            var filtrados = productos
                .Where(p => _mostrarSoloActivos ? p.Estado : !p.Estado)
                .ToList();

            foreach (var producto in filtrados)
            {
                DGVProductos.Rows.Add(
                    producto.Id,
                    producto.CodigoInterno ?? "",
                    producto.CodBarras ?? "",
                    producto.Nombre ?? "",
                    producto.CategoriaNombre ?? "",
                    producto.PrecioMayorista?.ToString("0.00") ?? "",
                    producto.PrecioMinorista.ToString("0.00"),
                    producto.StockActual,
                    producto.Estado ? "Activo" : "Inactivo"
                );
            }

            DGVProductos.ResumeLayout();
            AplicarFiltroGrilla();
        }
        private void DGVProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string rol = (SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();
            if (rol == "VENDEDOR" || rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
                return;

            try
            {
                var idValue = DGVProductos.Rows[e.RowIndex].Cells[0].Value;

                if (idValue == null || idValue == DBNull.Value)
                {
                    MessageBox.Show("No se pudo obtener el ID del producto.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(idValue);

                _productoId = id;
                _esEdicion = true;
                CargarProductoEnFormulario(id);

                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void CargarProductoEnFormulario(int id)
        {
            var token = _ctsCarga?.Token ?? CancellationToken.None;

            try
            {
                var producto = await _productoLogica.ObtenerPorId(id);
                if (token.IsCancellationRequested || this.IsDisposed) return;

                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TCodigoInterno.Text = producto.CodigoInterno ?? "";
                TCodBarras.Text = producto.CodBarras ?? "";
                TNombreProducto.Text = producto.Nombre ?? "";
                TDescripcion.Text = producto.Descripcion ?? "";
                TPrecioMinorista.Text = producto.PrecioMinorista.ToString("0.00");
                TPrecioMayorista.Text = producto.PrecioMayorista?.ToString("0.00") ?? "";

                if (producto.CategoriaId > 0 && CBCategoria.DataSource != null)
                {
                    CBCategoria.SelectedValue = producto.CategoriaId;

                    if (CBCategoria.SelectedIndex == -1)
                    {
                        for (int i = 0; i < CBCategoria.Items.Count; i++)
                        {
                            var cat = CBCategoria.Items[i] as CategoriaDto;
                            if (cat != null && cat.Id == producto.CategoriaId)
                            {
                                CBCategoria.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }

                if (producto.ProveedorId.HasValue && producto.ProveedorId.Value > 0)
                {
                    CBProveedor.SelectedValue = producto.ProveedorId.Value;

                    if (CBProveedor.SelectedIndex == -1)
                    {
                        for (int i = 0; i < CBProveedor.Items.Count; i++)
                        {
                            var prov = CBProveedor.Items[i] as ProveedorDto;
                            if (prov != null && prov.Id == producto.ProveedorId.Value)
                            {
                                CBProveedor.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    CBProveedor.SelectedIndex = 0;
                }

                NUDStockActual.Value = producto.StockActual;
                NUDStockMinimo.Value = producto.StockMinimo;
                ChBProductoHabilitado.Checked = producto.Estado;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void ValidarDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (txt.Text.Contains(",") || txt.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }

                if (txt.Text.Length == 0)
                {
                    txt.Text = "0,";
                    txt.SelectionStart = txt.Text.Length;
                    e.Handled = true;
                    return;
                }

                e.KeyChar = ',';
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                int indexSeparador = txt.Text.IndexOfAny(new char[] { ',', '.' });

                if (indexSeparador != -1)
                {
                    if (txt.SelectionStart > indexSeparador && txt.SelectionLength == 0)
                    {
                        string parteDecimal = txt.Text.Substring(indexSeparador + 1);

                        if (parteDecimal.Length >= 2)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
                return;
            }

            e.Handled = true;
        }
        public static bool IntentarConvertirDecimal(string texto, out decimal valor)
        {
            valor = 0;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            string textoNormalizado = texto.Trim().Replace(',', '.');

            return decimal.TryParse(
                textoNormalizado,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out valor
            );
        }
        private void FormatearMoneda_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text)) return;

            if (IntentarConvertirDecimal(txt.Text, out decimal valor))
            {
                txt.Text = valor.ToString("0.00");
            }
        }
        private bool ValidarCamposProducto()
        {
            if (string.IsNullOrWhiteSpace(TCodigoInterno.Text))
            {
                MessageBox.Show("El Código Interno es obligatorio.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TCodigoInterno.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TNombreProducto.Text) || TNombreProducto.Text.Trim().Length < 3)
            {
                MessageBox.Show("Debe ingresar un Nombre de Producto válido (mínimo 3 caracteres).",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TNombreProducto.Focus();
                return false;
            }

            if (CBCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Categoría.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBCategoria.Focus();
                return false;
            }

            if (!IntentarConvertirDecimal(TPrecioMinorista.Text, out decimal precioMinorista) || precioMinorista <= 0)
            {
                MessageBox.Show("Ingrese un Precio Minorista válido mayor a 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TPrecioMinorista.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(TPrecioMayorista.Text))
            {
                if (!IntentarConvertirDecimal(TPrecioMayorista.Text, out decimal precioMayorista) || precioMayorista <= 0)
                {
                    MessageBox.Show("Ingrese un Precio Mayorista válido mayor a 0, o déjelo vacío.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TPrecioMayorista.Focus();
                    return false;
                }

                if (precioMayorista > precioMinorista)
                {
                    MessageBox.Show("El precio mayorista no puede superar al precio minorista.",
                                    "Error de Precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TPrecioMayorista.Focus();
                    return false;
                }
            }

            if (NUDStockMinimo.Value <= 0)
            {
                MessageBox.Show("El Stock Mínimo debe ser de al menos 1 unidad.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NUDStockMinimo.Focus();
                return false;
            }

            if (NUDStockActual.Value < NUDStockMinimo.Value)
            {
                DialogResult res = MessageBox.Show(
                    "El Stock Actual es menor al Stock Mínimo.\n¿Desea registrar el producto bajo nivel crítico?",
                    "Aviso de Stock Crítico",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.No)
                {
                    NUDStockActual.Focus();
                    return false;
                }
            }

            if (TDescripcion.Text.Trim().Length > 300)
            {
                MessageBox.Show("La descripción no puede exceder los 300 caracteres.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDescripcion.Focus();
                return false;
            }

            return true;
        }
        private async void BGuardar_Click(object sender, EventArgs e)
        {
            if (_esEdicion)
            {
                MessageBox.Show("Está en modo edición. Use el botón 'Actualizar'.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCamposProducto())
                return;

            BGuardar.Enabled = false;
            BActualizar.Enabled = false;

            try
            {
                int? idProveedor = ObtenerIdProveedorSeleccionado();

                IntentarConvertirDecimal(TPrecioMinorista.Text, out decimal precioMinorista);
                decimal? precioMayorista = null;
                if (!string.IsNullOrWhiteSpace(TPrecioMayorista.Text) &&
                    IntentarConvertirDecimal(TPrecioMayorista.Text, out decimal pm))
                {
                    precioMayorista = pm;
                }

                var nuevoProducto = new CrearProductoDto
                {
                    CodigoInterno = TCodigoInterno.Text.Trim(),
                    CodBarras = string.IsNullOrWhiteSpace(TCodBarras.Text) ? null : TCodBarras.Text.Trim(),
                    Nombre = TNombreProducto.Text.Trim(),
                    Descripcion = TDescripcion.Text.Trim(),
                    CategoriaId = (int)CBCategoria.SelectedValue,
                    ProveedorId = idProveedor,
                    StockActual = (int)NUDStockActual.Value,
                    StockMinimo = (int)NUDStockMinimo.Value,
                    StockMaximo = 1000,
                    Costo = 0,
                    PrecioMinorista = precioMinorista,
                    PrecioMayorista = precioMayorista,
                    Estado = ChBProductoHabilitado.Checked
                };

                await _productoLogica.Crear(nuevoProducto);

                MessageBox.Show("Producto creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProductosAsync(_ctsCarga?.Token ?? CancellationToken.None);
                LimpiarCampos();
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BGuardar.Enabled = true;
                BActualizar.Enabled = false;
            }
        }
        private async void BActualizar_Click(object sender, EventArgs e)
        {
            if (!_esEdicion || _productoId <= 0)
            {
                MessageBox.Show("Seleccione un producto de la grilla para actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCamposProducto())
                return;

            BGuardar.Enabled = false;
            BActualizar.Enabled = false;

            try
            {
                int? idProveedor = ObtenerIdProveedorSeleccionado();

                IntentarConvertirDecimal(TPrecioMinorista.Text, out decimal precioMinorista);
                decimal? precioMayorista = null;
                if (!string.IsNullOrWhiteSpace(TPrecioMayorista.Text) &&
                    IntentarConvertirDecimal(TPrecioMayorista.Text, out decimal pm))
                {
                    precioMayorista = pm;
                }

                var actualizarProducto = new CrearProductoDto
                {
                    Nombre = TNombreProducto.Text.Trim(),
                    CodBarras = string.IsNullOrWhiteSpace(TCodBarras.Text) ? null : TCodBarras.Text.Trim(),
                    CodigoInterno = TCodigoInterno.Text.Trim(),
                    Descripcion = TDescripcion.Text.Trim(),
                    Costo = 0,
                    PrecioMinorista = precioMinorista,
                    PrecioMayorista = precioMayorista,
                    StockActual = (int)NUDStockActual.Value,
                    StockMinimo = (int)NUDStockMinimo.Value,
                    StockMaximo = 1000,
                    ProveedorId = idProveedor,
                    CategoriaId = (int)CBCategoria.SelectedValue,
                    Estado = ChBProductoHabilitado.Checked
                };

                await _productoLogica.Actualizar(_productoId, actualizarProducto);

                MessageBox.Show("Producto actualizado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProductosAsync(_ctsCarga?.Token ?? CancellationToken.None);
                LimpiarCampos();
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BGuardar.Enabled = false;
                BActualizar.Enabled = true;
            }
        }
        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (DGVProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para dar de baja", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var idValue = DGVProductos.SelectedRows[0].Cells[0].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int id = Convert.ToInt32(idValue);
                string nombre = DGVProductos.SelectedRows[0].Cells[3].Value?.ToString() ?? "";

                if (MessageBox.Show($"¿Desea dar de baja el producto '{nombre}'?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BGuardar.Enabled = false;
                    BActualizar.Enabled = false;
                    BDesactivar.Enabled = false;

                    await _productoLogica.Eliminar(id);

                    MessageBox.Show("Producto dado de baja exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarProductosAsync(_ctsCarga?.Token ?? CancellationToken.None);
                    LimpiarCampos();
                    BDesactivar.Enabled = true;
                    ActualizarBotonesSegunModo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dar de baja: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BDesactivar.Enabled = true;
                ActualizarBotonesSegunModo();
            }
        }
        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            _esEdicion = false;
            _productoId = 0;
            ActualizarBotonesSegunModo();
            TCodigoInterno.Focus();
        }
        private async void BNuevaCategoria_Click(object sender, EventArgs e)
        {
            using (FormModalCategoria modal = new FormModalCategoria())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarCategoriasAsync(_ctsCarga?.Token ?? CancellationToken.None);

                    if (modal.IdCategoriaCreada > 0 && CBCategoria.DataSource != null)
                    {
                        CBCategoria.SelectedValue = modal.IdCategoriaCreada;
                    }
                }
            }
        }
        private void ConfigurarFiltrosDinamicos()
        {
            TBBuscar.TextChanged += (s, e) => AplicarFiltroGrilla();
            CBFiltroCategoria.SelectedIndexChanged += (s, e) => AplicarFiltroGrilla();
            BLimpiarFiltros.Click += BLimpiarFiltros_Click;
        }
        private void AplicarFiltroGrilla()
        {
            string texto = TBBuscar.Text.Trim().ToLower();
            string categoriaFiltro = (CBFiltroCategoria.SelectedItem as CategoriaDto)?.Descripcion ?? "";

            bool filtrarPorCategoria = !string.IsNullOrEmpty(categoriaFiltro) && categoriaFiltro != "(Todas)";

            DGVProductos.SuspendLayout();
            foreach (DataGridViewRow row in DGVProductos.Rows)
            {
                if (row.IsNewRow) continue;

                string codInterno = row.Cells["ColCodInterno"].Value?.ToString().ToLower() ?? "";
                string codBarras = row.Cells["ColCodBarras"].Value?.ToString().ToLower() ?? "";
                string nombre = row.Cells["ColNombre"].Value?.ToString().ToLower() ?? "";
                string categoria = row.Cells["ColCategoria"].Value?.ToString() ?? "";

                bool coincideTexto = string.IsNullOrEmpty(texto) ||
                                     codInterno.Contains(texto) ||
                                     codBarras.Contains(texto) ||
                                     nombre.Contains(texto);

                bool coincideCategoria = !filtrarPorCategoria ||
                                         categoria.Equals(categoriaFiltro, StringComparison.OrdinalIgnoreCase);

                row.Visible = coincideTexto && coincideCategoria;
            }
            DGVProductos.ResumeLayout();
        }
        private async void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _mostrarSoloActivos = !_mostrarSoloActivos;
            BLimpiarFiltros.Text = _mostrarSoloActivos ? "Inactivos" : "Activos";
            await CargarProductosAsync(_ctsCarga?.Token ?? CancellationToken.None);
        }
        private void LimpiarCampos()
        {
            TCodigoInterno.Clear();
            TCodBarras.Clear();
            TNombreProducto.Clear();
            TDescripcion.Clear();
            TPrecioMinorista.Clear();
            TPrecioMayorista.Clear();

            if (CBCategoria.DataSource != null)
                CBCategoria.SelectedIndex = -1;

            if (CBProveedor.DataSource != null)
                CBProveedor.SelectedIndex = 0;

            NUDStockActual.Value = 0;
            NUDStockMinimo.Value = 1;
            ChBProductoHabilitado.Checked = true;

            _esEdicion = false;
            _productoId = 0;

            DGVProductos.ClearSelection();
            if (DGVProductos.CurrentCell != null)
                DGVProductos.CurrentCell = null;

            ActualizarBotonesSegunModo();
        }
        private void ActualizarBotonesSegunModo()
        {
            if (_esEdicion)
            {
                BGuardar.Enabled = false;
                BActualizar.Enabled = true;
            }
            else
            {
                BGuardar.Enabled = true;
                BActualizar.Enabled = false;
            }
        }
        private int? ObtenerIdProveedorSeleccionado()
        {
            if (CBProveedor.SelectedItem is ProveedorDto prov && prov.Id > 0)
                return prov.Id;

            return null;
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
        private void AsignarEstiloEIconos()
        {
            try
            {
                BNuevo.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);
                BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BActualizar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
                BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch { }
        }
    }
}