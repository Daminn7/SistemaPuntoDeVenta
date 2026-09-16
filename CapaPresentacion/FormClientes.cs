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

        private bool _actualizandoCuil = false;
        private bool _esEdicion = false;       // true = editando, false = nuevo
        private int _clienteId = 0;
        private List<ProvinciaDto> _provincias;
        private List<LocalidadDto> _localidades;

        // ✅ NUEVO: Controla qué clientes se muestran (true = activos, false = inactivos)
        private bool _mostrarSoloActivos = true;

        // ============================================================
        // CONSTRUCTOR
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
            LimpiarCampos();

            // Inicializar el texto del botón de estado
            BLimpiarFiltros.Text = "Inactivos";
        }

        // ============================================================
        // PERMISOS POR ROL
        // ============================================================
        private void AplicarPermisosPorRol()
        {
            string rol = (FormPrincipal.SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();

            if (rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                // El cajero solo puede consultar la grilla
                if (PTarjetaLateral != null)
                    PTarjetaLateral.Visible = false;

                if (TLPContenido != null && TLPContenido.ColumnCount >= 2)
                {
                    TLPContenido.ColumnStyles[0].SizeType = SizeType.Percent;
                    TLPContenido.ColumnStyles[0].Width = 100F;
                    TLPContenido.ColumnStyles[1].SizeType = SizeType.Percent;
                    TLPContenido.ColumnStyles[1].Width = 0F;
                }

                DGVClientes.ReadOnly = true;
                DGVClientes.AllowUserToAddRows = false;
                DGVClientes.AllowUserToDeleteRows = false;
                DGVClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGVClientes.MultiSelect = false;

                if (LTituloPrincipal != null)
                    LTituloPrincipal.Text = "CONSULTA Y VALIDACIÓN DE CLIENTES";
            }
            else if (rol == "VENDEDOR")
            {
                // El vendedor no puede dar de baja clientes
                if (BDesactivar != null)
                    BDesactivar.Visible = false;

                if (TLPBotonesMed != null && TLPBotonesMed.ColumnCount >= 2)
                {
                    TLPBotonesMed.ColumnStyles[0].SizeType = SizeType.Percent;
                    TLPBotonesMed.ColumnStyles[0].Width = 100F;
                    TLPBotonesMed.ColumnStyles[1].SizeType = SizeType.Percent;
                    TLPBotonesMed.ColumnStyles[1].Width = 0F;
                }

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

                // Filtrar según _mostrarSoloActivos
                var clientesFiltrados = clientes
                    .Where(c => _mostrarSoloActivos ? c.Estado : !c.Estado)
                    .ToList();

                foreach (var cliente in clientesFiltrados)
                {
                    string dni = cliente.Dni ?? "";
                    string cuilCuit = cliente.CuilCuit ?? "";
                    string nombreCompleto = $"{cliente.Nombre ?? ""} {cliente.Apellido ?? ""}".Trim();
                    string telefono = cliente.Telefono ?? "";
                    string email = cliente.Email ?? "";
                    string direccion = cliente.Direccion ?? "";

                    // Formatear localidad y provincia
                    string localidadMostrar = "";
                    if (!string.IsNullOrEmpty(cliente.Provincia) || !string.IsNullOrEmpty(cliente.Localidad))
                    {
                        localidadMostrar = $"{cliente.Provincia} - {cliente.Localidad}".Trim(' ', '-');
                    }
                    else if (!string.IsNullOrEmpty(cliente.Localidad))
                    {
                        localidadMostrar = cliente.Localidad;
                    }

                    // Formatear el estado como texto
                    string estadoMostrar = cliente.Estado ? "Activo" : "Inactivo";

                    DGVClientes.Rows.Add(
                        cliente.IdCliente,      // Columna 0: ID (oculta)
                        dni,                    // Columna 1: DNI
                        cuilCuit,               // Columna 2: CUIL/CUIT
                        nombreCompleto,         // Columna 3: Nombre Completo
                        telefono,               // Columna 4: Teléfono
                        email,                  // Columna 5: Email
                        localidadMostrar,       // Columna 6: Provincia - Localidad
                        direccion,              // Columna 7: Dirección
                        estadoMostrar           // Columna 8: Estado (Activo/Inactivo)
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

            // El cajero no puede editar clientes
            string rol = (FormPrincipal.SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();
            if (rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
                return;

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

                // ============================================================
                // DATOS PERSONALES
                // ============================================================
                TBCodigoInterno.Text = cliente.Dni ?? "";
                TBCuilCuit.Text = cliente.CuilCuit ?? "";
                TBNombreRazonSocial.Text = cliente.Nombre ?? "";
                TApellido.Text = cliente.Apellido ?? "";
                TBEmail.Text = cliente.Email ?? "";

                // ============================================================
                // TELÉFONO (Separación de Característica y Número)
                // ============================================================
                string telCompleto = (cliente.Telefono ?? "").Trim();
                if (!string.IsNullOrEmpty(telCompleto))
                {
                    string[] partesTel = telCompleto.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (partesTel.Length >= 2)
                    {
                        TBCaracteristica.Text = partesTel[0];
                        TTelefono.Text = partesTel[1];
                    }
                    else if (telCompleto.Length > 7)
                    {
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

                // ============================================================
                // DIRECCIÓN
                // ============================================================
                TBCalle.Clear();
                TBNro.Clear();
                TBPiso.Clear();
                TBDpto.Clear();

                // Usar DireccionCompleta si está disponible
                if (cliente.DireccionCompleta != null)
                {
                    try
                    {
                        var dir = cliente.DireccionCompleta as dynamic;
                        if (dir != null)
                        {
                            // Intentar diferentes nombres de propiedades
                            if (dir.Calle != null) TBCalle.Text = dir.Calle.ToString();
                            if (dir.calle != null) TBCalle.Text = dir.calle.ToString();

                            if (dir.Numero != null) TBNro.Text = dir.Numero.ToString();
                            if (dir.numero != null) TBNro.Text = dir.numero.ToString();

                            if (dir.Piso != null) TBPiso.Text = dir.Piso.ToString();
                            if (dir.piso != null) TBPiso.Text = dir.piso.ToString();

                            if (dir.Departamento != null) TBDpto.Text = dir.Departamento.ToString();
                            if (dir.departamento != null) TBDpto.Text = dir.departamento.ToString();
                        }
                    }
                    catch { }
                }
                else if (!string.IsNullOrEmpty(cliente.Direccion))
                {
                    // Fallback: extraer calle y número del campo Direccion
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

                // ============================================================
                // PROVINCIA Y LOCALIDAD
                // ============================================================
                if (cliente.LocalidadId.HasValue && cliente.LocalidadId.Value > 0)
                {
                    int localidadId = cliente.LocalidadId.Value;

                    // Buscar la localidad en la lista cargada
                    var localidad = _localidades?.FirstOrDefault(l => l.Id == localidadId);

                    // Si no se encuentra, cargar las localidades de esa provincia
                    if (localidad == null && cliente.ProvinciaId.HasValue && cliente.ProvinciaId.Value > 0)
                    {
                        await CargarLocalidadesPorProvinciaAsync(cliente.ProvinciaId.Value);
                        localidad = _localidades?.FirstOrDefault(l => l.Id == localidadId);
                    }

                    if (localidad != null)
                    {
                        var provincia = _provincias?.FirstOrDefault(p => p.Id == localidad.ProvinciaId);
                        if (provincia != null)
                        {
                            //  Seleccionar la provincia
                            CBProvincia.SelectedValue = provincia.Id;

                            //  Esperar a que la cascada cargue las localidades
                            await Task.Delay(300);

                            // Seleccionar la localidad
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

            // DNI
            string dni = TBCodigoInterno.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni) || dni.Length != 8 || !dni.All(char.IsDigit))
            {
                mensajeError = "El DNI es obligatorio y debe contener exactamente 8 números.";
                TBCodigoInterno.Focus();
                return false;
            }

            // Nombre
            if (string.IsNullOrWhiteSpace(TBNombreRazonSocial.Text.Trim()))
            {
                mensajeError = "Debe ingresar el Nombre o Razón Social del cliente.";
                TBNombreRazonSocial.Focus();
                return false;
            }

            // Característica
            if (string.IsNullOrWhiteSpace(TBCaracteristica.Text.Trim()) || TBCaracteristica.Text.Length < 2)
            {
                mensajeError = "Debe ingresar la Característica telefónica (código de área de 2 a 5 dígitos).";
                TBCaracteristica.Focus();
                return false;
            }

            // Teléfono
            if (string.IsNullOrWhiteSpace(TTelefono.Text.Trim()) || TTelefono.Text.Length < 6)
            {
                mensajeError = "Debe ingresar un número de teléfono válido (mínimo 6 dígitos).";
                TTelefono.Focus();
                return false;
            }

            // Email
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(TBEmail.Text.Trim()) || !Regex.IsMatch(TBEmail.Text.Trim(), patronEmail))
            {
                mensajeError = "Debe ingresar un Correo Electrónico válido (ejemplo: usuario@dominio.com).";
                TBEmail.Focus();
                return false;
            }

            // Calle
            if (string.IsNullOrWhiteSpace(TBCalle.Text.Trim()))
            {
                mensajeError = "Debe ingresar el nombre de la Calle.";
                TBCalle.Focus();
                return false;
            }

            // Provincia
            if (CBProvincia.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Provincia de la lista.";
                CBProvincia.Focus();
                return false;
            }

            // Localidad
            if (CBLocalidad.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Localidad.";
                CBLocalidad.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // 7. BOTÓN GUARDAR (SOLO CREAR NUEVO CLIENTE)
        // ============================================================
        private async void BGuardar_Click(object sender, EventArgs e)
        {
            // Si estamos en modo edición, avisar que use Actualizar
            if (_esEdicion)
            {
                MessageBox.Show("Está en modo edición. Use el botón 'Actualizar' para guardar los cambios.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCamposCliente(out string error))
            {
                MessageBox.Show(error, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //  MODIFICADO: Crear cliente completo en UNA SOLA PETICIÓN
                // Antes se hacían 4 peticiones separadas (dirección, teléfono, usuario, cliente)
                // Ahora se envía todo junto al endpoint POST /api/clientes
                var crearCliente = new CrearClienteDto
                {
                    Nombre = TBNombreRazonSocial.Text.Trim(),
                    Apellido = TApellido.Text.Trim(),
                    Dni = TBCodigoInterno.Text.Trim(),
                    CuilCuit = TBCuilCuit.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    Direccion = new DireccionCrearDto
                    {
                        Calle = TBCalle.Text.Trim(),
                        Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                        Edificio = null,
                        Piso = string.IsNullOrWhiteSpace(TBPiso.Text) ? (int?)null : int.Parse(TBPiso.Text),
                        Departamento = TBDpto.Text.Trim(),
                        Descripcion = null,
                        LocalidadId = (int)CBLocalidad.SelectedValue
                    },
                    Telefono = new TelefonoCrearDto
                    {
                        Caracteristica = TBCaracteristica.Text.Trim(),
                        Numero = long.Parse(TTelefono.Text.Trim())
                    }
                };

                await _clienteLogica.Crear(crearCliente);

                MessageBox.Show("Cliente creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarClientesAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 8. BOTÓN ACTUALIZAR (SOLO ACTUALIZAR CLIENTE SELECCIONADO)
        // ============================================================
        private async void BActualizar_Click(object sender, EventArgs e)
        {
            // Verificar que haya un cliente seleccionado
            if (!_esEdicion || _clienteId <= 0)
            {
                MessageBox.Show("Seleccione un cliente de la grilla para actualizar sus datos.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCamposCliente(out string error))
            {
                MessageBox.Show(error, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Actualizar cliente completo en UNA SOLA PETICIÓN
                // Antes se hacían peticiones separadas para dirección, teléfono y usuario
                // Ahora se envía todo junto al endpoint PUT /api/clientes/{id}
                var actualizarCliente = new CrearClienteDto
                {
                    Nombre = TBNombreRazonSocial.Text.Trim(),
                    Apellido = TApellido.Text.Trim(),
                    Dni = TBCodigoInterno.Text.Trim(),
                    CuilCuit = TBCuilCuit.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    Direccion = new DireccionCrearDto
                    {
                        Calle = TBCalle.Text.Trim(),
                        Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                        Edificio = null,
                        Piso = string.IsNullOrWhiteSpace(TBPiso.Text) ? (int?)null : int.Parse(TBPiso.Text),
                        Departamento = TBDpto.Text.Trim(),
                        Descripcion = null,
                        LocalidadId = (int)CBLocalidad.SelectedValue
                    },
                    Telefono = new TelefonoCrearDto
                    {
                        Caracteristica = TBCaracteristica.Text.Trim(),
                        Numero = long.Parse(TTelefono.Text.Trim())
                    }
                };

                await _clienteLogica.Actualizar(_clienteId, actualizarCliente);

                MessageBox.Show("Cliente actualizado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarClientesAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 9. BOTÓN DESACTIVAR (DAR DE BAJA)
        // ============================================================
        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (DGVClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var idValue = DGVClientes.SelectedRows[0].Cells[0].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int id = Convert.ToInt32(idValue);
                string nombre = DGVClientes.SelectedRows[0].Cells[3].Value?.ToString() ?? "";

                if (MessageBox.Show($"¿Desea dar de baja al cliente '{nombre}'?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await _clienteLogica.Eliminar(id);
                    MessageBox.Show("Cliente dado de baja exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarClientesAsync();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dar de baja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ============================================================
        //  BOTÓN ESTADO (Alterna entre Activos e Inactivos)
        // ============================================================
        private async void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // Alternar el filtro
            _mostrarSoloActivos = !_mostrarSoloActivos;

            // Cambiar el texto del botón para indicar qué se está mostrando
            BLimpiarFiltros.Text = _mostrarSoloActivos ? "Inactivos" : "Activos";

            //  Recargar la lista con el filtro aplicado
            await CargarClientesAsync();
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