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
        // CONSTRUCTOR LIMPIO (Eventos delegados al Designer)
        // ============================================================
        public FormClientes()
        {
            InitializeComponent();
            InicializarComportamiento();
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
            ConfigurarBuscadorEnVivo();
        }

        // ============================================================
        // CARGA DEL FORMULARIO
        // ============================================================
        private async void FormClientes_Load(object sender, EventArgs e)
        {
            AplicarPermisosPorRol();
            ConfigurarEstiloDataGridView();
            await CargarProvinciasAsync();
            await CargarClientesAsync();
        }
        private void AplicarPermisosPorRol()
        {
            string rol = (FormPrincipal.SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();

            if (rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                // 1. Ocultar la tarjeta lateral de edición completa para el cajero
                if (PTarjetaLateral != null)
                {
                    PTarjetaLateral.Visible = false;
                }

                // 2. Expandir la grilla de clientes al 100% del formulario
                if (TLPContenido != null && TLPContenido.ColumnCount >= 2)
                {
                    TLPContenido.ColumnStyles[0].SizeType = SizeType.Percent;
                    TLPContenido.ColumnStyles[0].Width = 100F;

                    TLPContenido.ColumnStyles[1].SizeType = SizeType.Percent;
                    TLPContenido.ColumnStyles[1].Width = 0F;
                }

                // 3. Grilla en modo estricto de solo lectura
                DGVClientes.ReadOnly = true;
                DGVClientes.AllowUserToAddRows = false;
                DGVClientes.AllowUserToDeleteRows = false;
                DGVClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVClientes.MultiSelect = false;

                // 4. Actualizar título para reflejar consulta
                if (LTituloPrincipal != null)
                {
                    LTituloPrincipal.Text = "CONSULTA Y VALIDACIÓN DE CLIENTES";
                }
            }
            else if (rol == "VENDEDOR")
            {
                // El vendedor puede dar de alta o actualizar datos de contacto,
                // pero NO tiene permiso para dar de baja clientes
                if (BDesactivar != null)
                {
                    BDesactivar.Visible = false;
                }

                // Ajustamos BActualizar para que ocupe todo el ancho disponible en su fila
                if (TLPBotonesMed != null && TLPBotonesMed.ColumnCount >= 2)
                {
                    TLPBotonesMed.ColumnStyles[0].SizeType = SizeType.Percent;
                    TLPBotonesMed.ColumnStyles[0].Width = 100F;

                    TLPBotonesMed.ColumnStyles[1].SizeType = SizeType.Percent;
                    TLPBotonesMed.ColumnStyles[1].Width = 0F;
                }

                // Centrado de BActualizar al ocupar el ancho completo (388 px)
                BActualizar.Padding = new Padding(125, 0, 0, 0);
            }
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
        // CARGA DE CLIENTES
        // ============================================================
        private async Task CargarClientesAsync()
        {
            try
            {
                var clientes = await _clienteLogica.ObtenerTodos();

                DGVClientes.Rows.Clear();
                if (clientes == null || clientes.Count == 0) return;

                foreach (var cliente in clientes)
                {
                    string dni = cliente.Dni ?? "";
                    string cuilCuit = cliente.CuilCuit ?? "";
                    string nombreCompleto = $"{cliente.Nombre ?? ""} {cliente.Apellido ?? ""}".Trim();
                    string telefono = cliente.Telefono ?? "";
                    string email = cliente.Email ?? "";
                    string direccion = cliente.Direccion ?? "";

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
                        direccion,
                        cliente.Estado
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // SELECCIÓN DE CLIENTE EN EL DATAGRIDVIEW
        // ============================================================
        private void DGVClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Si es Cajero, solo navega y consulta la grilla, no carga la ficha de edición
            string rol = (FormPrincipal.SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();
            if (rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                return;
            }

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
                MessageBox.Show($"Error al seleccionar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Cliente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _usuarioId = cliente.UsuarioId;

                // DATOS PERSONALES
                TBCodigoInterno.Text = cliente.Dni ?? "";
                TBCuilCuit.Text = cliente.CuilCuit ?? "";
                TBNombreRazonSocial.Text = cliente.Nombre ?? "";
                TApellido.Text = cliente.Apellido ?? "";
                TBEmail.Text = cliente.Email ?? "";

                // TELÉFONO (Separación de Característica y Número si corresponde)
                string telCompleto = (cliente.Telefono ?? "").Trim();
                if (!string.IsNullOrEmpty(telCompleto))
                {
                    // Si viene con formato "379-4123456" o "379 4123456"
                    string[] partesTel = telCompleto.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (partesTel.Length >= 2)
                    {
                        TBCaracteristica.Text = partesTel[0];
                        TTelefono.Text = partesTel[1];
                    }
                    else if (telCompleto.Length > 7)
                    {
                        // Estimación por longitud
                        int longCaract = telCompleto.Length - 7;
                        TBCaracteristica.Text = telCompleto.Substring(0, longCaract);
                        TTelefono.Text = telCompleto.Substring(longCaract);
                    }
                    else
                    {
                        TBCaracteristica.Text = "";
                        TTelefono.Text = telCompleto;
                    }
                }
                else
                {
                    TBCaracteristica.Clear();
                    TTelefono.Clear();
                }

                // DIRECCIÓN
                TBCalle.Clear();
                TBNro.Clear();
                TBPiso.Clear();
                TBDpto.Clear();

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
                        }
                    }
                    else
                    {
                        TBCalle.Text = direccion;
                    }
                }

                if (cliente.DireccionCompleta != null)
                {
                    try
                    {
                        var dir = cliente.DireccionCompleta as dynamic;
                        if (dir != null)
                        {
                            if (dir.Calle != null) TBCalle.Text = dir.Calle.ToString();
                            if (dir.Numero != null) TBNro.Text = dir.Numero.ToString();
                            if (dir.Piso != null) TBPiso.Text = dir.Piso.ToString();
                            if (dir.Departamento != null) TBDpto.Text = dir.Departamento.ToString();
                        }
                    }
                    catch { }
                }

                // PROVINCIA Y LOCALIDAD
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
                MessageBox.Show($"Error al cargar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            TBCaracteristica.MaxLength = 5;
            TBCaracteristica.KeyPress += SoloNumeros_KeyPress;

            TTelefono.MaxLength = 10;
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
        // 4. BÚSQUEDA REACTIVA EN GRILLA
        // ============================================================
        private void ConfigurarBuscadorEnVivo()
        {
            TBBuscar.TextChanged += (s, e) =>
            {
                string termino = TBBuscar.Text.Trim().ToLower();

                foreach (DataGridViewRow row in DGVClientes.Rows)
                {
                    if (row.IsNewRow) continue;

                    string dni = row.Cells["ColDni"].Value?.ToString().ToLower() ?? "";
                    string nombre = row.Cells["ColNombreCompleto"].Value?.ToString().ToLower() ?? "";
                    string cuil = row.Cells["ColCuilCuit"].Value?.ToString().ToLower() ?? "";

                    row.Visible = string.IsNullOrEmpty(termino) ||
                                  dni.Contains(termino) ||
                                  nombre.Contains(termino) ||
                                  cuil.Contains(termino);
                }
            };
        }

        // ============================================================
        // 5. CASCADA PROVINCIAS -> LOCALIDADES
        // ============================================================
        private async Task CargarProvinciasAsync()
        {
            try
            {
                _provincias = await _tablasLogica.GetProvincias();
                if (_provincias == null || _provincias.Count == 0) return;

                CBProvincia.DataSource = _provincias;
                CBProvincia.DisplayMember = "Descripcion";
                CBProvincia.ValueMember = "Id";
                CBProvincia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar provincias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en cascada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 6. VALIDAR CAMPOS
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

            if (string.IsNullOrWhiteSpace(TBCaracteristica.Text.Trim()) || TBCaracteristica.Text.Length < 2)
            {
                mensajeError = "Debe ingresar la Característica telefónica (código de área de 2 a 5 dígitos).";
                TBCaracteristica.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TTelefono.Text.Trim()) || TTelefono.Text.Length < 6)
            {
                mensajeError = "Debe ingresar un número de teléfono válido (mínimo 6 dígitos).";
                TTelefono.Focus();
                return false;
            }

            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(TBEmail.Text.Trim()) || !Regex.IsMatch(TBEmail.Text.Trim(), patronEmail))
            {
                mensajeError = "Debe ingresar un Correo Electrónico válido (ejemplo: usuario@dominio.com).";
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
        // 7. BOTÓN GUARDAR (Nuevo o Edición)
        // ============================================================
        private async void BGuardar_Click(object sender, EventArgs e)
        {
            /*if (!ValidarCamposCliente(out string error))
            {
                MessageBox.Show(error, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // PASO 1: Dirección (con Piso y Dpto)
                var direccion = new CrearDireccionDto
                {
                    Calle = TBCalle.Text.Trim(),
                    Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                    Edificio = null,
                    Piso = string.IsNullOrWhiteSpace(TBPiso.Text) ? null : TBPiso.Text.Trim(),
                    Departamento = string.IsNullOrWhiteSpace(TBDpto.Text) ? null : TBDpto.Text.Trim(),
                    Descripcion = null,
                    LocalidadId = (int)CBLocalidad.SelectedValue
                };
                var direccionCreada = await _direccionLogica.Crear(direccion);

                // PASO 2: Teléfono con su característica real
                var telefono = new CrearTelefonoDto
                {
                    Caracteristica = TBCaracteristica.Text.Trim(),
                    Numero = long.Parse(TTelefono.Text.Trim())
                };
                var telefonoCreado = await _telefonoLogica.Crear(telefono);

                // PASO 3: Usuario
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
                    MessageBox.Show("Cliente actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var usuarioCreado = await _usuarioLogica.CrearUsuario(usuario);
                    var crearCliente = new CrearClienteDto
                    {
                        UsuarioId = usuarioCreado.Id
                    };
                    await _clienteLogica.Crear(crearCliente);
                    MessageBox.Show("Cliente creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await CargarClientesAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        // ============================================================
        // 8. BOTÓN ACTUALIZAR (Antes Editar)
        // ============================================================
        private void BActualizar_Click(object sender, EventArgs e)
        {
            if (DGVClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente de la grilla para actualizar sus datos.", "Aviso",
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
                MessageBox.Show($"Error al preparar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 9. BOTÓN DESACTIVAR (Dar de baja)
        // ============================================================
        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (DGVClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para desactivar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var idValue = DGVClientes.SelectedRows[0].Cells[0].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int id = Convert.ToInt32(idValue);
                string nombre = DGVClientes.SelectedRows[0].Cells[3].Value?.ToString() ?? "";

                if (MessageBox.Show($"¿Desea desactivar al cliente '{nombre}'?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await _clienteLogica.Eliminar(id);
                    MessageBox.Show("Cliente desactivado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarClientesAsync();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 10. BOTÓN NUEVO
        // ============================================================
        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            TBCodigoInterno.Focus();
        }

        // ============================================================
        // 11. FILTROS Y ACTUALIZACIÓN DE LISTA
        // ============================================================
        private async void BActualizarLista_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            await CargarClientesAsync();
        }

        private void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
        }

        // ============================================================
        // 12. LIMPIAR CAMPOS
        // ============================================================
        private void LimpiarCampos()
        {
            TBCodigoInterno.Clear();
            TBCuilCuit.Clear();
            TBNombreRazonSocial.Clear();
            TApellido.Clear();
            TBCaracteristica.Clear();
            TTelefono.Clear();
            TBEmail.Clear();
            TBCalle.Clear();
            TBNro.Clear();
            TBPiso.Clear();
            TBDpto.Clear();

            CBProvincia.SelectedIndex = -1;
            CBLocalidad.DataSource = null;
            CBLocalidad.Items.Clear();

            ChBClienteHabilitado.Checked = true;
            _esEdicion = false;
            _clienteId = 0;
            _usuarioId = 0;
        }

        // ============================================================
        // 13. ESTILO E ÍCONOS
        // ============================================================
        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            if (imagenOriginal == null) return null;

            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
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
                // BActualizar ahora utiliza el icono que antes pertenecía a Limpiar:
                BActualizar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
                BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch
            {
                // Fallback silencioso
            }
        }
    }
}