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
        private bool _actualizandoCuil = false;
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
        // CARGA DE CLIENTES
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
                    string direccion = cliente.Direccion ?? "";
                    string localidad = "";

                    if (cliente.DireccionCompleta != null)
                    {
                        try
                        {
                            var direccionObj = cliente.DireccionCompleta as dynamic;
                            if (direccionObj != null)
                            {
                                localidad = direccionObj.Localidad?.ToString() ?? "";
                            }
                        }
                        catch
                        {
                            localidad = "";
                        }
                    }

                    DGVClientes.Rows.Add(
                        cliente.IdCliente,
                        cliente.Dni ?? "",
                        cliente.CuilCuit ?? "",
                        $"{cliente.Nombre ?? ""} {cliente.Apellido ?? ""}".Trim(),
                        cliente.Telefono ?? "",
                        cliente.Email ?? "",
                        localidad,
                        direccion,
                        cliente.Estado ? "Activo" : "Inactivo"
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
        // 5. BOTÓN LIMPIAR CAMPOS
        // ============================================================
        private void BLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // ============================================================
        // 6. BOTÓN NUEVO
        // ============================================================
        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            TBCodigoInterno.Focus();
        }

        // ============================================================
        // 7. LIMPIAR CAMPOS
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

            Refresh();
        }

        // ============================================================
        // 8. ICONOS
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