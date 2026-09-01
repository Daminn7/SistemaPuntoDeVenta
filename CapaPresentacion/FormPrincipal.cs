using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            GenerarIconosMenu();
            _nombreUsuario = nombreUsuario;
            _rolUsuario = rolUsuario;

            ConfigurarSesion();
            IniciarReloj();
            AplicarPermisosPorRol();   
        }

        private void ConfigurarSesion()
        {
            LUsuarioInfo.Text = $"Usuario: {_nombreUsuario} | Rol: {_rolUsuario.ToUpper()}";
        }

        // Restringe el acceso a módulos según el perfil (RF-SEG#01)
        private void AplicarPermisosPorRol()
        {
            switch (_rolUsuario)
            {
                case "Vendedor":
                    // Solo consulta catálogo, alta clientes y órdenes
                    BMenuVentas.Visible = true;
                    BMenuClientes.Visible = true;
                    BMenuProductos.Visible = false; // O solo consulta
                    BMenuCaja.Visible = false;
                    BMenuUsuarios.Visible = false;
                    BMenuReportes.Visible = false;
                    break;

                case "Cobranza":
                    // Operativo de Caja y Cobranza
                    BMenuVentas.Visible = false;
                    BMenuClientes.Visible = true;
                    BMenuProductos.Visible = false;
                    BMenuCaja.Visible = true;
                    BMenuUsuarios.Visible = false;
                    BMenuReportes.Visible = false;
                    break;

                case "Administrador":
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
            _formularioActivo.BringToFront();
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
            int anchoBoton = 140; // Ancho suficiente para que ninguna palabra se corte
            int altoBoton = 70;   // Altura adaptada al panel de 90px
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
                item.boton.Padding = Padding.Empty;

                // Estilos
                item.boton.Text = item.texto;
                item.boton.Image = item.icono;
                item.boton.BackColor = colorFondo;
                item.boton.ForeColor = Color.White;
                item.boton.Font = new Font("Segoe UI", 9.0f, FontStyle.Bold);
                item.boton.FlatStyle = FlatStyle.Flat;
                item.boton.FlatAppearance.BorderSize = 0;
                item.boton.Cursor = Cursors.Hand;
                item.boton.TextImageRelation = TextImageRelation.ImageAboveText;

                // Hover
                item.boton.MouseEnter += (s, e) => ((Button)s).BackColor = colorHover;
                item.boton.MouseLeave += (s, e) => ((Button)s).BackColor = colorFondo;
            }
        }

        //Generación de iconos
        private Image DibujarIconoVentas(Color color)
        {
            Bitmap bmp = new Bitmap(36, 36);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.5f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawLines(pen, new[] { new Point(3, 6), new Point(9, 6), new Point(14, 23), new Point(29, 23), new Point(32, 12), new Point(10, 12) });
                    g.FillEllipse(brush, 14, 26, 4.5f, 4.5f);
                    g.FillEllipse(brush, 26, 26, 4.5f, 4.5f);
                }
            }
            return bmp;
        }

        private Image DibujarIconoClientes(Color color)
        {
            Bitmap bmp = new Bitmap(36, 36);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(color))
                using (Pen pen = new Pen(color, 2.5f))
                {
                    g.FillEllipse(brush, 12, 3, 12, 12); // Cabeza
                    using (var p = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        p.AddArc(6, 18, 24, 24, 180, 180);
                        p.CloseFigure();
                        g.FillPath(brush, p);
                    }
                }
            }
            return bmp;
        }

        private Image DibujarIconoCatalogo(Color color)
        {
            Bitmap bmp = new Bitmap(36, 36);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.5f))
                {
                    g.DrawPolygon(pen, new[] { new Point(18, 4), new Point(31, 12), new Point(31, 24), new Point(18, 32), new Point(5, 24), new Point(5, 12) });
                    g.DrawLine(pen, 18, 4, 18, 32);
                    g.DrawLine(pen, 5, 12, 18, 18);
                    g.DrawLine(pen, 31, 12, 18, 18);
                }
            }
            return bmp;
        }

        private Image DibujarIconoCaja(Color color)
        {
            Bitmap bmp = new Bitmap(36, 36);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.5f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 4, 9, 28, 18);
                    g.FillEllipse(brush, 15, 15, 6, 6);
                }
            }
            return bmp;
        }

        private Image DibujarIconoPersonal(Color color)
        {
            Bitmap bmp = new Bitmap(36, 36);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.5f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 6, 4, 24, 28);
                    g.FillEllipse(brush, 14, 9, 8, 8);
                    g.DrawLine(pen, 11, 24, 25, 24);
                }
            }
            return bmp;
        }

        private Image DibujarIconoInformes(Color color)
        {
            Bitmap bmp = new Bitmap(36, 36);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(color))
                using (Pen pen = new Pen(color, 2.5f))
                {
                    g.DrawLine(pen, 4, 30, 32, 30);
                    g.FillRectangle(brush, 7, 18, 5, 12);
                    g.FillRectangle(brush, 15, 12, 5, 18);
                    g.FillRectangle(brush, 23, 6, 5, 24);
                }
            }
            return bmp;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // 1. Genera los PNGs en la carpeta bin/Debug si aún no existen
            GenerarIconosMenu();

            // 2. Asigna cada imagen generada a su respectivo botón
            BMenuVentas.Image = Image.FromFile("ico_ventas.png");
            BMenuClientes.Image = Image.FromFile("ico_clientes.png");
            BMenuProductos.Image = Image.FromFile("ico_catalogo.png");
            BMenuCaja.Image = Image.FromFile("ico_caja.png");
            BMenuUsuarios.Image = Image.FromFile("ico_personal.png");
            BMenuReportes.Image = Image.FromFile("ico_informes.png");

            // 3. Ajusta la alineación visual (icono a la izquierda del texto)
            Button[] botones = { BMenuVentas, BMenuClientes, BMenuProductos, BMenuCaja, BMenuUsuarios, BMenuReportes };
            foreach (var btn in botones)
            {
                if (btn != null)
                {
                    btn.ImageAlign = ContentAlignment.MiddleLeft;
                    btn.TextAlign = ContentAlignment.MiddleRight;
                    btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
            }
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
                this.Close();
            }
        }
        // Eventos de los botones de navegación
        private void BMenuProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FormProductos>();
        }
    }
}
