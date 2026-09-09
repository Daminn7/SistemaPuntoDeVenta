using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDatos.DTOs;

namespace CapaPresentacion
{
    public partial class FormProductos : Form
    {
        // ============================================================
        // DECLARACIÓN DE VARIABLES
        // ============================================================
        private readonly ProductoLogica _productoLogica = new ProductoLogica();
        private readonly CategoriaLogica _categoriaLogica = new CategoriaLogica();
        private bool _esEdicion = false;
        private int _productoId = 0;
        private List<CategoriaDto> _categorias;
        private List<ProductoDto> _productosOriginales;

        public FormProductos()
        {
            InitializeComponent();
            AsignarEstiloEIconos();
        }

        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return nuevoBitmap;
        }

        private void AsignarEstiloEIconos()
        {
            BNuevo.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);
            BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
            BEditar.Image = EscalarIcono(Properties.Resources.boton_editar_blanco, 32, 32);
            BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            BLimpiar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
        }

        // ============================================================
        // CARGA DEL FORMULARIO (UNIFICADO)
        // ============================================================
        private async void FormProductos_Load(object sender, EventArgs e)
        {   
            AplicarRestriccionesPorRol();
            // ✅ Cargar datos desde la API
            await CargarCategoriasAsync();
            await CargarProductosAsync();
            ConfigurarEstiloDataGridView();

            // ✅ Lógica de visibilidad por rol (comentada hasta que SesionUsuario esté disponible)
            /*
            if (SesionUsuario.Rol == "Vendedor")
            {
                PTarjetaLateral.Visible = false;
                TLPContenido.ColumnStyles[0].Width = 100F;
                TLPContenido.ColumnStyles[1].Width = 0F;
            }
            */
        }
        private void AplicarRestriccionesPorRol()
        {
            // Accedemos a la clase estática de sesión declarada en FormPrincipal
            string rol = (FormPrincipal.SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();

            if (rol == "VENDEDOR" || rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                // Ocultar tarjeta lateral de carga / modificación
                PTarjetaLateral.Visible = false;

                // Expandir grilla al 100% del ancho del TableLayoutPanel
                TLPContenido.ColumnStyles[0].SizeType = SizeType.Percent;
                TLPContenido.ColumnStyles[0].Width = 100F;
                TLPContenido.ColumnStyles[1].SizeType = SizeType.Percent;
                TLPContenido.ColumnStyles[1].Width = 0F;

                // Bloquear edición en la grilla (solo consulta)
                DGVProductos.ReadOnly = true;
                DGVProductos.AllowUserToAddRows = false;
                DGVProductos.AllowUserToDeleteRows = false;
                DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVProductos.MultiSelect = false;

                // Quitar la selección inicial para que no quede una fila marcada en azul
                DGVProductos.ClearSelection();
                DGVProductos.CurrentCell = null;

                // Cambiar título si el control existe en el diseñador
                Control[] lblTitulo = this.Controls.Find("LTituloPrincipal", true);
                if (lblTitulo.Length > 0)
                {
                    lblTitulo[0].Text = "CATÁLOGO DE PRODUCTOS";
                }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MOSTRAR PRODUCTOS EN EL DATAGRIDVIEW
        // ============================================================
        private void MostrarProductos(List<ProductoDto> productos)
        {
            DGVProductos.Rows.Clear();

            foreach (var producto in productos)
            {
                DGVProductos.Rows.Add(
                    producto.Id,
                    producto.CodigoInterno ?? "",
                    producto.CodBarras ?? "",
                    producto.Nombre ?? "",
                    producto.CategoriaNombre ?? "",
                    producto.ProveedorNombre ?? "",
                    producto.StockActual,
                    producto.StockMinimo,
                    producto.PrecioMinorista.ToString("0.00"),
                    producto.PrecioMayorista?.ToString("0.00") ?? "",
                    producto.Estado ? "Activo" : "Inactivo"
                );
            }
        }

        // ============================================================
        // ESTILO DEL DATAGRIDVIEW
        // ============================================================
        private void ConfigurarEstiloDataGridView()
        {
            DGVProductos.DefaultCellStyle.ForeColor = Color.Black;
            DGVProductos.DefaultCellStyle.BackColor = Color.White;
            DGVProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 131, 53);
            DGVProductos.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            DGVProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            DGVProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
        }

        // ============================================================
        // SELECCIÓN DE PRODUCTO EN EL DATAGRIDVIEW
        // ============================================================
        private void DGVProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Si es Vendedor o Cajero, solo permitimos navegar y visualizar la grilla
            string rol = (FormPrincipal.SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();
            if (rol == "VENDEDOR" || rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                return;
            }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARGAR PRODUCTO EN EL FORMULARIO PARA EDITAR
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

                if (producto.CategoriaId > 0)
                    CBCategoria.SelectedValue = producto.CategoriaId;

                NUDStockActual.Value = producto.StockActual;
                NUDStockMinimo.Value = producto.StockMinimo;
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
            {
                e.Handled = true;
            }
        }

        private bool ValidarCamposProducto()
        {
            if (string.IsNullOrWhiteSpace(TCodigoInterno.Text) || !long.TryParse(TCodigoInterno.Text.Trim(), out _))
            {
                MessageBox.Show("El Código Interno es obligatorio y debe ser exclusivamente numérico.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TCodigoInterno.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(TCodBarras.Text) && !long.TryParse(TCodBarras.Text.Trim(), out _))
            {
                MessageBox.Show("El Código de Barras debe ser numérico.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TCodBarras.Focus();
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
                MessageBox.Show("Ingrese un Precio Minorista válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TPrecioMinorista.Focus();
                return false;
            }

            if (!IntentarConvertirDecimal(TPrecioMayorista.Text, out decimal precioMayorista) || precioMayorista <= 0)
            {
                MessageBox.Show("Ingrese un Precio Mayorista válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (NUDStockMinimo.Value <= 0)
            {
                MessageBox.Show("El Stock Mínimo debe ser de al menos 1 unidad para activar alertas de reposición.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NUDStockMinimo.Focus();
                return false;
            }

            if (NUDStockActual.Value < NUDStockMinimo.Value)
            {
                DialogResult res = MessageBox.Show(
                    "El Stock Actual ingresado es menor al Stock Mínimo requerido.\n¿Desea registrar el producto bajo nivel crítico de reposición?",
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

        private void ValidarDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            if (char.IsControl(e.KeyChar))
            {
                return;
            }

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

        // ============================================================
        // BOTONES
        // ============================================================

        private async void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposProducto())
                return;

            try
            {
                var producto = new CrearProductoDto
                {
                    CodigoInterno = TCodigoInterno.Text.Trim(),
                    CodBarras = string.IsNullOrWhiteSpace(TCodBarras.Text) ? null : TCodBarras.Text.Trim(),
                    Nombre = TNombreProducto.Text.Trim(),
                    Descripcion = TDescripcion.Text.Trim(),
                    CategoriaId = (int)CBCategoria.SelectedValue,
                    ProveedorId = null,
                    StockActual = (int)NUDStockActual.Value,
                    StockMinimo = (int)NUDStockMinimo.Value,
                    StockMaximo = 1000,
                    Costo = 0,
                    PrecioMinorista = decimal.Parse(TPrecioMinorista.Text.Replace(',', '.'),
                        System.Globalization.CultureInfo.InvariantCulture),
                    PrecioMayorista = string.IsNullOrWhiteSpace(TPrecioMayorista.Text) ? (decimal?)null :
                        decimal.Parse(TPrecioMayorista.Text.Replace(',', '.'),
                        System.Globalization.CultureInfo.InvariantCulture)
                };

                if (_esEdicion)
                {
                    var actualizarProducto = new ActualizarProductoDto
                    {
                        Nombre = producto.Nombre,
                        CodBarras = producto.CodBarras,
                        CodigoInterno = producto.CodigoInterno,
                        Descripcion = producto.Descripcion,
                        Costo = producto.Costo,
                        PrecioMinorista = producto.PrecioMinorista,
                        PrecioMayorista = producto.PrecioMayorista,
                        StockActual = producto.StockActual,
                        StockMinimo = producto.StockMinimo,
                        StockMaximo = producto.StockMaximo,
                        ProveedorId = producto.ProveedorId,
                        CategoriaId = producto.CategoriaId,
                        Estado = true
                    };
                    await _productoLogica.Actualizar(_productoId, actualizarProducto);
                    MessageBox.Show("Producto actualizado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _productoLogica.Crear(producto);
                    MessageBox.Show("Producto creado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await CargarProductosAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (DGVProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var idValue = DGVProductos.SelectedRows[0].Cells[0].Value;
                if (idValue != null && idValue != DBNull.Value)
                {
                    _productoId = Convert.ToInt32(idValue);
                    _esEdicion = true;
                    CargarProductoEnFormulario(_productoId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (DGVProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para desactivar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var idValue = DGVProductos.SelectedRows[0].Cells[0].Value;
                if (idValue == null || idValue == DBNull.Value)
                {
                    MessageBox.Show("No se pudo obtener el ID del producto.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(idValue);
                string nombre = DGVProductos.SelectedRows[0].Cells[3].Value?.ToString() ?? "";

                if (MessageBox.Show($"¿Desea desactivar el producto '{nombre}'?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await _productoLogica.Eliminar(id);
                    MessageBox.Show("Producto desactivado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProductosAsync();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            CBCategoria.SelectedIndex = -1;
            NUDStockActual.Value = 0;
            NUDStockMinimo.Value = 1;
            _esEdicion = false;
            _productoId = 0;
            TCodigoInterno.Focus();
        }

        private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVProductos.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}