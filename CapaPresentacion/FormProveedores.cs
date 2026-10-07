using CapaDatos.DTOs;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormProveedores : Form
    {
        // ============================================================
        // DECLARACIÓN DE VARIABLES
        // ============================================================
        private readonly ProveedorLogica _proveedorLogica = new ProveedorLogica();
        private readonly TablasMaestrasLogica _tablasLogica = new TablasMaestrasLogica();

        private int _idProveedorSeleccionado = 0;
        private bool _esEdicion = false;

        private List<ProvinciaDto> _provincias;
        private List<LocalidadDto> _localidades;

        // ✅ NUEVO: Controla qué proveedores se muestran (true = activos, false = inactivos)
        private bool _mostrarSoloActivos = true;

        // ✅ NUEVO: Bandera para el formateo del CUIT en vivo
        private bool _actualizandoCuit = false;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public FormProveedores()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        // ============================================================
        // CARGA DEL FORMULARIO
        // ✅ MODIFICADO: Ahora carga de la API
        // ============================================================
        private async void FormProveedores_Load(object sender, EventArgs e)
        {
            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = GenerarIconoProveedores(Color.FromArgb(212, 131, 53));

            AsignarEstiloEIconos();
            await CargarProvinciasAsync();
            await CargarProveedoresAsync();
            LimpiarFormulario();
            ActualizarBotonesSegunModo();

            BLimpiarFiltros.Text = "Inactivos";
        }

        // ============================================================
        // ✅ NUEVO: Carga las provincias desde la API
        // ============================================================
        private async Task CargarProvinciasAsync()
        {
            try
            {
                _provincias = await _tablasLogica.GetProvincias();

                CBProvincia.DataSource = _provincias;
                CBProvincia.DisplayMember = "Descripcion";
                CBProvincia.ValueMember = "Id";
                CBProvincia.SelectedIndex = -1;

                CBFiltroLocalidad.Items.Clear();
                CBFiltroLocalidad.Items.Add("(Todas)");
                CBFiltroLocalidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar provincias: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ✅ NUEVO: Carga los proveedores desde la API
        // ============================================================
        private async Task CargarProveedoresAsync()
        {
            try
            {
                var proveedores = await _proveedorLogica.ObtenerTodos();

                DGVProveedores.Rows.Clear();
                if (proveedores == null || proveedores.Count == 0) return;

                // ✅ Filtrar según _mostrarSoloActivos
                var filtrados = proveedores
                    .Where(p => _mostrarSoloActivos ? p.Estado : !p.Estado)
                    .ToList();

                foreach (var p in filtrados)
                {
                    string nombreCompleto = $"{p.Nombre ?? ""} {p.Apellido ?? ""}".Trim();
                    string estadoMostrar = p.Estado ? "Habilitado" : "Deshabilitado";

                    DGVProveedores.Rows.Add(
                        p.Id,                  // Columna 0: ID (oculta)
                        p.CuilCuit ?? "",      // Columna 1: ColCuit
                        nombreCompleto,        // Columna 2: ColRazonSocial
                        p.Nombre ?? "",        // Columna 3: ColContacto
                        p.Telefono ?? "",      // Columna 4: ColTelefono
                        p.Email ?? "",         // Columna 5: ColEmail
                        p.Localidad ?? "",     // Columna 6: ColLocalidad
                        p.Direccion ?? "",     // Columna 7: ColDireccion
                        estadoMostrar          // Columna 8: ColEstado
                    );
                }

                AplicarFiltroGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // Ícono vectorial
        // ============================================================
        private Image GenerarIconoProveedores(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 3.5f, 8.5f, 15f, 12f);
                    PointF[] cabina = new PointF[]
                    {
                        new PointF(18.5f, 12.5f),
                        new PointF(23.5f, 12.5f),
                        new PointF(27.5f, 16.5f),
                        new PointF(27.5f, 20.5f),
                        new PointF(18.5f, 20.5f)
                    };
                    g.DrawLines(pen, cabina);
                    g.DrawLine(pen, 20.5f, 14.5f, 24.5f, 14.5f);
                    g.FillEllipse(brush, 6.5f, 20.5f, 5f, 5f);
                    g.FillEllipse(brush, 21.5f, 20.5f, 5f, 5f);
                }
            }
            return bmp;
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

        // ============================================================
        // 2. RESTRICCIONES DE TECLADO Y FILTRADO
        // ============================================================
        private void InicializarComportamiento()
        {
            // CUIT: solo dígitos y guiones, con formateo en vivo
            TBCuit.MaxLength = 15;
            TBCuit.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
                    e.Handled = true;
            };
            ConfigurarFormateoCuitEnVivo();

            // Teléfono: solo dígitos, '+' opcional al inicio
            TBTelefono.MaxLength = 18;
            TBTelefono.KeyPress += (s, e) =>
            {
                if (char.IsControl(e.KeyChar)) return;
                if (e.KeyChar == '+' && TBTelefono.SelectionStart == 0 && !TBTelefono.Text.Contains("+"))
                    return;
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // Nombre / Razón social: solo letras, números, espacios y puntos
            TBRazonSocial.KeyPress += SoloLetrasYNumerosYEspacios_KeyPress;
            TBContacto.KeyPress += SoloLetrasYEspacios_KeyPress;

            // Validación de email en vivo
            ConfigurarValidacionEmailEnVivo();

            // Cascada provincia → localidad desde la API
            ConfigurarCascadaProvincias();

            // Filtros dinámicos
            ConfigurarFiltrosDinamicos();
        }

        // ✅ Formateo CUIT en vivo (XX-XXXXXXXX-X)
        private void ConfigurarFormateoCuitEnVivo()
        {
            TBCuit.TextChanged += (s, e) =>
            {
                if (_actualizandoCuit) return;

                string digitos = new string(TBCuit.Text.Where(char.IsDigit).ToArray());
                if (digitos.Length > 11) digitos = digitos.Substring(0, 11);

                string textoFormateado = digitos;
                if (digitos.Length > 10)
                {
                    textoFormateado = $"{digitos.Substring(0, 2)}-{digitos.Substring(2, 8)}-{digitos.Substring(10, 1)}";
                }
                else if (digitos.Length > 2)
                {
                    textoFormateado = $"{digitos.Substring(0, 2)}-{digitos.Substring(2)}";
                }

                _actualizandoCuit = true;
                TBCuit.Text = textoFormateado;
                TBCuit.SelectionStart = TBCuit.Text.Length;
                _actualizandoCuit = false;
            };
        }

        // ✅ Validación de email en vivo
        private void ConfigurarValidacionEmailEnVivo()
        {
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            TBEmail.TextChanged += (s, e) =>
            {
                string email = TBEmail.Text.Trim();
                if (string.IsNullOrEmpty(email))
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                    return;
                }
                TBEmail.ForeColor = Regex.IsMatch(email, patronEmail)
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(38, 40, 44);
            };

            TBEmail.Leave += (s, e) =>
            {
                string email = TBEmail.Text.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    TBEmail.ForeColor = Color.FromArgb(192, 57, 43);
                    LEmail.Text = "Correo Electrónico * (Obligatorio)";
                    LEmail.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else if (!Regex.IsMatch(email, patronEmail))
                {
                    TBEmail.ForeColor = Color.FromArgb(192, 57, 43);
                    LEmail.Text = "Correo Electrónico (Formato: ej@dominio.com)";
                    LEmail.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                    LEmail.Text = "Correo Electrónico:";
                    LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                }
            };

            TBEmail.Enter += (s, e) =>
            {
                LEmail.Text = "Correo Electrónico:";
                LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
            };
        }

        private void SoloLetrasYEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void SoloLetrasYNumerosYEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                e.Handled = true;
        }

        // ✅ Cascada provincia → localidad desde la API
        private void ConfigurarCascadaProvincias()
        {
            CBProvincia.SelectedIndexChanged += async (s, e) =>
            {
                try
                {
                    if (CBProvincia.SelectedItem == null)
                    {
                        CBLocalidad.DataSource = null;
                        CBLocalidad.Items.Clear();
                        return;
                    }

                    if (CBProvincia.SelectedItem is ProvinciaDto provincia)
                    {
                        await CargarLocalidadesPorProvinciaAsync(provincia.Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en cascada: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private async Task CargarLocalidadesPorProvinciaAsync(int idProvincia)
        {
            try
            {
                _localidades = await _tablasLogica.GetLocalidadesByProvincia(idProvincia);
                if (_localidades == null || _localidades.Count == 0)
                {
                    CBLocalidad.DataSource = null;
                    CBLocalidad.Items.Clear();
                    return;
                }

                CBLocalidad.DataSource = _localidades;
                CBLocalidad.DisplayMember = "Descripcion";
                CBLocalidad.ValueMember = "Id";
                CBLocalidad.SelectedIndex = -1;

                // ✅ También actualizamos el combo de filtro
                CBFiltroLocalidad.Items.Clear();
                CBFiltroLocalidad.Items.Add("(Todas)");
                foreach (var loc in _localidades)
                    CBFiltroLocalidad.Items.Add(loc.Descripcion);
                CBFiltroLocalidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarFiltrosDinamicos()
        {
            TBBuscar.TextChanged += (s, e) => AplicarFiltroGrilla();
            CBFiltroLocalidad.SelectedIndexChanged += (s, e) => AplicarFiltroGrilla();
            BLimpiarFiltros.Click += BLimpiarFiltros_Click;
        }

        private void AplicarFiltroGrilla()
        {
            string texto = TBBuscar.Text.Trim().ToLower();
            string localidadFiltro = CBFiltroLocalidad.Text;

            bool filtrarPorLocalidad = !string.IsNullOrEmpty(localidadFiltro) && localidadFiltro != "(Todas)";

            foreach (DataGridViewRow row in DGVProveedores.Rows)
            {
                if (row.IsNewRow) continue;

                string cuit = row.Cells["ColCuit"].Value?.ToString().ToLower() ?? "";
                string razon = row.Cells["ColRazonSocial"].Value?.ToString().ToLower() ?? "";
                string contacto = row.Cells["ColContacto"].Value?.ToString().ToLower() ?? "";
                string localidad = row.Cells["ColLocalidad"].Value?.ToString() ?? "";

                bool coincideTexto = string.IsNullOrEmpty(texto) ||
                                     cuit.Contains(texto) ||
                                     razon.Contains(texto) ||
                                     contacto.Contains(texto);

                bool coincideLocalidad = !filtrarPorLocalidad ||
                                         localidad.Equals(localidadFiltro, StringComparison.OrdinalIgnoreCase);

                row.Visible = coincideTexto && coincideLocalidad;
            }
        }

        // ============================================================
        // BOTÓN QUE ALTERNA ACTIVOS/INACTIVOS
        // ============================================================
        private async void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _mostrarSoloActivos = !_mostrarSoloActivos;
            BLimpiarFiltros.Text = _mostrarSoloActivos ? "Inactivos" : "Activos";
            await CargarProveedoresAsync();
        }

        // ============================================================
        // VALIDACIÓN
        // ============================================================
        private bool ValidarFormulario(out string mensajeError)
        {
            mensajeError = string.Empty;

            // CUIT obligatorio, 11 dígitos
            string cuitDigitos = new string(TBCuit.Text.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(TBCuit.Text) || cuitDigitos.Length != 11)
            {
                mensajeError = "Debe ingresar un CUIT válido (11 dígitos, formato XX-XXXXXXXX-X).";
                TBCuit.Focus();
                return false;
            }

            // Razón social obligatoria
            if (string.IsNullOrWhiteSpace(TBRazonSocial.Text))
            {
                mensajeError = "Debe ingresar la Razón Social del proveedor.";
                TBRazonSocial.Focus();
                return false;
            }

            // Email obligatorio y válido
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(TBEmail.Text.Trim()) ||
                !Regex.IsMatch(TBEmail.Text.Trim(), patronEmail))
            {
                mensajeError = "Debe ingresar un Correo Electrónico válido.";
                TBEmail.Focus();
                return false;
            }

            // Provincia obligatoria si se carga dirección
            if (!string.IsNullOrWhiteSpace(TBCalle.Text) && CBProvincia.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Provincia.";
                CBProvincia.Focus();
                return false;
            }

            // Localidad obligatoria si se carga dirección
            if (!string.IsNullOrWhiteSpace(TBCalle.Text) && CBLocalidad.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Localidad.";
                CBLocalidad.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // BOTONES DE ACCIÓN
        // ✅ MODIFICADO: Deshabilitar botones durante la operación
        // ============================================================
        private async void BGuardar_Click(object sender, EventArgs e)
        {
            if (_esEdicion)
            {
                MessageBox.Show("Está en modo edición. Use el botón 'Actualizar'.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(error, "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ NUEVO: Deshabilitar botones durante el guardado
            BGuardar.Enabled = false;
            BActualizar.Enabled = false;

            try
            {
                string telCompleto = TBTelefono.Text.Trim();
                string caracteristica = "";
                long numero = 0;

                if (!string.IsNullOrEmpty(telCompleto))
                {
                    string digitosTel = new string(telCompleto.Where(char.IsDigit).ToArray());
                    if (digitosTel.Length > 7)
                    {
                        caracteristica = digitosTel.Substring(0, digitosTel.Length - 7);
                        long.TryParse(digitosTel.Substring(digitosTel.Length - 7), out numero);
                    }
                    else
                    {
                        long.TryParse(digitosTel, out numero);
                    }
                }

                var nuevo = new CrearProveedorDto
                {
                    Nombre = TBRazonSocial.Text.Trim(),
                    Apellido = TBContacto.Text.Trim(),
                    CuilCuit = TBCuit.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    Estado = ChBProveedorHabilitado.Checked,
                    Direccion = new DireccionCrearDto
                    {
                        Calle = TBCalle.Text.Trim(),
                        Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                        Edificio = null,
                        Piso = null,
                        Departamento = "",
                        Descripcion = null,
                        LocalidadId = CBLocalidad.SelectedValue != null ? (int)CBLocalidad.SelectedValue : 0
                    },
                    Telefono = !string.IsNullOrEmpty(telCompleto) ? new TelefonoCrearDto
                    {
                        Caracteristica = caracteristica,
                        Numero = numero
                    } : null
                };

                await _proveedorLogica.Crear(nuevo);

                MessageBox.Show("Proveedor creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarProveedoresAsync();
                LimpiarFormulario();

                // ✅ NUEVO: Actualización explícita del estado de botones
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // ✅ Rehabilitar botones en caso de error
                BGuardar.Enabled = true;
                BActualizar.Enabled = false;
            }
        }

        private async void BActualizar_Click(object sender, EventArgs e)
        {
            if (!_esEdicion || _idProveedorSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un proveedor de la grilla para actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(error, "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ NUEVO: Deshabilitar botones durante la operación
            BGuardar.Enabled = false;
            BActualizar.Enabled = false;

            try
            {
                string telCompleto = TBTelefono.Text.Trim();
                string caracteristica = "";
                long numero = 0;

                if (!string.IsNullOrEmpty(telCompleto))
                {
                    string digitosTel = new string(telCompleto.Where(char.IsDigit).ToArray());
                    if (digitosTel.Length > 7)
                    {
                        caracteristica = digitosTel.Substring(0, digitosTel.Length - 7);
                        long.TryParse(digitosTel.Substring(digitosTel.Length - 7), out numero);
                    }
                    else
                    {
                        long.TryParse(digitosTel, out numero);
                    }
                }

                var actualizar = new CrearProveedorDto
                {
                    Nombre = TBRazonSocial.Text.Trim(),
                    Apellido = TBContacto.Text.Trim(),
                    CuilCuit = TBCuit.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    Estado = ChBProveedorHabilitado.Checked,
                    Direccion = new DireccionCrearDto
                    {
                        Calle = TBCalle.Text.Trim(),
                        Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                        Edificio = null,
                        Piso = null,
                        Departamento = "",
                        Descripcion = null,
                        LocalidadId = CBLocalidad.SelectedValue != null ? (int)CBLocalidad.SelectedValue : 0
                    },
                    Telefono = !string.IsNullOrEmpty(telCompleto) ? new TelefonoCrearDto
                    {
                        Caracteristica = caracteristica,
                        Numero = numero
                    } : null
                };

                await _proveedorLogica.Actualizar(_idProveedorSeleccionado, actualizar);

                MessageBox.Show("Proveedor actualizado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarProveedoresAsync();
                LimpiarFormulario();

                // ✅ NUEVO: Actualización explícita del estado de botones
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // ✅ Rehabilitar botones en caso de error (mantener modo edición)
                BGuardar.Enabled = false;
                BActualizar.Enabled = true;
            }
        }

        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (_idProveedorSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un proveedor de la grilla para dar de baja.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de dar de baja a este proveedor?",
                "Dar de Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // ✅ NUEVO: Deshabilitar botones durante la operación
                BGuardar.Enabled = false;
                BActualizar.Enabled = false;
                BDesactivar.Enabled = false;

                try
                {
                    await _proveedorLogica.Eliminar(_idProveedorSeleccionado);
                    MessageBox.Show("Proveedor dado de baja exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProveedoresAsync();
                    LimpiarFormulario();
                    BDesactivar.Enabled = true;

                    // ✅ NUEVO: Actualización explícita del estado de botones
                    ActualizarBotonesSegunModo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al dar de baja: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // ✅ Rehabilitar botones en caso de error
                    BDesactivar.Enabled = true;
                    ActualizarBotonesSegunModo();
                }
            }
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            _esEdicion = false;
            _idProveedorSeleccionado = 0;
            ActualizarBotonesSegunModo();
            TBCuit.Focus();
        }

        // ============================================================
        // SELECCIÓN EN LA GRILLA
        // ============================================================
        private async void DGVProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var fila = DGVProveedores.Rows[e.RowIndex];
                int id = Convert.ToInt32(fila.Cells["ColIdProveedor"].Value ?? 0);

                _idProveedorSeleccionado = id;
                _esEdicion = true;

                var proveedor = await _proveedorLogica.ObtenerPorId(id);
                if (proveedor != null)
                {
                    TBRazonSocial.Text = proveedor.Nombre ?? "";
                    TBContacto.Text = proveedor.Apellido ?? "";
                    TBCuit.Text = proveedor.CuilCuit ?? "";
                    TBEmail.Text = proveedor.Email ?? "";
                    TBTelefono.Text = proveedor.Telefono ?? "";

                    // ✅ Cargar dirección
                    string dir = proveedor.Direccion ?? "";
                    if (!string.IsNullOrEmpty(dir))
                    {
                        int lastSpace = dir.LastIndexOf(' ');
                        if (lastSpace > 0 && int.TryParse(dir.Substring(lastSpace + 1), out _))
                        {
                            TBCalle.Text = dir.Substring(0, lastSpace);
                            TBNro.Text = dir.Substring(lastSpace + 1);
                        }
                        else
                        {
                            TBCalle.Text = dir;
                            TBNro.Clear();
                        }
                    }
                    else
                    {
                        TBCalle.Clear();
                        TBNro.Clear();
                    }

                    // ✅ Cargar provincia y localidad
                    if (proveedor.LocalidadId > 0)
                    {
                        var localidad = _localidades?.FirstOrDefault(l => l.Id == proveedor.LocalidadId);

                        if (localidad == null)
                        {
                            foreach (var prov in _provincias)
                            {
                                var locs = await _tablasLogica.GetLocalidadesByProvincia(prov.Id);
                                localidad = locs.FirstOrDefault(l => l.Id == proveedor.LocalidadId);
                                if (localidad != null)
                                {
                                    CBProvincia.SelectedValue = prov.Id;
                                    await Task.Delay(200);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            var provincia = _provincias?.FirstOrDefault(p => p.Id == localidad.ProvinciaId);
                            if (provincia != null)
                                CBProvincia.SelectedValue = provincia.Id;

                            await Task.Delay(300);
                        }

                        if (localidad != null && CBLocalidad.DataSource != null)
                            CBLocalidad.SelectedValue = proveedor.LocalidadId;
                    }

                    ChBProveedorHabilitado.Checked = proveedor.Estado;
                }

                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // LIMPIAR FORMULARIO
        // ============================================================
        private void LimpiarFormulario()
        {
            _idProveedorSeleccionado = 0;
            _esEdicion = false;

            TBCuit.Clear();
            TBRazonSocial.Clear();
            TBContacto.Clear();
            TBTelefono.Clear();
            TBEmail.Clear();
            TBCalle.Clear();
            TBNro.Clear();

            CBProvincia.SelectedIndex = -1;
            CBLocalidad.DataSource = null;
            CBLocalidad.Items.Clear();

            ChBProveedorHabilitado.Checked = true;

            // ✅ Restaurar color del label de email
            TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
            LEmail.Text = "Correo Electrónico:";
            LEmail.ForeColor = Color.FromArgb(70, 70, 70);

            DGVProveedores.ClearSelection();
            if (DGVProveedores.CurrentCell != null)
                DGVProveedores.CurrentCell = null;

            // ✅ Asegurar botón Dar de Baja habilitado por defecto
            BDesactivar.Enabled = true;

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
    }
}