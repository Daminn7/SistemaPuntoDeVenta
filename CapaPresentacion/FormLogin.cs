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

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        //La capa Presentación solo conoce a la capa Lógica
        private readonly UsuarioLogica _usuarioLogica = new UsuarioLogica();
        private Timer _timerReloj;
        //Variables para hacer variar el comportamiento del boton INGRESAR
        private readonly Color ColorBotonActivo = Color.FromArgb(212, 131, 53);
        private readonly Color ColorBotonInactivo = Color.FromArgb(120, 90, 60);
        public FormLogin()
        {
            InitializeComponent();
            ConfigurarComportamiento();
            ConfigurarRestriccionesTeclado();
            IniciarReloj();
            ValidarCamposEnTiempoReal();
        }
        private void ConfigurarComportamiento()
        {
            //Foco inicial y placeholders
            TUsuario.Text = "Usuario";
            TUsuario.ForeColor = Color.Gray;

            TPassword.Text = "Contraseña";
            TPassword.ForeColor = Color.Gray;
            TPassword.PasswordChar = '\0'; // Texto visible como placeholder

            //Estado inicial de placeholders
            RestablecerCampos();

            //Eventos Placeholder Usuario
            TUsuario.GotFocus += (s, e) =>
            {
                if (TUsuario.Text == "Usuario")
                {
                    TUsuario.Text = "";
                    TUsuario.ForeColor = Color.White;
                }
                LErrorUsuario.Visible = false; // Se oculta al enfocar
            };

            TUsuario.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(TUsuario.Text) || TUsuario.Text == "Usuario")
                {
                    TUsuario.Text = "Usuario";
                    TUsuario.ForeColor = Color.Gray;
                    LErrorUsuario.Visible = true; // Muestra el error al pasar por alto el campo
                }
                else
                {
                    LErrorUsuario.Visible = false;
                }
                ValidarCamposEnTiempoReal();
            };

            //Eventos Placeholder Contraseña
            TPassword.GotFocus += (s, e) =>
            {
                if (TPassword.Text == "Contraseña")
                {
                    TPassword.Text = "";
                    TPassword.ForeColor = Color.White;
                    TPassword.PasswordChar = '●';
                }
                LErrorPassword.Visible = false; // Se oculta al enfocar
            };

            TPassword.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(TPassword.Text) || TPassword.Text == "Contraseña")
                {
                    TPassword.PasswordChar = '\0';
                    TPassword.Text = "Contraseña";
                    TPassword.ForeColor = Color.Gray;
                    LErrorPassword.Visible = true; // Muestra el error al pasar por alto el campo
                }
                else
                {
                    LErrorPassword.Visible = false;
                }
                ValidarCamposEnTiempoReal();
            };

            //Monitoreamos escritura en tiempo real
            TUsuario.TextChanged += (s, e) =>
            {
                if (TUsuario.Text != "Usuario" && !string.IsNullOrWhiteSpace(TUsuario.Text))
                    LErrorUsuario.Visible = false;
                ValidarCamposEnTiempoReal();
            };

            TPassword.TextChanged += (s, e) =>
            {
                if (TPassword.Text != "Contraseña" && !string.IsNullOrWhiteSpace(TPassword.Text))
                    LErrorPassword.Visible = false;
                ValidarCamposEnTiempoReal();
            };

            //Enfoque al hacer clic sobre el panel o iconos
            PUsuario.Click += (s, e) => TUsuario.Focus();
            PBIconoUsuario.Click += (s, e) => TUsuario.Focus();
            PPassword.Click += (s, e) => TPassword.Focus();
            PBIconoPassword.Click += (s, e) => TPassword.Focus();
        }

        private void RestablecerCampos()
        {
            TUsuario.Text = "Usuario";
            TUsuario.ForeColor = Color.Gray;

            TPassword.PasswordChar = '\0';
            TPassword.Text = "Contraseña";
            TPassword.ForeColor = Color.Gray;

            LErrorUsuario.Visible = false;
            LErrorPassword.Visible = false;
        }

        private void ConfigurarRestriccionesTeclado()
        {
            //Solo letras y números en usuario
            TUsuario.KeyPress += (s, e) =>
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            //Letras, números y símbolos en contraseña
            TPassword.KeyPress += (s, e) =>
            {
                string permitidos = "@#$%*!_-.";
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !permitidos.Contains(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            };
        }

        private void ValidarCamposEnTiempoReal()
        {
            bool usuarioValido = !string.IsNullOrWhiteSpace(TUsuario.Text) && TUsuario.Text != "Usuario";
            bool passwordValido = !string.IsNullOrWhiteSpace(TPassword.Text) && TPassword.Text != "Contraseña";

            if (usuarioValido && passwordValido)
            {
                BIngresar.BackColor = ColorBotonActivo;
                BIngresar.Cursor = Cursors.Hand;
            }
            else
            {
                BIngresar.BackColor = ColorBotonInactivo;
                BIngresar.Cursor = Cursors.Default;
            }
        }

        private void IniciarReloj()
        {
            _timerReloj = new Timer();
            _timerReloj.Interval = 1000; // Cada 1 segundo
            _timerReloj.Tick += (s, e) =>
            {
                if (LHora != null)
                    LHora.Text = DateTime.Now.ToString("HH:mm");

                if (LFecha != null)
                    LFecha.Text = DateTime.Now.ToString("dd 'de' MMM yyyy");
            };
            _timerReloj.Start();

            //Carga inicial inmediata
            if (LHora != null) LHora.Text = DateTime.Now.ToString("HH:mm");
            if (LFecha != null) LFecha.Text = DateTime.Now.ToString("dd 'de' MMM yyyy");
        }

        //Atajo para cerrar con tecla ESC (RNF#05)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //Dispara la acción de ingresar directamente
                BIngresar.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                //Dispara la acción de cerrar toda la aplicación
                Application.Exit();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            string usuario = (TUsuario.Text == "Usuario") ? "" : TUsuario.Text.Trim();
            string clave = (TPassword.Text == "Contraseña") ? "" : TPassword.Text;

            bool hayError = false;

            //Validación individual previa antes de procesar
            if (string.IsNullOrWhiteSpace(usuario))
            {
                LErrorUsuario.Visible = true;
                hayError = true;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                LErrorPassword.Visible = true;
                hayError = true;
            }

            if (hayError)
            {
                if (string.IsNullOrWhiteSpace(usuario)) TUsuario.Focus();
                else TPassword.Focus();
                return;
            }

            //Validación estricta a través de la Capa Lógica
            string error = _usuarioLogica.ValidarLogin(usuario, clave, out string rol, out string nombreCompleto);

            if (string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"¡Bienvenido {nombreCompleto}!\nRol asignado: {rol}", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                // Aquí abriremos el FormPrincipal pasando el rol y nombre
                // FormPrincipal frmPrincipal = new FormPrincipal(nombreCompleto, rol);
                // frmPrincipal.ShowDialog();

                this.Close();
            }
            else
            {
                // Alerta al usuario
                MessageBox.Show(error, "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Limpiamos ambos campos y restablecemos sus placeholders
                RestablecerCampos();
                ValidarCamposEnTiempoReal();

                // Devolvemos el foco al campo de usuario
                TUsuario.Focus();

                //Ocultamos las advertencias
                LErrorUsuario.Visible = false;
                LErrorPassword.Visible = false;
            }
        }
    }
}
