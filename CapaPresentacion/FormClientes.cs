using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaPresentacion
{
    public partial class FormClientes : Form
    {
        private readonly UsuarioLogica _usuarioLogica = new UsuarioLogica();
        private bool _actualizandoCuil = false;
        public FormClientes()
        {
            InitializeComponent();
            InicializarComportamiento();
        }
        private void InicializarComportamiento()
        {   
            AsignarEstiloEIconos();
            ConfigurarRestriccionesTeclado();
            ConfigurarFormateoCuilEnVivo();
            ConfigurarCascadaProvincias();
            ConfigurarValidacionEmailEnVivo();
        }
        // 1. RESTRICCIONES DE TECLADO (KeyPress)
        private void ConfigurarRestriccionesTeclado()
        {
            // DNI: 8 dígitos continuos puros
            TBCodigoInterno.MaxLength = 8;
            TBCodigoInterno.KeyPress += SoloNumeros_KeyPress;

            // CUIL/CUIT: hasta 13 caracteres con los dos guiones (XX-XXXXXXXX-X)
            TBCuilCuit.MaxLength = 13;
            TBCuilCuit.KeyPress += SoloNumeros_KeyPress;

            // Teléfono: solo números, sin guiones ni caracteres
            TTelefono.MaxLength = 15;
            TTelefono.KeyPress += SoloNumeros_KeyPress;

            // N° / Altura: solo números
            TBNro.MaxLength = 6;
            TBNro.KeyPress += SoloNumeros_KeyPress;

            // Solo letras y espacios en Nombre y Apellido
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
        // 2. FORMATEO EN TIEMPO REAL DEL DNI (Ej: 42-123-456)
        private void ConfigurarFormateoCuilEnVivo()
        {
            TBCuilCuit.TextChanged += (s, e) =>
            {
                if (_actualizandoCuil) return;

                // Extraer únicamente los dígitos numéricos
                string digitos = new string(TBCuilCuit.Text.Where(char.IsDigit).ToArray());

                // Límite de 11 dígitos reales
                if (digitos.Length > 11)
                    digitos = digitos.Substring(0, 11);

                string textoFormateado = digitos;

                // Inserción progresiva de guiones: XX-XXXXXXXX-X
                if (digitos.Length > 10)
                {
                    // Tiene los 11 dígitos: XX-XXXXXXXX-X
                    textoFormateado = $"{digitos.Substring(0, 2)}-{digitos.Substring(2, 8)}-{digitos.Substring(10, 1)}";
                }
                else if (digitos.Length > 2)
                {
                    // Entre 3 y 10 dígitos: XX-XXXXXXXX...
                    textoFormateado = $"{digitos.Substring(0, 2)}-{digitos.Substring(2)}";
                }

                _actualizandoCuil = true;
                TBCuilCuit.Text = textoFormateado;
                TBCuilCuit.SelectionStart = TBCuilCuit.Text.Length; // Mantiene el cursor al final
                _actualizandoCuil = false;
            };
        }
        // VALIDACIÓN DE CORREO ELECTRÓNICO EN TIEMPO REAL
        private void ConfigurarValidacionEmailEnVivo()
        {
            // Patrón estándar RFC para correos electrónicos
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // 1. Mientras tipea: confirmación sutil
            TBEmail.TextChanged += (s, e) =>
            {
                string email = TBEmail.Text.Trim();

                if (string.IsNullOrEmpty(email))
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                    return;
                }

                // Si ya completó una estructura válida mientras escribe, le damos feedback positivo
                if (Regex.IsMatch(email, patronEmail))
                {
                    TBEmail.ForeColor = Color.FromArgb(39, 174, 96); // Verde éxito
                }
                else
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44); // Vuelve al color estándar mientras tipea
                }
            };

            // 2. Al perder el foco (el usuario terminó de escribir y pasó a otro campo)
            TBEmail.Leave += (s, e) =>
            {
                string email = TBEmail.Text.Trim();

                if (string.IsNullOrWhiteSpace(email))
                {
                    // Si es campo obligatorio
                    TBEmail.ForeColor = Color.FromArgb(192, 57, 43); // Rojo alerta
                    LEmail.Text = "Correo Electrónico * (Obligatorio)";
                    LEmail.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else if (!Regex.IsMatch(email, patronEmail))
                {
                    // Formato inválido al salir
                    TBEmail.ForeColor = Color.FromArgb(192, 57, 43); // Rojo alerta
                    LEmail.Text = "Correo Electrónico (Formato inválido: ej@dominio.com)";
                    LEmail.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else
                {
                    // Válido
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                    LEmail.Text = "Correo Electrónico";
                    LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                }
            };

            // 3. Al reingresar al campo, restablece la etiqueta
            TBEmail.Enter += (s, e) =>
            {
                LEmail.Text = "Correo Electrónico";
                LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
            };
        }
        // 3. CASCADA PROVINCIAS -> LOCALIDADES
        private void ConfigurarCascadaProvincias()
        {
            // Evento de selección de Provincia
            CBProvincia.SelectedIndexChanged += (s, e) =>
            {
                if (CBProvincia.SelectedValue != null && int.TryParse(CBProvincia.SelectedValue.ToString(), out int idProvincia))
                {
                    CargarLocalidadesPorProvincia(idProvincia);
                }
                else
                {
                    CBLocalidad.DataSource = null;
                    CBLocalidad.Items.Clear();
                }
            };
        }
        private void CargarProvincias()
        {
            // Consumo de tu Capa Lógica / Datos
            //var listaProvincias = _usuarioLogica.ObtenerProvincias();
            //CBProvincia.DataSource = listaProvincias;
            CBProvincia.DisplayMember = "Nombre";
            CBProvincia.ValueMember = "IdProvincia";
            CBProvincia.SelectedIndex = -1; // Sin selección inicial
        }

        private void CargarLocalidadesPorProvincia(int idProvincia)
        {
            //var listaLocalidades = _usuarioLogica.ObtenerLocalidadesPorProvincia(idProvincia);
            //CBLocalidad.DataSource = listaLocalidades;
            CBLocalidad.DisplayMember = "Nombre";
            CBLocalidad.ValueMember = "IdLocalidad";
            CBLocalidad.SelectedIndex = -1;
        }
        // 4. VALIDACIÓN INTEGRAL AL GUARDAR / EDITAR
        private bool ValidarCamposCliente(out string mensajeError)
        {
            mensajeError = string.Empty;

            // DNI: obligatorio, exactamente 8 dígitos puros
            string dni = TBCodigoInterno.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni) || dni.Length != 8 || !dni.All(char.IsDigit))
            {
                mensajeError = "El DNI es obligatorio y debe contener exactamente 8 números.";
                TBCodigoInterno.Focus();
                return false;
            }

            // CUIL/CUIT: si se ingresó, debe tener exactamente 11 dígitos numéricos (XX-XXXXXXXX-X)
            string cuilDigitos = new string(TBCuilCuit.Text.Where(char.IsDigit).ToArray());
            if (!string.IsNullOrWhiteSpace(cuilDigitos))
            {
                if (cuilDigitos.Length != 11)
                {
                    mensajeError = "El CUIL/CUIT debe contener 11 dígitos numéricos con el formato XX-XXXXXXXX-X.";
                    TBCuilCuit.Focus();
                    return false;
                }

                // Comprobación de coherencia, los 8 dígitos del medio suelen ser el DNI
                string cuilDniCentro = cuilDigitos.Substring(2, 8);
                string prefijo = cuilDigitos.Substring(0, 2);
                if ((prefijo == "20" || prefijo == "27" || prefijo == "23" || prefijo == "24") && cuilDniCentro != dni)
                {
                    DialogResult advertencia = MessageBox.Show(
                        "El número de DNI no coincide con los dígitos centrales del CUIL ingresado.\n\n¿Desea continuar de todos modos?",
                        "Verificación de Identidad",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (advertencia == DialogResult.No)
                    {
                        TBCuilCuit.Focus();
                        return false;
                    }
                }
            }

                // Nombre
                if (string.IsNullOrWhiteSpace(TBNombreRazonSocial.Text.Trim()))
            {
                mensajeError = "Debe ingresar el Nombre o Razón Social del cliente.";
                TBNombreRazonSocial.Focus();
                return false;
            }

            // Teléfono: obligatorio, solo números
            if (string.IsNullOrWhiteSpace(TTelefono.Text.Trim()) || TTelefono.Text.Length < 7)
            {
                mensajeError = "Debe ingresar un número de teléfono válido (solo números, mínimo 7 dígitos).";
                TTelefono.Focus();
                return false;
            }

            // Correo Electrónico: validación estricta de formato RFC
            if (!string.IsNullOrWhiteSpace(TBEmail.Text.Trim()))
            {
                string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(TBEmail.Text.Trim(), patronEmail))
                {
                    mensajeError = "El formato del Correo Electrónico no es válido (ejemplo: usuario@dominio.com).";
                    TBEmail.Focus();
                    return false;
                }
            }
            else
            {
                mensajeError = "El Correo Electrónico es obligatorio.";
                TBEmail.Focus();
                return false;
            }

            // Calle (Domicilio)
            if (string.IsNullOrWhiteSpace(TBCalle.Text.Trim()))
            {
                mensajeError = "Debe ingresar el nombre de la Calle.";
                TBCalle.Focus();
                return false;
            }

            // Altura / Nro es opcional: si está vacío se guardará como nulo o "S/N"
            // Provincia y Localidad
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
        // 5. ACCIÓN DE GUARDAR
        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCliente(out string error))
            {
                MessageBox.Show(error, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extracción limpia lista para la Capa de Negocio
            string dni = new string(TBCodigoInterno.Text.Where(char.IsDigit).ToArray());
            string cuil = TBCuilCuit.Text.Trim();
            string nombre = TBNombreRazonSocial.Text.Trim();
            string apellido = TApellido.Text.Trim();
            string telefono = TTelefono.Text.Trim();
            string email = TBEmail.Text.Trim();
            string calle = TBCalle.Text.Trim();
            string altura = string.IsNullOrWhiteSpace(TBNro.Text) ? "S/N" : TBNro.Text.Trim(); // Opcional
            int idLocalidad = Convert.ToInt32(CBLocalidad.SelectedValue);
            bool habilitado = ChBClienteHabilitado.Checked;

            // Procesar guardado en capa lógica...
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
            BNuevo.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);;
            BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
            BEditar.Image = EscalarIcono(Properties.Resources.boton_editar_blanco, 32, 32);
            BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            BLimpiar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarProvincias();
        }

    }
}
