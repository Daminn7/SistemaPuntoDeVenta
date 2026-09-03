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
            InicializarFormulario();
        }
        private void InicializarFormulario()
        {
            ConfigurarComportamiento();
            ConfigurarRestriccionesTeclado();
            RestablecerCampos();
            ValidarCamposEnTiempoReal();
            IniciarReloj();
        }
        private void ConfigurarComportamiento()
        {
            // Eventos Placeholder Usuario
            TUsuario.GotFocus += (s, e) =>
            {
                if (TUsuario.Text == "Usuario")
                {
                    TUsuario.Text = "";
                    TUsuario.ForeColor = Color.White;
                }
                LErrorUsuario.Visible = false;
            };

            TUsuario.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(TUsuario.Text) || TUsuario.Text == "Usuario")
                {
                    TUsuario.Text = "Usuario";
                    TUsuario.ForeColor = Color.Gray;
                    LErrorUsuario.Visible = true;
                }
                else
                {
                    LErrorUsuario.Visible = false;
                }
                ValidarCamposEnTiempoReal();
            };

            // Eventos Placeholder Contraseña
            TPassword.GotFocus += (s, e) =>
            {
                if (TPassword.Text == "Contraseña")
                {
                    TPassword.Text = "";
                    TPassword.ForeColor = Color.White;
                    TPassword.PasswordChar = '●';
                }
                LErrorPassword.Visible = false;
            };

            TPassword.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(TPassword.Text) || TPassword.Text == "Contraseña")
                {
                    TPassword.PasswordChar = '\0';
                    TPassword.Text = "Contraseña";
                    TPassword.ForeColor = Color.Gray;
                    LErrorPassword.Visible = true;
                }
                else
                {
                    LErrorPassword.Visible = false;
                }
                ValidarCamposEnTiempoReal();
            };
            // Monitoreo en tiempo real
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
            // Enfoque al hacer clic sobre el panel o iconos
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
            _timerReloj = new Timer { Interval = 1000 };
            _timerReloj.Tick += (s, e) => ActualizarFechaHora();
            _timerReloj.Start();

            ActualizarFechaHora();
        }
        private void ActualizarFechaHora()
        {
            if (LHora != null) LHora.Text = DateTime.Now.ToString("HH:mm");
            if (LFecha != null) LFecha.Text = DateTime.Now.ToString("dd 'de' MMM yyyy");
        }
        //Atajos de teclado (RNF#05)
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
                // Notificación elegante con la paleta institucional que se desvanece o dura 1 segundo
                MostrarBienvenidaFlotante(nombreCompleto, rol);

                this.Hide();

                // Abrimos el FormPrincipal con los datos de sesión
                using (FormPrincipal frmPrincipal = new FormPrincipal(nombreCompleto, rol))
                {
                    frmPrincipal.ShowDialog();
                }

                // Al cerrar el FormPrincipal, cerramos la aplicación
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
        private void MostrarBienvenidaFlotante(string nombre, string rol)
        {
            using (Form toast = new Form())
            {
                toast.FormBorderStyle = FormBorderStyle.None;
                toast.StartPosition = FormStartPosition.CenterScreen;
                toast.Size = new Size(440, 125);
                toast.BackColor = Color.FromArgb(34, 36, 40);
                toast.TopMost = true;
                toast.ShowInTaskbar = false;

                // Pintado de bordes
                toast.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    // Borde exterior sutil
                    using (Pen penBorde = new Pen(Color.FromArgb(60, 63, 68), 1))
                    {
                        e.Graphics.DrawRectangle(penBorde, 0, 0, toast.Width - 1, toast.Height - 1);
                    }

                    // Barra lateral izquierda decorativa en ocre
                    using (Brush brushOcre = new SolidBrush(Color.FromArgb(212, 131, 53)))
                    {
                        e.Graphics.FillRectangle(brushOcre, 0, 0, 5, toast.Height);
                    }

                    // Icono de verificación circular en ocre
                    using (Pen penCirculo = new Pen(Color.FromArgb(212, 131, 53), 2.2f))
                    using (Pen penCheck = new Pen(Color.White, 2.2f))
                    {
                        e.Graphics.DrawEllipse(penCirculo, 24, 38, 44, 44);

                        // Trazo del check / tilde interior
                        PointF[] checkPoints = {
                    new PointF(35f, 60f),
                    new PointF(43f, 68f),
                    new PointF(56f, 50f)
                };
                        e.Graphics.DrawLines(penCheck, checkPoints);
                    }
                };

                // Saludo principal 
                Label lblHola = new Label
                {
                    Text = $"¡Bienvenido, {nombre}!",
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(245, 245, 245),
                    Location = new Point(84, 32),
                    AutoSize = true
                };

                // Rol activo destacado en ocre suave
                Label lblRol = new Label
                {
                    Text = $"Perfil: {rol.ToUpper()}",
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(212, 131, 53), // Ocre
                    Location = new Point(85, 60),
                    AutoSize = true
                };

                // Mensaje secundario de inicialización
                Label lblCargando = new Label
                {
                    Text = "Cargando espacio de trabajo...",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = new Point(85, 80),
                    AutoSize = true
                };

                toast.Controls.Add(lblHola);
                toast.Controls.Add(lblRol);
                toast.Controls.Add(lblCargando);

                // Tiempo para cierre fluido tras 1.3 segundos
                Timer timerCierre = new Timer { Interval = 1300 };
                timerCierre.Tick += (s, e) =>
                {
                    timerCierre.Stop();
                    toast.Close();
                };
                timerCierre.Start();

                toast.ShowDialog();
            }
        }
    }
}
