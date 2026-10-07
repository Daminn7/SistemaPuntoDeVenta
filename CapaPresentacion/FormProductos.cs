using CapaDatos.DTOs;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormProductos : Form
    {
        // ============================================================
        // DECLARACIÓN DE VARIABLES
        // ============================================================
        private readonly ProductoLogica _productoLogica = new ProductoLogica();
        private readonly CategoriaLogica _categoriaLogica = new CategoriaLogica();
        private readonly ProveedorLogica _proveedorLogica = new ProveedorLogica();

        private int _productoId = 0;
        private bool _esEdicion = false;

        private List<CategoriaDto> _categorias;
        private List<ProveedorDto> _proveedores;
        private List<ProductoDto> _productosOriginales;

        // ✅ NUEVO: Controla qué productos se muestran (true = activos, false = inactivos)
        private bool _mostrarSoloActivos = true;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
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
        // ============================================================
        // ✅ NUEVO: Al cambiar la categoría, se puede filtrar el combo de proveedores
        //    (por ahora solo limpia el proveedor seleccionado)
        // ============================================================
        private void CBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si no hay categoría seleccionada, no hacer nada
            if (CBCategoria.SelectedIndex == -1) return;

            // Aquí podrías filtrar proveedores por categoría si quisieras
            // Por ahora, dejamos el combo de proveedores como está
        }
        // ============================================================
        // CARGA DEL FORMULARIO
        // ============================================================
        private async void FormProductos_Load(object sender, EventArgs e)
        {
            AplicarRestriccionesPorRol();

            await CargarCategoriasAsync();
            await CargarProveedoresAsync();
            await CargarProductosAsync();

            LimpiarCampos();
            ActualizarBotonesSegunModo();

            BLimpiarFiltros.Text = "Inactivos";
        }

        // ============================================================
        // PERMISOS POR ROL
        // ============================================================
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

        // ============================================================
        // CARGA DE CATEGORÍAS
        // ============================================================
        private async Task CargarCategoriasAsync()
        {
            try
            {
                _categorias = await _categoriaLogica.ObtenerTodos();
                if (_categorias == null || _categorias.Count == 0) return;

                CBCategoria.DataSource = _categorias;
                CBCategoria.DisplayMember = "Descripcion";
                CBCategoria.ValueMember = "Id";
                CBCategoria.SelectedIndex = -1;

                // Filtro de categorías con opción "Todas"
                var categoriasFiltro = new List<CategoriaDto>();
                categoriasFiltro.Add(new CategoriaDto { Id = 0, Descripcion = "(Todas)" });
                categoriasFiltro.AddRange(_categorias);

                CBFiltroCategoria.DataSource = categoriasFiltro;
                CBFiltroCategoria.DisplayMember = "Descripcion";
                CBFiltroCategoria.ValueMember = "Id";
                CBFiltroCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARGA DE PROVEEDORES
        // ============================================================
        private async Task CargarProveedoresAsync()
        {
            try
            {
                var proveedores = await _proveedorLogica.ObtenerTodos();

                // ✅ Solo proveedores activos
                _proveedores = proveedores?.Where(p => p.Estado).ToList() ?? new List<ProveedorDto>();

                // Agregar opción "(Sin proveedor)"
                var proveedoresCombo = new List<ProveedorDto>();
                proveedoresCombo.Add(new ProveedorDto { Id = 0, Nombre = "(Sin proveedor)" });
                proveedoresCombo.AddRange(_proveedores);

                CBProveedor.DataSource = proveedoresCombo;
                CBProveedor.DisplayMember = "Nombre";
                CBProveedor.ValueMember = "Id";
                CBProveedor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARGA DE PRODUCTOS
        // ============================================================
        private async Task CargarProductosAsync()
        {
            try
            {
                _productosOriginales = await _productoLogica.ObtenerTodos();

                if (_productosOriginales == null || _productosOriginales.Count == 0)
                {
                    DGVProductos.Rows.Clear();
                    return;
                }

                MostrarProductos(_productosOriginales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MOSTRAR PRODUCTOS EN LA GRILLA
        // ============================================================
        private void MostrarProductos(List<ProductoDto> productos)
        {
            DGVProductos.Rows.Clear();

            // ✅ Filtrar según _mostrarSoloActivos
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

            AplicarFiltroGrilla();
        }

        // ============================================================
        // SELECCIÓN DE PRODUCTO EN LA GRILLA
        // ============================================================
        private void DGVProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Si es Vendedor o Cajero, solo consulta
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

                // ✅ NUEVO: Cambiar botones a modo edición
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARGAR PRODUCTO EN EL FORMULARIO
        // ============================================================
        private async void CargarProductoEnFormulario(int id)
        {
            try
            {
                var producto = await _productoLogica.ObtenerPorId(id);

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

                // ✅ Cargar categoría
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

                // ✅ Cargar proveedor
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
                    CBProveedor.SelectedIndex = 0; // (Sin proveedor)
                }

                NUDStockActual.Value = producto.StockActual;
                NUDStockMinimo.Value = producto.StockMinimo;
                ChBProductoHabilitado.Checked = producto.Estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // VALIDACIONES
        // ============================================================
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

        // ============================================================
        // BOTÓN GUARDAR (SOLO CREAR)
        // ============================================================
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

            // ✅ Deshabilitar botones durante la operación
            BGuardar.Enabled = false;
            BActualizar.Enabled = false;

            try
            {
                int? idProveedor = ObtenerIdProveedorSeleccionado();

                // ✅ Parsear precios
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
                    PrecioMayorista = precioMayorista
                };

                await _productoLogica.Crear(nuevoProducto);

                MessageBox.Show("Producto creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProductosAsync();
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

        // ============================================================
        // BOTÓN ACTUALIZAR
        // ============================================================
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

            // ✅ Deshabilitar botones durante la operación
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
                    CategoriaId = (int)CBCategoria.SelectedValue
                };

                await _productoLogica.Actualizar(_productoId, actualizarProducto);

                MessageBox.Show("Producto actualizado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProductosAsync();
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

        // ============================================================
        // BOTÓN DESACTIVAR
        // ============================================================
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

                    await CargarProductosAsync();
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

        // ============================================================
        // BOTÓN NUEVO
        // ============================================================
        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            _esEdicion = false;
            _productoId = 0;
            ActualizarBotonesSegunModo();
            TCodigoInterno.Focus();
        }

        // ============================================================
        // BOTÓN NUEVA CATEGORÍA
        // ============================================================
        private async void BNuevaCategoria_Click(object sender, EventArgs e)
        {
            using (FormModalCategoria modal = new FormModalCategoria())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarCategoriasAsync();

                    if (modal.IdCategoriaCreada > 0 && CBCategoria.DataSource != null)
                    {
                        CBCategoria.SelectedValue = modal.IdCategoriaCreada;
                    }
                }
            }
        }

        // ============================================================
        // FILTROS DINÁMICOS
        // ============================================================
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
        }

        // ============================================================
        // BOTÓN QUE ALTERNA ACTIVOS/INACTIVOS
        // ============================================================
        private async void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _mostrarSoloActivos = !_mostrarSoloActivos;
            BLimpiarFiltros.Text = _mostrarSoloActivos ? "Inactivos" : "Activos";
            await CargarProductosAsync();
        }

        // ============================================================
        // LIMPIAR CAMPOS
        // ============================================================
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
                CBProveedor.SelectedIndex = 0; // (Sin proveedor)

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

        // ============================================================
        // HABILITAR/DESHABILITAR BOTONES SEGÚN MODO
        // ============================================================
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

        // ============================================================
        // HELPERS
        // ============================================================
        private int? ObtenerIdProveedorSeleccionado()
        {
            if (CBProveedor.SelectedItem is ProveedorDto prov && prov.Id > 0)
                return prov.Id;

            return null;
        }

        // ============================================================
        // ÍCONOS
        // ============================================================
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