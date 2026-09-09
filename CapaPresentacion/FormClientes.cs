using CapaLogica;
using CapaDatos.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormClientes : Form
    {
        // ============================================================
        // DECLARACIÓN DE VARIABLES
        // ============================================================
        private readonly TablasMaestrasLogica _tablasLogica = new TablasMaestrasLogica();
        private readonly ClienteLogica _clienteLogica = new ClienteLogica();
        private readonly DireccionLogica _direccionLogica = new DireccionLogica();
        private readonly TelefonoLogica _telefonoLogica = new TelefonoLogica();
        private readonly UsuarioLogica _usuarioLogica = new UsuarioLogica();

        private bool _actualizandoCuil = false;
        private bool _esEdicion = false;
        private int _clienteId = 0;
        private int _usuarioId = 0;
        private List<ProvinciaDto> _provincias;
        private List<LocalidadDto> _localidades;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public FormClientes()
        {
            InitializeComponent();
            InicializarComportamiento();

            // Conectar eventos de botones
            this.BLimpiar.Click += BLimpiar_Click;
            this.BNuevo.Click += BNuevo_Click;
            this.BGuardar.Click += BGuardar_Click;
            this.BEditar.Click += BEditar_Click;
            this.BDesactivar.Click += BDesactivar_Click;

            // Conectar evento de selección en DataGridView
            this.DGVClientes.CellClick += DGVClientes_CellClick;
        }

        // ============================================================
        // INICIALIZACIÓN
        // ============================================================
        private void InicializarComportamiento()
        {
            AsignarEstiloEIconos();
            ConfigurarRestriccionesTeclado();
            ConfigurarFormateoCuilEnVivo();
            ConfigurarCascadaProvincias();
            ConfigurarValidacionEmailEnVivo();
        }

        // ============================================================
        // CARGA DEL FORMULARIO
        // ============================================================
        private async void FormClientes_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloDataGridView();
            await CargarProvinciasAsync();
            await CargarClientesAsync();
        }

        // ============================================================
        // ESTILO DEL DATAGRIDVIEW
        // ============================================================
        private void ConfigurarEstiloDataGridView()
        {
            DGVClientes.DefaultCellStyle.ForeColor = Color.Black;
            DGVClientes.DefaultCellStyle.BackColor = Color.White;
            DGVClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 131, 53);
            DGVClientes.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            DGVClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            DGVClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
        }

        // ============================================================
        // CARGA DE CLIENTES (USANDO CAMPOS DIRECTOS DE LA API)
        // ============================================================
        private async Task CargarClientesAsync()
        {
            try
            {
                var clientes = await _clienteLogica.ObtenerTodos();

                if (clientes == null || clientes.Count == 0)
                {
                    DGVClientes.Rows.Clear();
                    return;
                }

                DGVClientes.Rows.Clear();

                foreach (var cliente in clientes)
                {
                    string dni = cliente.Dni ?? "";
                    string cuilCuit = cliente.CuilCuit ?? "";
                    string nombreCompleto = $"{cliente.Nombre ?? ""} {cliente.Apellido ?? ""}".Trim();
                    string telefono = cliente.Telefono ?? "";
                    string email = cliente.Email ?? "";
                    string direccion = cliente.Direccion ?? "";

                    // ✅ LOCALIDAD - Usar campos directos de la API
                    string localidadMostrar = "";
                    if (!string.IsNullOrEmpty(cliente.Provincia) || !string.IsNullOrEmpty(cliente.Localidad))
                    {
                        localidadMostrar = $"{cliente.Provincia} - {cliente.Localidad}".Trim(' ', '-');
                    }
                    else if (!string.IsNullOrEmpty(cliente.Localidad))
                    {
                        localidadMostrar = cliente.Localidad;
                    }

                    DGVClientes.Rows.Add(
                        cliente.IdCliente,
                        dni,
                        cuilCuit,
                        nombreCompleto,
                        telefono,
                        email,
                        localidadMostrar,
                        direccion
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // SELECCIÓN DE CLIENTE EN EL DATAGRIDVIEW
        // ============================================================
        private void DGVClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var idValue = DGVClientes.Rows[e.RowIndex].Cells[0].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int id = Convert.ToInt32(idValue);
                _clienteId = id;
                _esEdicion = true;
                CargarClienteEnFormulario(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar cliente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARGAR CLIENTE EN EL FORMULARIO PARA EDITAR
        // ============================================================
        private async void CargarClienteEnFormulario(int id)
        {
            try
            {
                var cliente = await _clienteLogica.ObtenerPorId(id);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente no encontrado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _usuarioId = cliente.UsuarioId;

                // ============================================================
                // DATOS BÁSICOS
                // ============================================================
                TBCodigoInterno.Text = cliente.Dni ?? "";
                TBCuilCuit.Text = cliente.CuilCuit ?? "";
                TBNombreRazonSocial.Text = cliente.Nombre ?? "";
                TApellido.Text = cliente.Apellido ?? "";
                TTelefono.Text = cliente.Telefono ?? "";
                TBEmail.Text = cliente.Email ?? "";

                // ============================================================
                // DIRECCIÓN - Usar el campo Direccion directamente
                // ============================================================
                if (!string.IsNullOrEmpty(cliente.Direccion))
                {
                    string direccion = cliente.Direccion;
                    int lastSpaceIndex = direccion.LastIndexOf(' ');
                    if (lastSpaceIndex > 0)
                    {
                        string posibleNumero = direccion.Substring(lastSpaceIndex + 1);
                        if (int.TryParse(posibleNumero, out _))
                        {
                            TBCalle.Text = direccion.Substring(0, lastSpaceIndex);
                            TBNro.Text = posibleNumero;
                        }
                        else
                        {
                            TBCalle.Text = direccion;
                            TBNro.Text = "";
                        }
                    }
                    else
                    {
                        TBCalle.Text = direccion;
                        TBNro.Text = "";
                    }
                }
                else
                {
                    // Fallback: usar DireccionCompleta si está disponible
                    if (cliente.DireccionCompleta != null)
                    {
                        try
                        {
                            var dir = cliente.DireccionCompleta as dynamic;
                            if (dir != null)
                            {
                                TBCalle.Text = dir.Calle?.ToString() ?? "";
                                TBNro.Text = dir.Numero?.ToString() ?? "";
                            }
                        }
                        catch { }
                    }
                }

                // ============================================================
                // PROVINCIA Y LOCALIDAD
                // ============================================================
                if (cliente.LocalidadId.HasValue && cliente.LocalidadId.Value > 0)
                {
                    int localidadId = cliente.LocalidadId.Value;
                    var localidad = _localidades?.FirstOrDefault(l => l.Id == localidadId);
                    if (localidad != null)
                    {
                        var provincia = _provincias?.FirstOrDefault(p => p.Id == localidad.ProvinciaId);
                        if (provincia != null)
                        {
                            CBProvincia.SelectedValue = provincia.Id;
                            await Task.Delay(200);
                            CBLocalidad.SelectedValue = localidadId;
                        }
                    }
                }

                ChBClienteHabilitado.Checked = cliente.Estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cliente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 1. RESTRICCIONES DE TECLADO
        // ============================================================
        private void ConfigurarRestriccionesTeclado()
        {
            TBCodigoInterno.MaxLength = 8;
            TBCodigoInterno.KeyPress += SoloNumeros_KeyPress;

            TBCuilCuit.MaxLength = 13;
            TBCuilCuit.KeyPress += SoloNumeros_KeyPress;

            TTelefono.MaxLength = 15;
            TTelefono.KeyPress += SoloNumeros_KeyPress;

            TBNro.MaxLength = 6;
            TBNro.KeyPress += SoloNumeros_KeyPress;

            TBNombreRazonSocial.KeyPress += SoloLetrasYEspacios_KeyPress;
            TApellido.KeyPress += SoloLetrasYEspacios_KeyPress;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void SoloLetrasYEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        // ============================================================
        // 2. FORMATEO CUIL EN VIVO
        // ============================================================
        private void ConfigurarFormateoCuilEnVivo()
        {
            TBCuilCuit.TextChanged += (s, e) =>
            {
                if (_actualizandoCuil) return;

                string digitos = new string(TBCuilCuit.Text.Where(char.IsDigit).ToArray());

                if (digitos.Length > 11)
                    digitos = digitos.Substring(0, 11);

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
                TBCuilCuit.Text = textoFormateado;
                TBCuilCuit.SelectionStart = TBCuilCuit.Text.Length;
                _actualizandoCuil = false;
            };
        }

        // ============================================================
        // 3. VALIDACIÓN EMAIL EN VIVO
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

                if (Regex.IsMatch(email, patronEmail))
                {
                    TBEmail.ForeColor = Color.FromArgb(39, 174, 96);
                }
                else
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                }
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
                    LEmail.Text = "Correo Electrónico (Formato inválido: ej@dominio.com)";
                    LEmail.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                    LEmail.Text = "Correo Electrónico";
                    LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                }
            };

            TBEmail.Enter += (s, e) =>
            {
                LEmail.Text = "Correo Electrónico";
                LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
            };
        }

        // ============================================================
        // 4. CASCADA PROVINCIAS -> LOCALIDADES (ASYNC)
        // ============================================================
        private async Task CargarProvinciasAsync()
        {
            try
            {
                _provincias = await _tablasLogica.GetProvincias();

                if (_provincias == null || _provincias.Count == 0)
                {
                    MessageBox.Show("No se cargaron provincias", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CBProvincia.DataSource = _provincias;
                CBProvincia.DisplayMember = "Descripcion";
                CBProvincia.ValueMember = "Id";
                CBProvincia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar provincias: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    else
                    {
                        MessageBox.Show("Error: El elemento seleccionado no es una provincia válida",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en cascada: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("No se encontraron localidades para esta provincia",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CBLocalidad.DataSource = null;
                    CBLocalidad.Items.Clear();
                    return;
                }

                CBLocalidad.DataSource = _localidades;
                CBLocalidad.DisplayMember = "Descripcion";
                CBLocalidad.ValueMember = "Id";
                CBLocalidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 5. VALIDAR CAMPOS
        // ============================================================
        private bool ValidarCamposCliente(out string mensajeError)
        {
            mensajeError = string.Empty;

            string dni = TBCodigoInterno.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni) || dni.Length != 8 || !dni.All(char.IsDigit))
            {
                mensajeError = "El DNI es obligatorio y debe contener exactamente 8 números.";
                TBCodigoInterno.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBNombreRazonSocial.Text.Trim()))
            {
                mensajeError = "Debe ingresar el Nombre o Razón Social del cliente.";
                TBNombreRazonSocial.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TTelefono.Text.Trim()) || TTelefono.Text.Length < 7)
            {
                mensajeError = "Debe ingresar un número de teléfono válido (solo números, mínimo 7 dígitos).";
                TTelefono.Focus();
                return false;
            }

            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(TBEmail.Text.Trim()))
            {
                mensajeError = "El Correo Electrónico es obligatorio.";
                TBEmail.Focus();
                return false;
            }
            if (!Regex.IsMatch(TBEmail.Text.Trim(), patronEmail))
            {
                mensajeError = "El formato del Correo Electrónico no es válido (ejemplo: usuario@dominio.com).";
                TBEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBCalle.Text.Trim()))
            {
                mensajeError = "Debe ingresar el nombre de la Calle.";
                TBCalle.Focus();
                return false;
            }

            if (CBProvincia.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Provincia de la lista.";
                CBProvincia.Focus();
                return false;
            }

            if (CBLocalidad.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Localidad.";
                CBLocalidad.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // 6. BOTÓN GUARDAR
        // ============================================================
        private async void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCliente(out string error))
            {
                MessageBox.Show(error, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ============================================================
                // PASO 1: Crear Dirección
                // ============================================================
                var direccion = new CrearDireccionDto
                {
                    Calle = TBCalle.Text.Trim(),
                    Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                    Edificio = null,
                    Piso = null,
                    Departamento = null,
                    Descripcion = null,
                    LocalidadId = (int)CBLocalidad.SelectedValue
                };

                var direccionCreada = await _direccionLogica.Crear(direccion);

                // ============================================================
                // PASO 2: Crear Teléfono (con validación)
                // ============================================================
                // PASO 2: Crear Teléfono
                string telefonoTexto = TTelefono.Text.Trim();

                if (string.IsNullOrWhiteSpace(telefonoTexto))
                {
                    MessageBox.Show("Debe ingresar un número de teléfono.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TTelefono.Focus();
                    return;
                }

                if (!long.TryParse(telefonoTexto, out long numeroTelefono))
                {
                    MessageBox.Show("El teléfono debe contener solo números.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TTelefono.Focus();
                    return;
                }

                var telefono = new CrearTelefonoDto
                {
                    Caracteristica = "11",
                    Numero = numeroTelefono
                };

                var telefonoCreado = await _telefonoLogica.Crear(telefono);

                // ============================================================
                // PASO 3: Crear Usuario (cliente)
                // ============================================================
                var usuario = new CrearUsuarioDto
                {
                    Nombre = TBNombreRazonSocial.Text.Trim(),
                    Apellido = TApellido.Text.Trim(),
                    Dni = TBCodigoInterno.Text.Trim(),
                    CuilCuit = TBCuilCuit.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    DireccionId = direccionCreada.Id,
                    TelefonoId = telefonoCreado.Id,
                    PerfilId = 4,
                    EsCliente = true,
                    EsPersonal = false,
                    EsProveedor = false,
                    CodUsuario = null,
                    Contrasena = null
                };

                if (_esEdicion)
                {
                    var actualizarUsuario = new ActualizarUsuarioDto
                    {
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        Dni = usuario.Dni,
                        CuilCuit = usuario.CuilCuit,
                        Email = usuario.Email,
                        DireccionId = usuario.DireccionId,
                        TelefonoId = usuario.TelefonoId,
                        EsCliente = true,
                        Estado = ChBClienteHabilitado.Checked
                    };
                    await _usuarioLogica.ActualizarUsuario(_usuarioId, actualizarUsuario);
                    MessageBox.Show("Cliente actualizado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var usuarioCreado = await _usuarioLogica.CrearUsuario(usuario);

                    var crearCliente = new CrearClienteDto
                    {
                        UsuarioId = usuarioCreado.Id
                    };
                    await _clienteLogica.Crear(crearCliente);
                    MessageBox.Show("Cliente creado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await CargarClientesAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 7. BOTÓN EDITAR
        // ============================================================
        private void BEditar_Click(object sender, EventArgs e)
        {
            if (DGVClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para editar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var idValue = DGVClientes.SelectedRows[0].Cells[0].Value;
                if (idValue != null && idValue != DBNull.Value)
                {
                    _clienteId = Convert.ToInt32(idValue);
                    _esEdicion = true;
                    CargarClienteEnFormulario(_clienteId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cliente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 8. BOTÓN DESACTIVAR
        // ============================================================
        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (DGVClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para desactivar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var idValue = DGVClientes.SelectedRows[0].Cells[0].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int id = Convert.ToInt32(idValue);
                string nombre = DGVClientes.SelectedRows[0].Cells[3].Value?.ToString() ?? "";

                if (MessageBox.Show($"¿Desea desactivar el cliente '{nombre}'?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await _clienteLogica.Eliminar(id);
                    MessageBox.Show("Cliente desactivado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarClientesAsync();
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
        // 9. BOTÓN LIMPIAR CAMPOS
        // ============================================================
        private void BLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // ============================================================
        // 10. BOTÓN NUEVO
        // ============================================================
        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            _esEdicion = false;
            _clienteId = 0;
            _usuarioId = 0;
            TBCodigoInterno.Focus();
        }

        // ============================================================
        // 11. LIMPIAR CAMPOS
        // ============================================================
        private void LimpiarCampos()
        {
            TBCodigoInterno.Clear();
            TBCuilCuit.Clear();
            TBNombreRazonSocial.Clear();
            TApellido.Clear();
            TTelefono.Clear();
            TBEmail.Clear();
            TBCalle.Clear();
            TBNro.Clear();

            CBProvincia.SelectedIndex = -1;
            CBLocalidad.DataSource = null;
            CBLocalidad.Items.Clear();

            ChBClienteHabilitado.Checked = true;
            _esEdicion = false;
            _clienteId = 0;
            _usuarioId = 0;

            Refresh();
        }

        // ============================================================
        // 12. ICONOS
        // ============================================================
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
    }
}