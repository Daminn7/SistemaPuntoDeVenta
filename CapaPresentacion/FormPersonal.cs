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
    public partial class FormPersonal : Form
    {
        // ============================================================
        // DECLARACIÓN DE VARIABLES
        // ============================================================
        private readonly PersonalLogica _personalLogica = new PersonalLogica();
        private readonly TablasMaestrasLogica _tablasLogica = new TablasMaestrasLogica();

        private int _idPersonalSeleccionado = 0;
        private bool _esEdicion = false;

        private List<PerfilDto> _perfiles;

        private bool _mostrarSoloActivos = true;

        // ✅ NUEVO: Bandera para el formateo del CUIL en vivo (evita loop infinito)
        private bool _actualizandoCuil = false;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public FormPersonal()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        // ============================================================
        // CARGA DEL FORMULARIO
        // ============================================================
        private async void FormPersonal_Load(object sender, EventArgs e)
        {
            AsignarEstiloEIconos();
            await CargarPerfilesAsync();
            await CargarPersonalAsync();
            LimpiarFormulario();
            ActualizarBotonesSegunModo();

            BLimpiarFiltros.Text = "Inactivos";
        }

        // ============================================================
        // Carga la lista de perfiles desde la API
        // ============================================================
        private async Task CargarPerfilesAsync()
        {
            try
            {
                _perfiles = await _tablasLogica.GetPerfiles();

                // ✅ Configurar el combo de roles del formulario
                CBRol.DataSource = _perfiles;
                CBRol.DisplayMember = "Nombre";
                CBRol.ValueMember = "Id";
                CBRol.SelectedIndex = -1;

                // ✅ Combo de filtro con opción "Todos"
                var perfilesFiltro = new List<PerfilDto>();
                perfilesFiltro.Add(new PerfilDto { Id = 0, Nombre = "(Todos)" });
                perfilesFiltro.AddRange(_perfiles);

                CBFiltroRol.DataSource = perfilesFiltro;
                CBFiltroRol.DisplayMember = "Nombre";
                CBFiltroRol.ValueMember = "Id";
                CBFiltroRol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar perfiles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // Carga el personal desde la API
        // ============================================================
        private async Task CargarPersonalAsync()
        {
            try
            {
                var personal = await _personalLogica.ObtenerTodos();

                DGVPersonal.Rows.Clear();
                if (personal == null || personal.Count == 0) return;

                var filtrados = personal
                    .Where(p => _mostrarSoloActivos ? p.Estado : !p.Estado)
                    .ToList();

                foreach (var p in filtrados)
                {
                    string nombreCompleto = $"{p.Nombre ?? ""} {p.Apellido ?? ""}".Trim();
                    string estadoMostrar = p.Estado ? "Habilitado" : "Deshabilitado";

                    DGVPersonal.Rows.Add(
                        p.IdPersonal,          // Columna 0: ID (oculta)
                        p.Dni ?? "",           // Columna 1: ColDni
                        p.CuilCuit ?? "",      // Columna 2: ColCuil
                        nombreCompleto,        // Columna 3: ColNombreCompleto
                        p.Perfil ?? "",        // Columna 4: ColRol
                        p.Telefono ?? "",      // Columna 5: ColTelefono
                        p.Email ?? "",         // Columna 6: ColEmail
                        estadoMostrar          // Columna 7: ColEstado
                    );
                }

                AplicarFiltroGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar personal: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 1. ÍCONO VECTORIAL DE PERSONAL Y ESCALADO DE BOTONERA
        // ============================================================
        private Image GenerarIconoPersonal(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 4.5f, 5.5f, 23f, 22f);
                    g.DrawLine(pen, 12f, 8.5f, 20f, 8.5f);
                    g.FillEllipse(brush, 12.5f, 11f, 7f, 7f);
                    PointF[] busto = new PointF[]
                    {
                        new PointF(9.5f, 23.5f),
                        new PointF(12f, 19.5f),
                        new PointF(20f, 19.5f),
                        new PointF(22.5f, 23.5f)
                    };
                    g.DrawLines(pen, busto);
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
                if (PBIconoTitulo != null)
                    PBIconoTitulo.Image = GenerarIconoPersonal(Color.FromArgb(212, 131, 53));

                BNuevo.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);
                BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BActualizar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
                BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch { }
        }

        // ============================================================
        // 2. RESTRICCIONES DE TECLADO Y FILTRADO
        // ✅ MODIFICADO: Se agregaron todas las restricciones de FormClientes
        // ============================================================
        private void InicializarComportamiento()
        {
            // ============================================================
            // DNI: solo dígitos, máximo 8
            // ============================================================
            TBDni.MaxLength = 8;
            TBDni.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };

            // ============================================================
            // ✅ NUEVO: CUIL/CUIT: solo dígitos y guiones, con formateo en vivo
            //    MaxLength = 15 para permitir el formateo XX-XXXXXXXX-X
            // ============================================================
            TBCuil.MaxLength = 15;
            TBCuil.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
                    e.Handled = true;
            };
            ConfigurarFormateoCuilEnVivo();

            // ============================================================
            // Teléfono: dígitos continuos y '+' opcional al principio
            // ============================================================
            TBTelefono.MaxLength = 18;
            TBTelefono.KeyPress += (s, e) =>
            {
                if (char.IsControl(e.KeyChar)) return;
                if (e.KeyChar == '+' && TBTelefono.SelectionStart == 0 && !TBTelefono.Text.Contains("+"))
                    return;
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // ============================================================
            // ✅ NUEVO: Nombre y Apellido: solo letras y espacios
            // ============================================================
            TBNombre.KeyPress += SoloLetrasYEspacios_KeyPress;
            TBApellido.KeyPress += SoloLetrasYEspacios_KeyPress;

            // ============================================================
            // ✅ NUEVO: CodUsuario: máximo 7 caracteres (límite de la API)
            // ============================================================
            TBUsuario.MaxLength = 7;

            // ============================================================
            // ✅ NUEVO: Validación de email en vivo (verde/rojo)
            // ============================================================
            ConfigurarValidacionEmailEnVivo();

            // ============================================================
            // Filtros dinámicos de la grilla
            // ============================================================
            ConfigurarFiltrosDinamicos();
        }

        // ============================================================
        // ✅ NUEVO: Restricción solo letras y espacios
        // ============================================================
        private void SoloLetrasYEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        // ============================================================
        // ✅ NUEVO: Formateo CUIL en vivo (XX-XXXXXXXX-X)
        // ============================================================
        private void ConfigurarFormateoCuilEnVivo()
        {
            TBCuil.TextChanged += (s, e) =>
            {
                if (_actualizandoCuil) return;

                string digitos = new string(TBCuil.Text.Where(char.IsDigit).ToArray());
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

                _actualizandoCuil = true;
                TBCuil.Text = textoFormateado;
                TBCuil.SelectionStart = TBCuil.Text.Length;
                _actualizandoCuil = false;
            };
        }

        // ============================================================
        // ✅ NUEVO: Validación de email en vivo (verde si es válido, rojo si no)
        // ============================================================
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
                TBEmail.ForeColor = System.Text.RegularExpressions.Regex.IsMatch(email, patronEmail)
                    ? Color.FromArgb(39, 174, 96)   // Verde si es válido
                    : Color.FromArgb(38, 40, 44);   // Color normal si no
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
                else if (!System.Text.RegularExpressions.Regex.IsMatch(email, patronEmail))
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

        private void ConfigurarFiltrosDinamicos()
        {
            TBBuscar.TextChanged += (s, e) => AplicarFiltroGrilla();
            CBFiltroRol.SelectedIndexChanged += (s, e) => AplicarFiltroGrilla();
            BLimpiarFiltros.Click += BLimpiarFiltros_Click;
        }

        // ============================================================
        // Filtro sobre la grilla (texto + rol)
        // ============================================================
        private void AplicarFiltroGrilla()
        {
            string texto = TBBuscar.Text.Trim().ToLower();
            string rolFiltro = (CBFiltroRol.SelectedItem as PerfilDto)?.Nombre ?? "";

            bool filtrarPorRol = !string.IsNullOrEmpty(rolFiltro) && rolFiltro != "(Todos)";

            foreach (DataGridViewRow row in DGVPersonal.Rows)
            {
                if (row.IsNewRow) continue;

                string dni = row.Cells["ColDni"].Value?.ToString().ToLower() ?? "";
                string nombre = row.Cells["ColNombreCompleto"].Value?.ToString().ToLower() ?? "";
                string rol = row.Cells["ColRol"].Value?.ToString() ?? "";

                bool coincideTexto = string.IsNullOrEmpty(texto) ||
                                     dni.Contains(texto) ||
                                     nombre.Contains(texto);

                bool coincideRol = !filtrarPorRol ||
                                   rol.Equals(rolFiltro, StringComparison.OrdinalIgnoreCase);

                row.Visible = coincideTexto && coincideRol;
            }
        }

        // ============================================================
        // Botón que alterna entre activos e inactivos
        // ============================================================
        private async void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _mostrarSoloActivos = !_mostrarSoloActivos;
            BLimpiarFiltros.Text = _mostrarSoloActivos ? "Inactivos" : "Activos";
            await CargarPersonalAsync();
        }

        // ============================================================
        // 3. VALIDACIÓN
        // ============================================================
        private bool ValidarFormulario(out string mensajeError)
        {
            mensajeError = string.Empty;

            // DNI
            if (string.IsNullOrWhiteSpace(TBDni.Text) || TBDni.Text.Length < 7 || !TBDni.Text.All(char.IsDigit))
            {
                mensajeError = "Debe ingresar un DNI válido (mínimo 7 u 8 dígitos).";
                TBDni.Focus();
                return false;
            }

            // Nombre
            if (string.IsNullOrWhiteSpace(TBNombre.Text))
            {
                mensajeError = "Debe ingresar el nombre del personal.";
                TBNombre.Focus();
                return false;
            }

            // Apellido
            if (string.IsNullOrWhiteSpace(TBApellido.Text))
            {
                mensajeError = "Debe ingresar el apellido del personal.";
                TBApellido.Focus();
                return false;
            }

            // Email
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(TBEmail.Text.Trim()) ||
                !System.Text.RegularExpressions.Regex.IsMatch(TBEmail.Text.Trim(), patronEmail))
            {
                mensajeError = "Debe ingresar un Correo Electrónico válido (ejemplo: usuario@dominio.com).";
                TBEmail.Focus();
                return false;
            }

            // CUIL/CUIT (opcional pero si se ingresa debe tener 11 dígitos)
            if (!string.IsNullOrWhiteSpace(TBCuil.Text))
            {
                string digitosCuil = new string(TBCuil.Text.Where(char.IsDigit).ToArray());
                if (digitosCuil.Length != 11)
                {
                    mensajeError = "El CUIL/CUIT debe contener 11 dígitos (formato: XX-XXXXXXXX-X).";
                    TBCuil.Focus();
                    return false;
                }
            }

            // Rol
            if (CBRol.SelectedIndex == -1 || CBRol.SelectedValue == null || (int)CBRol.SelectedValue <= 0)
            {
                mensajeError = "Debe seleccionar un Rol válido para el usuario.";
                CBRol.Focus();
                return false;
            }

            // CodUsuario
            if (string.IsNullOrWhiteSpace(TBUsuario.Text))
            {
                mensajeError = "Debe asignar un nombre de usuario para el login.";
                TBUsuario.Focus();
                return false;
            }

            if (TBUsuario.Text.Trim().Length > 7)
            {
                mensajeError = "El nombre de usuario (CodUsuario) no puede tener más de 7 caracteres.";
                TBUsuario.Focus();
                return false;
            }

            // Contraseña (solo al crear)
            if (!_esEdicion && string.IsNullOrWhiteSpace(TBPassword.Text))
            {
                mensajeError = "Debe asignar una contraseña para el nuevo usuario.";
                TBPassword.Focus();
                return false;
            }

            // Regla: el admin no puede revocarse privilegios a sí mismo
            if (_idPersonalSeleccionado > 0 &&
                _idPersonalSeleccionado == SesionUsuario.IdUsuario)
            {
                if (CBRol.Text != "Administrador")
                {
                    mensajeError = "No puede revocar sus propios privilegios de ADMINISTRADOR mientras mantenga la sesión activa.";
                    CBRol.Text = "Administrador";
                    return false;
                }

                if (!ChBUsuarioHabilitado.Checked)
                {
                    mensajeError = "No puede deshabilitar su propia cuenta mientras esté en sesión.";
                    ChBUsuarioHabilitado.Checked = true;
                    return false;
                }
            }

            return true;
        }

        // ============================================================
        // 4. ACCIONES DE BOTONES
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
                MessageBox.Show(error, "Validación de Personal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nuevo = new CrearPersonalDto
                {
                    Nombre = TBNombre.Text.Trim(),
                    Apellido = TBApellido.Text.Trim(),
                    Dni = TBDni.Text.Trim(),
                    CuilCuit = TBCuil.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    CodUsuario = TBUsuario.Text.Trim(),
                    Contrasena = TBPassword.Text,
                    PerfilId = CBRol.SelectedValue != null ? (int?)CBRol.SelectedValue : null,
                    EsPersonal = true
                };

                await _personalLogica.Crear(nuevo);

                MessageBox.Show("Personal creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarPersonalAsync();
                LimpiarFormulario();
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BActualizar_Click(object sender, EventArgs e)
        {
            if (!_esEdicion || _idPersonalSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un usuario de la grilla para actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(error, "Validación de Personal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var actualizar = new ActualizarPersonalDto
                {
                    Nombre = TBNombre.Text.Trim(),
                    Apellido = TBApellido.Text.Trim(),
                    Dni = TBDni.Text.Trim(),
                    CuilCuit = TBCuil.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    CodUsuario = TBUsuario.Text.Trim(),
                    PerfilId = CBRol.SelectedValue != null ? (int?)CBRol.SelectedValue : null,
                    Estado = ChBUsuarioHabilitado.Checked
                };

                if (!string.IsNullOrWhiteSpace(TBPassword.Text))
                    actualizar.NuevaContrasena = TBPassword.Text;

                await _personalLogica.Actualizar(_idPersonalSeleccionado, actualizar);

                MessageBox.Show("Personal actualizado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarPersonalAsync();
                LimpiarFormulario();
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (_idPersonalSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un usuario de la grilla para dar de baja.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_idPersonalSeleccionado == SesionUsuario.IdUsuario)
            {
                MessageBox.Show(
                    "Operación denegada: Un Administrador no puede darse de baja ni eliminar su propia cuenta en uso.",
                    "Restricción de Seguridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }

            if (MessageBox.Show("¿Está seguro de dar de baja a este usuario?",
                "Dar de Baja Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await _personalLogica.Eliminar(_idPersonalSeleccionado);
                    MessageBox.Show("Personal dado de baja exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarPersonalAsync();
                    LimpiarFormulario();
                    ActualizarBotonesSegunModo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al dar de baja: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            _esEdicion = false;
            _idPersonalSeleccionado = 0;
            ActualizarBotonesSegunModo();
            TBDni.Focus();
        }

        // ============================================================
        // 5. SELECCIÓN EN LA GRILLA
        // ============================================================
        private async void DGVPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var fila = DGVPersonal.Rows[e.RowIndex];
                int id = Convert.ToInt32(fila.Cells["ColIdUsuario"].Value ?? 0);

                System.Diagnostics.Debug.WriteLine($"=== CellClick ===");
                System.Diagnostics.Debug.WriteLine($"ID leído de la grilla: {id}");
                System.Diagnostics.Debug.WriteLine($"ColIdUsuario.Value: {fila.Cells["ColIdUsuario"].Value}");
                System.Diagnostics.Debug.WriteLine($"Nombre en la fila: {fila.Cells["ColNombreCompleto"].Value}");
                _idPersonalSeleccionado = id;
                _esEdicion = true;

                var personal = await _personalLogica.ObtenerPorId(id);
                if (personal != null)
                {
                    TBDni.Text = personal.Dni ?? "";
                    TBCuil.Text = personal.CuilCuit ?? "";
                    TBNombre.Text = personal.Nombre ?? "";
                    TBApellido.Text = personal.Apellido ?? "";
                    TBEmail.Text = personal.Email ?? "";
                    TBUsuario.Text = personal.CodUsuario ?? "";
                    TBTelefono.Text = personal.Telefono ?? "";
                    TBPassword.Clear();

                    // ✅ Seleccionar el perfil en el combo
                    if (personal.PerfilId > 0)
                    {
                        CBRol.SelectedValue = personal.PerfilId;

                        // ✅ Fallback: si no matcheó por ValueMember, buscar manualmente
                        if (CBRol.SelectedIndex == -1)
                        {
                            for (int i = 0; i < CBRol.Items.Count; i++)
                            {
                                var perfil = CBRol.Items[i] as PerfilDto;
                                if (perfil != null && perfil.Id == personal.PerfilId)
                                {
                                    CBRol.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }

                    ChBUsuarioHabilitado.Checked = personal.Estado;
                }

                BDesactivar.Enabled = (_idPersonalSeleccionado != SesionUsuario.IdUsuario);
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                // ✅ Mostrar el error completo con inner exception
                string mensajeCompleto = $"Error al cargar personal:\n\n" +
                                         $"Mensaje: {ex.Message}\n\n" +
                                         $"Tipo: {ex.GetType().Name}\n\n" +
                                         $"StackTrace: {ex.StackTrace}";

                if (ex.InnerException != null)
                {
                    mensajeCompleto += $"\n\nInner Exception:\n{ex.InnerException.Message}";
                }

                MessageBox.Show(mensajeCompleto, "Error Detallado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 6. LIMPIAR FORMULARIO
        // ============================================================
        private void LimpiarFormulario()
        {
            _idPersonalSeleccionado = 0;
            _esEdicion = false;

            TBDni.Clear();
            TBCuil.Clear();
            TBNombre.Clear();
            TBApellido.Clear();
            TBTelefono.Clear();
            TBEmail.Clear();
            TBUsuario.Clear();
            TBPassword.Clear();
            CBRol.SelectedIndex = -1;
            ChBUsuarioHabilitado.Checked = true;

            // ✅ Restaurar color del label de email
            TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
            LEmail.Text = "Correo Electrónico:";
            LEmail.ForeColor = Color.FromArgb(70, 70, 70);

            BDesactivar.Enabled = true;

            DGVPersonal.ClearSelection();
            if (DGVPersonal.CurrentCell != null)
                DGVPersonal.CurrentCell = null;

            ActualizarBotonesSegunModo();
        }

        // ============================================================
        // Habilita/Deshabilita botones según el modo
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