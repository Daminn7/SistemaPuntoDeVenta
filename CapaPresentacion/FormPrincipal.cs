using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        private readonly string _nombreUsuario;
        private readonly string _rolUsuario;
        private Form _formularioActivo = null;
        private Timer _timerReloj;
        public FormPrincipal(string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();
            _nombreUsuario = nombreUsuario;
            _rolUsuario = rolUsuario;
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            /*// Evaluamos el rol del usuario autenticado
            switch (UsuarioSesion.Rol.ToUpper())
            {
                case "COBRANZA":
                case "CAJERO":
                    AbrirFormHijo(new FormCobroCaja());
                    ResaltarBotonActivo(btnCaja);
                    break;

                case "VENDEDOR":
                    AbrirFormHijo(new FormNuevaPreVenta());
                    ResaltarBotonActivo(btnVentas);
                    break;

                case "ADMINISTRADOR":
                default:
                    // Si ya tienes FormDashboard usas ese; si no, FormHistorialVentas
                    AbrirFormHijo(new FormDashboard());
                    ResaltarBotonActivo(btnInicio); // o btnVentas / btnDashboard
                    break;
            }*/

            // 1. Genera los PNGs en la carpeta bin/Debug si aún no existen
            GenerarIconosMenu();

            ConfigurarSesion();
            AplicarPermisosPorRol();   
            IniciarReloj();
            // 5. Abre la pantalla correspondiente sin dejar el contenedor vacío
            //CargarPantallaInicial();
            // Carga inicial automática de la pantalla principal
            BMenuDashboard_Click(null, EventArgs.Empty);

        }
        private void ConfigurarSesion()
        {
            LUsuarioInfo.Text = $"Usuario: {_nombreUsuario} | Rol: {_rolUsuario.ToUpper()}";
        }

        // Restringe el acceso a módulos según el perfil (RF-SEG#01)
        private void AplicarPermisosPorRol()
        {
            switch (_rolUsuario.Trim().ToLower())
            {
                case "vendedor":
                    // Solo consulta catálogo, alta clientes y órdenes
                    BMenuVentas.Visible = true;
                    BMenuClientes.Visible = true;
                    BMenuProductos.Visible = false; // O solo consulta
                    BMenuCaja.Visible = false;
                    BMenuUsuarios.Visible = false;
                    BMenuReportes.Visible = false;
                    break;

                case "cobranza":
                    // Operativo de Caja y Cobranza
                    BMenuVentas.Visible = false;
                    BMenuClientes.Visible = true;
                    BMenuProductos.Visible = false;
                    BMenuCaja.Visible = true;
                    BMenuUsuarios.Visible = false;
                    BMenuReportes.Visible = false;
                    break;

                case "administrador":
                    // Acceso total a todos los módulos
                    BMenuVentas.Visible = true;
                    BMenuClientes.Visible = true;
                    BMenuProductos.Visible = true;
                    BMenuCaja.Visible = true;
                    BMenuUsuarios.Visible = true;
                    BMenuReportes.Visible = true;
                    break;
            }
        }

        private void IniciarReloj()
        {
            _timerReloj = new Timer();
            _timerReloj.Interval = 1000;
            _timerReloj.Tick += (s, e) =>
            {
                if (LFechaHora != null)
                {
                    LFechaHora.Text = $"🕒 {DateTime.Now.ToString("HH:mm:ss")}  •  {DateTime.Now.ToString("dd/MM/yyyy")}";
                }
            };
            _timerReloj.Start();

            // Carga inicial
            if (LFechaHora != null)
            {
                LFechaHora.Text = $"🕒 {DateTime.Now.ToString("HH:mm:ss")}  •  {DateTime.Now.ToString("dd/MM/yyyy")}";
            }
        }

        // Carga la primera pantalla al entrar sin dejar el panel gris vacío
        private void CargarPantallaInicial()
        {
            switch (_rolUsuario.Trim().ToLower())
            {
                case "vendedor":
                    // Cuando crees FormNuevaPreVenta lo activas aquí:
                    // AbrirFormularioEnContenedor<FormNuevaPreVenta>();
                    AbrirFormularioEnContenedor<FormClientes>();
                    break;

                case "cobranza":
                    // Cuando crees FormCobroCaja lo activas aquí:
                    // AbrirFormularioEnContenedor<FormCobroCaja>();
                    AbrirFormularioEnContenedor<FormClientes>();
                    break;

                case "administrador":
                default:
                    // Mientras no exista FormDashboard, arranca en Catálogo
                    AbrirFormularioEnContenedor<FormProductos>();
                    break;
            }
        }

        // Método maestro para abrir cualquier formulario dentro del PContenedor
        public void AbrirFormularioEnContenedor<T>() where T : Form, new()
        {
            // Si ya está abierto el mismo formulario, no lo recreamos
            if (_formularioActivo is T) return;

            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
            }

            _formularioActivo = new T
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            PContenedor.Controls.Clear();
            PContenedor.Controls.Add(_formularioActivo);
            PContenedor.Tag = _formularioActivo;
            _formularioActivo.Show();
        }

        //Generador de Iconos para no exportar una por una cada imagen
        private void GenerarIconosMenu()
        {
            Color colorIcono = Color.FromArgb(212, 131, 53); // Ocre/Dorado
            Color colorFondo = Color.FromArgb(38, 40, 44);   // Mismo fondo de la barra
            Color colorHover = Color.FromArgb(55, 58, 64);   // Resalte suave

            var listaBotones = new (Button boton, string texto, Image icono)[]
            {
                (BMenuVentas, "Ventas", DibujarIconoVentas(colorIcono)),
                (BMenuClientes, "Clientes", DibujarIconoClientes(colorIcono)),
                (BMenuProductos, "Catálogo", DibujarIconoCatalogo(colorIcono)),
                (BMenuCaja, "Caja", DibujarIconoCaja(colorIcono)),
                (BMenuUsuarios, "Personal", DibujarIconoPersonal(colorIcono)),
                (BMenuReportes, "Informes", DibujarIconoInformes(colorIcono))
            };

            int posicionX = 20;  // Margen inicial izquierdo
            int anchoBoton = 160; // Ancho suficiente para que ninguna palabra se corte
            int altoBoton = 60;   // Altura adaptada al panel de 90px
            // Centrado vertical dinámico respecto al panel contenedor (PMenu)
            int posicionY = (PMenu.Height - altoBoton) / 2; // (90 - 70) / 2 = 10
            foreach (var item in listaBotones)
            {
                if (item.boton == null) continue;

                // Dimensiones y posición centrada verticalmente en el panel
                item.boton.Size = new Size(anchoBoton, altoBoton);
                item.boton.Location = new Point(posicionX, posicionY);
                posicionX += anchoBoton + 12; // 12px de separación entre botones

                // Quitamos el Padding lateral que apretaba el texto
                item.boton.Padding = new Padding(12, 0, 8, 0);

                // Estilos
                item.boton.Text = item.texto;
                item.boton.Image = item.icono;
                item.boton.BackColor = colorFondo;
                item.boton.ForeColor = Color.White;
                item.boton.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
                item.boton.FlatStyle = FlatStyle.Flat;
                item.boton.FlatAppearance.BorderSize = 0;
                item.boton.Cursor = Cursors.Hand;
                item.boton.TextImageRelation = TextImageRelation.ImageAboveText;

                // Hover
                item.boton.MouseEnter += (s, e) => ((Button)s).BackColor = colorHover;
                item.boton.MouseLeave += (s, e) => ((Button)s).BackColor = colorFondo;

                //3.Ajusta la alineación visual(icono a la izquierda del texto)
                Button[] botones = { BMenuVentas, BMenuClientes, BMenuProductos, BMenuCaja, BMenuUsuarios, BMenuReportes }; 
                foreach (var btn in botones) { 
                    if (btn != null) { 
                        btn.ImageAlign = ContentAlignment.MiddleLeft; 
                        btn.TextAlign = ContentAlignment.MiddleRight; 
                        btn.TextImageRelation = TextImageRelation.ImageBeforeText; } 
                }
            }
        }

        //Generación de iconos
        private Image DibujarIconoVentas(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 3.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawLines(pen, new[] { 
                        new Point(4, 8), 
                        new Point(11, 8), 
                        new Point(17, 28), 
                        new Point(35, 28), 
                        new Point(39, 14), 
                        new Point(13, 14) });
                    g.FillEllipse(brush, 17, 32, 5.5f, 5.5f);
                    g.FillEllipse(brush, 32, 32, 5.5f, 5.5f);
                }
            }
            return bmp;
        }

        private Image DibujarIconoClientes(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(color))
                using (Pen pen = new Pen(color, 3.0f))
                {
                    g.FillEllipse(brush, 15, 4, 14, 14); // Cabeza
                    using (var p = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        p.AddArc(7, 22, 30, 30, 180, 180);
                        p.CloseFigure();
                        g.FillPath(brush, p);
                    }
                }
            }
            return bmp;
        }

        private Image DibujarIconoCatalogo(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 3.0f))
                {
                    g.DrawPolygon(pen, new[] { new Point(22, 5), new Point(38, 14), new Point(38, 30), new Point(22, 39), new Point(6, 30), new Point(6, 14) });
                    g.DrawLine(pen, 22, 5, 22, 39);
                    g.DrawLine(pen, 6, 14, 22, 22);
                    g.DrawLine(pen, 38, 14, 22, 22);
                }
            }
            return bmp;
        }
        private Image DibujarIconoCaja(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 3.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 5, 11, 34, 22);
                    g.FillEllipse(brush, 18, 18, 8, 8);
                }
            }
            return bmp;
        }

        private Image DibujarIconoPersonal(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 3.0f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 7, 5, 30, 34);
                    g.FillEllipse(brush, 17, 11, 10, 10);
                    g.DrawLine(pen, 13, 30, 31, 30);
                }
            }
            return bmp;
        }

        private Image DibujarIconoInformes(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(color))
                using (Pen pen = new Pen(color, 3.2f))
                {
                    g.DrawLine(pen, 5, 37, 39, 37);
                    g.FillRectangle(brush, 9, 22, 6, 15);
                    g.FillRectangle(brush, 19, 15, 6, 22);
                    g.FillRectangle(brush, 29, 7, 6, 30);
                }
            }
            return bmp;
        }
        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                if (_timerReloj != null)
                {
                    _timerReloj.Stop();
                    _timerReloj.Dispose();
                }
                this.Close();
            }
        }
        // Eventos de los botones de navegación
        private void BMenuProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FormProductos>();
        }

        private void BMenuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FormClientes>();
        }

        private void BMenuVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FormHistorialVentas>();
        }

        private void BMenuCaja_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FormMovimientosCaja>();
        }
        private void BMenuDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FormDashboard>();
        }
    }
}
