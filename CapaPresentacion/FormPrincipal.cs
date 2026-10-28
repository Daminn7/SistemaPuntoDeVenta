using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;      // ✅ Necesario para async/await
using System.Windows.Forms;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        private readonly string _nombreUsuario;
        private readonly string _rolUsuario;
        private Form _formularioActivo = null;
        private Timer _timerReloj;
        private Button _botonMenuActivo = null;
        private bool _cierreConfirmado = false;
        private bool _cerrandoSesion = false;
        // Paleta de colores
        private readonly Color ColorOcre = Color.FromArgb(212, 131, 53);
        private readonly Color ColorGrafito = Color.FromArgb(38, 40, 44);
        private readonly Color ColorHover = Color.FromArgb(55, 58, 64);
        private readonly Color ColorBotonActivo = Color.FromArgb(48, 51, 57);

        public FormPrincipal(string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();
            _nombreUsuario = nombreUsuario;
            _rolUsuario = rolUsuario;
            SesionUsuario.Nombre = nombreUsuario;
            SesionUsuario.Rol = rolUsuario?.ToUpper() ?? "ADMINISTRADOR";
            this.FormClosing += FormPrincipal_FormClosing;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.FromHandle(this.Handle).Bounds;
            ConfigurarBotonLogoInicio();
            GenerarIconosMenu();
            ConfigurarSesion();
            IniciarReloj();
            AplicarPermisosPorRol();
        }

        private void ConfigurarSesion()
        {
            if (LUsuarioInfo != null)
                LUsuarioInfo.Text = $"Usuario: {_nombreUsuario} | Rol: {_rolUsuario.ToUpper()}";
        }

        private void ConfigurarBotonLogoInicio()
        {
            Control[] posiblesLogos = this.Controls.Find("LTitulo", true);
            if (posiblesLogos.Length > 0)
            {
                Control lblLogo = posiblesLogos[0];
                lblLogo.Cursor = Cursors.Hand;
                lblLogo.Click += (s, e) => IrAlDashboard();
            }
            Control[] posiblesPanelesLogo = this.Controls.Find("PLogo", true);
            if (posiblesPanelesLogo.Length > 0)
            {
                posiblesPanelesLogo[0].Cursor = Cursors.Hand;
                posiblesPanelesLogo[0].Click += (s, e) => IrAlDashboard();
            }
        }

        private void IrAlDashboard()
        {
            ResaltarBotonActivo(null);
            AbrirFormularioEnContenedor<FormDashboard>();
        }

        private void AplicarPermisosPorRol()
        {
            string rolActual = (SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();
            string nombreUsuario = SesionUsuario.Nombre ?? "Usuario Activo";

            if (LUsuarioInfo != null)
            {
                LUsuarioInfo.Text = $"Operador: {nombreUsuario}  |  Rol: {rolActual}";
            }

            OcultarTodosLosBotonesMenu();

            switch (rolActual)
            {
                case "VENDEDOR":
                    ConfigurarMenuVendedor();
                    break;

                case "CAJERO":
                case "CAJERO / OPERADOR":
                case "OPERADOR":
                    ConfigurarMenuCajero();
                    break;

                case "ADMINISTRADOR":
                default:
                    ConfigurarMenuAdministrador();
                    break;
            }
        }

        private void OcultarTodosLosBotonesMenu()
        {
            if (BMenuVentas != null) BMenuVentas.Visible = false;
            if (BMenuClientes != null) BMenuClientes.Visible = false;
            if (BMenuProductos != null) BMenuProductos.Visible = false;
            if (BMenuCaja != null) BMenuCaja.Visible = false;
            if (BMenuCompras != null) BMenuCompras.Visible = false;
            if (BMenuProveedores != null) BMenuProveedores.Visible = false;
            if (BMenuUsuarios != null) BMenuUsuarios.Visible = false;
            if (BMenuReportes != null) BMenuReportes.Visible = false;
            if (BMenuMisVentas != null) BMenuMisVentas.Visible = false;
        }

        private void ConfigurarMenuVendedor()
        {
            if (BMenuVentas != null) { BMenuVentas.Text = "PreVenta"; BMenuVentas.Visible = true; }
            if (BMenuClientes != null) { BMenuClientes.Text = "Clientes"; BMenuClientes.Visible = true; }
            if (BMenuProductos != null) { BMenuProductos.Text = "Ver Productos"; BMenuProductos.Visible = true; }
            if (BMenuMisVentas != null) { BMenuMisVentas.Text = "Mis Ventas"; BMenuMisVentas.Visible = true; }

            BMenuVentas_Click(null, EventArgs.Empty);
        }

        private void ConfigurarMenuCajero()
        {
            if (BMenuCaja != null) { BMenuCaja.Text = "Caja"; BMenuCaja.Visible = true; }
            if (BMenuVentas != null) { BMenuVentas.Text = "Cobro"; BMenuVentas.Visible = true; }
            if (BMenuClientes != null) { BMenuClientes.Text = "Clientes"; BMenuClientes.Visible = true; }
            if (BMenuProductos != null) { BMenuProductos.Text = "Ver Productos"; BMenuProductos.Visible = true; }

            BMenuCaja_Click(BMenuCaja, EventArgs.Empty);
        }

        private void ConfigurarMenuAdministrador()
        {
            if (BMenuVentas != null) { BMenuVentas.Text = "Ventas"; BMenuVentas.Visible = true; }
            if (BMenuClientes != null) { BMenuClientes.Text = "Clientes"; BMenuClientes.Visible = true; }
            if (BMenuProductos != null) { BMenuProductos.Text = "Productos"; BMenuProductos.Visible = true; }
            if (BMenuCaja != null) { BMenuCaja.Text = "Caja"; BMenuCaja.Visible = true; }
            if (BMenuCompras != null) { BMenuCompras.Text = "Compras"; BMenuCompras.Visible = true; }
            if (BMenuProveedores != null) { BMenuProveedores.Text = "Proveedores"; BMenuProveedores.Visible = true; }
            if (BMenuUsuarios != null) { BMenuUsuarios.Text = "Personal"; BMenuUsuarios.Visible = true; }
            if (BMenuReportes != null) { BMenuReportes.Text = "Informes"; BMenuReportes.Visible = true; }

            BMenuDashboard_Click(null, EventArgs.Empty);
        }

        private void IniciarReloj()
        {
            _timerReloj = new Timer { Interval = 1000 };
            _timerReloj.Tick += (s, e) =>
            {
                if (LFechaHora != null)
                    LFechaHora.Text = $"🕒 {DateTime.Now:HH:mm:ss}  •  {DateTime.Now:dd/MM/yyyy}";
            };
            _timerReloj.Start();

            if (LFechaHora != null)
                LFechaHora.Text = $"🕒 {DateTime.Now:HH:mm:ss}  •  {DateTime.Now:dd/MM/yyyy}";
        }

        public void AbrirFormularioEnContenedor<T>() where T : Form, new()
        {
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

        private void ResaltarBotonActivo(Button botonSeleccionado)
        {
            Button[] botones = {
                BMenuVentas, BMenuClientes, BMenuProductos, BMenuCaja,
                BMenuCompras, BMenuProveedores, BMenuUsuarios, BMenuReportes,
                BMenuMisVentas
            };
            foreach (var btn in botones)
            {
                if (btn == null) continue;
                btn.BackColor = ColorGrafito;
            }
            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackColor = ColorBotonActivo;
            }
            _botonMenuActivo = botonSeleccionado;
        }

        private void GenerarIconosMenu()
        {
            var listaBotones = new (Button boton, string texto, Image icono)[]
            {
                (BMenuVentas, "Ventas", DibujarIconoVentas(ColorOcre)),
                (BMenuClientes, "Clientes", DibujarIconoClientes(ColorOcre)),
                (BMenuProductos, "Catálogo", DibujarIconoCatalogo(ColorOcre)),
                (BMenuCaja, "Caja", DibujarIconoCaja(ColorOcre)),
                (BMenuCompras, "Compras", DibujarIconoCompras(ColorOcre)),
                (BMenuProveedores, "Proveedores", DibujarIconoProveedores(ColorOcre)),
                (BMenuUsuarios, "Personal", DibujarIconoPersonal(ColorOcre)),
                (BMenuReportes, "Informes", DibujarIconoInformes(ColorOcre)),
                (BMenuMisVentas, "Mis Ventas", DibujarIconoMisVentas(ColorOcre))
            };
            int altoBoton = 56;
            int anchoEstandar = 145;
            foreach (var item in listaBotones)
            {
                if (item.boton == null) continue;

                int anchoActual = (item.boton == BMenuProveedores) ? 170 : anchoEstandar;

                item.boton.Size = new Size(anchoActual, altoBoton);
                item.boton.Margin = new Padding(2, 0, 4, 0);
                item.boton.Padding = new Padding(6, 0, 6, 0);

                item.boton.Text = item.texto;
                item.boton.Image = item.icono;
                item.boton.BackColor = ColorGrafito;
                item.boton.ForeColor = Color.White;
                item.boton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                item.boton.FlatStyle = FlatStyle.Flat;
                item.boton.FlatAppearance.BorderSize = 0;
                item.boton.Cursor = Cursors.Hand;
                item.boton.ImageAlign = ContentAlignment.MiddleLeft;
                item.boton.TextAlign = ContentAlignment.MiddleRight;
                item.boton.TextImageRelation = TextImageRelation.ImageBeforeText;

                item.boton.MouseEnter += (s, e) =>
                {
                    Button b = (Button)s;
                    if (b != _botonMenuActivo) b.BackColor = ColorHover;
                };

                item.boton.MouseLeave += (s, e) =>
                {
                    Button b = (Button)s;
                    if (b != _botonMenuActivo) b.BackColor = ColorGrafito;
                };
            }
        }

        // (Acá van los métodos de dibujo de íconos, que ya están en tu archivo, no los toques)
        // Icono Compras: Carrito con flecha hacia abajo
        private Image DibujarIconoCompras(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.8f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawLines(pen, new[] {
                        new Point(6, 12), new Point(12, 12), new Point(16, 30),
                        new Point(34, 30), new Point(38, 16), new Point(14, 16)
                    });
                    g.FillEllipse(brush, 17, 33, 4.5f, 4.5f);
                    g.FillEllipse(brush, 31, 33, 4.5f, 4.5f);
                    g.DrawLine(pen, 25, 6, 25, 22);
                    g.DrawLine(pen, 21, 18, 25, 22);
                    g.DrawLine(pen, 29, 18, 25, 22);
                }
            }
            return bmp;
        }

        // Icono Proveedores: Camión de suministros / Fábrica
        private Image DibujarIconoProveedores(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.8f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 5, 12, 20, 18);
                    Point[] cabina = {
                        new Point(25, 18),
                        new Point(33, 18),
                        new Point(38, 23),
                        new Point(38, 30),
                        new Point(25, 30)
                    };
                    g.DrawPolygon(pen, cabina);
                    g.FillEllipse(brush, 10, 30, 6, 6);
                    g.FillEllipse(brush, 30, 30, 6, 6);
                }
            }
            return bmp;
        }

        private Image DibujarIconoVentas(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 3f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawLines(pen, new[] {
                        new Point(4, 10), new Point(11, 10), new Point(17, 28),
                        new Point(34, 28), new Point(38, 15), new Point(13, 15)
                    });
                    g.FillEllipse(brush, 17, 31, 5f, 5f);
                    g.FillEllipse(brush, 31, 31, 5f, 5f);
                }
            }
            return bmp;
        }

        private Image DibujarIconoClientes(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, 15, 6, 14, 14);
                    using (var p = new GraphicsPath())
                    {
                        p.AddArc(7, 23, 30, 26, 180, 180);
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
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.8f))
                {
                    g.DrawPolygon(pen, new[] {
                        new Point(22, 5), new Point(38, 14), new Point(38, 30),
                        new Point(22, 39), new Point(6, 30), new Point(6, 14)
                    });
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
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 3f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 5, 12, 34, 21);
                    g.FillEllipse(brush, 18, 19, 8, 8);
                }
            }
            return bmp;
        }

        private Image DibujarIconoPersonal(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.8f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 8, 6, 28, 32);
                    g.FillEllipse(brush, 17, 12, 10, 10);
                    g.DrawLine(pen, 13, 29, 31, 29);
                }
            }
            return bmp;
        }

        private Image DibujarIconoInformes(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(color))
                using (Pen pen = new Pen(color, 3f))
                {
                    g.DrawLine(pen, 5, 36, 39, 36);
                    g.FillRectangle(brush, 9, 22, 6, 14);
                    g.FillRectangle(brush, 19, 15, 6, 21);
                    g.FillRectangle(brush, 29, 8, 6, 28);
                }
            }
            return bmp;
        }

        private Image DibujarIconoMisVentas(Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.8f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 8, 6, 28, 32);
                    g.DrawLine(pen, 14, 14, 26, 14);
                    g.DrawLine(pen, 14, 20, 30, 20);
                    PointF[] check = new PointF[]
                    {
                        new PointF(14, 28),
                        new PointF(19, 32),
                        new PointF(29, 24)
                    };
                    g.DrawLines(pen, check);
                }
            }
            return bmp;
        }

        private bool ConfirmarCierreSesion()
        {
            using (Form modal = new Form())
            {
                modal.FormBorderStyle = FormBorderStyle.None;
                modal.StartPosition = FormStartPosition.CenterParent;
                modal.Size = new Size(420, 160);
                modal.BackColor = Color.FromArgb(34, 36, 40);
                modal.ShowInTaskbar = false;

                modal.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
                    {
                        e.Graphics.DrawRectangle(penBorde, 0, 0, modal.Width - 1, modal.Height - 1);
                    }

                    using (Brush brushOcre = new SolidBrush(ColorOcre))
                    {
                        e.Graphics.FillRectangle(brushOcre, 0, 0, 5, modal.Height);
                    }

                    using (Pen penCirculo = new Pen(ColorOcre, 2.2f))
                    {
                        e.Graphics.DrawEllipse(penCirculo, 24, 40, 42, 42);
                    }
                    using (Font fontSigno = new Font("Segoe UI", 18F, FontStyle.Bold))
                    using (Brush brushBlanco = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString("?", fontSigno, brushBlanco, 34, 43);
                    }
                };

                Label lblTitulo = new Label
                {
                    Text = "CERRAR SESIÓN",
                    Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                    ForeColor = ColorOcre,
                    Location = new Point(82, 24),
                    AutoSize = true
                };
                Label lblMensaje = new Label
                {
                    Text = "¿Desea cerrar la sesión actual y salir del sistema?",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(230, 230, 230),
                    Location = new Point(83, 50),
                    Size = new Size(315, 40)
                };
                Button btnSi = new Button
                {
                    Text = "Sí, Salir",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    BackColor = Color.FromArgb(192, 57, 43),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(100, 34),
                    Location = new Point(190, 105),
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.Yes
                };
                btnSi.FlatAppearance.BorderSize = 0;
                Button btnNo = new Button
                {
                    Text = "Cancelar",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    BackColor = Color.FromArgb(60, 63, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(100, 34),
                    Location = new Point(300, 105),
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.No
                };
                btnNo.FlatAppearance.BorderSize = 0;

                modal.Controls.Add(lblTitulo);
                modal.Controls.Add(lblMensaje);
                modal.Controls.Add(btnSi);
                modal.Controls.Add(btnNo);
                modal.AcceptButton = btnSi;
                modal.CancelButton = btnNo;

                return modal.ShowDialog(this) == DialogResult.Yes;
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cerrandoSesion) return;

            if (_cierreConfirmado) return;

            if (ConfirmarCierreSesion())
            {
                _cierreConfirmado = true;
                DetenerReloj();
            }
            else
            {
                e.Cancel = true;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (_cerrandoSesion)
            {
                Application.Restart();
            }
        }

        private void DetenerReloj()
        {
            if (_timerReloj != null)
            {
                _timerReloj.Stop();
                _timerReloj.Dispose();
                _timerReloj = null;
            }
        }

        // ✅ CORREGIDO: Ahora es async void para no bloquear la UI
        private async void BCerrarSesion_Click(object sender, EventArgs e)
        {
            string rol = (SesionUsuario.Rol ?? "").Trim().ToUpper();

            // ✅ Si es cajero, verificar que no tenga caja abierta (sin bloquear la UI)
            if (rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                try
                {
                    var cajaLogica = new CajaLogica();
                    var cajaActiva = await cajaLogica.ObtenerActiva();

                    if (cajaActiva != null && cajaActiva.Id > 0)
                    {
                        MessageBox.Show(
                            $"No puede cerrar sesión porque tiene la Caja {cajaActiva.NumeroCaja} abierta.\n\n" +
                            "Debe realizar el cierre y arqueo de caja antes de salir.",
                            "Cierre de Caja Pendiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Verificación de caja: {ex.Message}");
                }
            }

            if (ConfirmarCierreSesion())
            {
                _cerrandoSesion = true;
                DetenerReloj();
                this.Close();
            }
        }

        private void BMenuProductos_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuProductos);
            AbrirFormularioEnContenedor<FormProductos>();
        }
        private void BMenuClientes_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuClientes);
            AbrirFormularioEnContenedor<FormClientes>();
        }
        private void BMenuVentas_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuVentas);

            string rol = (SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();

            switch (rol)
            {
                case "VENDEDOR":
                    AbrirFormularioEnContenedor<FormPreVenta>();
                    break;

                case "CAJERO":
                case "CAJERO / OPERADOR":
                case "OPERADOR":
                    AbrirFormularioEnContenedor<FormCobroVenta>();
                    break;

                case "ADMINISTRADOR":
                default:
                    AbrirFormularioEnContenedor<FormHistorialVentas>();
                    break;
            }
        }
        private void BMenuCaja_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuCaja);

            string rol = (SesionUsuario.Rol ?? "").Trim().ToUpper();
            if (rol == "CAJERO" || rol == "CAJERO / OPERADOR" || rol == "OPERADOR")
            {
                AbrirFormularioEnContenedor<FormCierreCaja>();
            }
            else
            {
                AbrirFormularioEnContenedor<FormMovimientosCaja>();
            }
        }
        private void BMenuCompras_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuCompras);
            AbrirFormularioEnContenedor<FormCompras>();
        }
        private void BMenuProveedores_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuProveedores);
            AbrirFormularioEnContenedor<FormProveedores>();
        }
        private void BMenuUsuarios_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuUsuarios);
            AbrirFormularioEnContenedor<FormPersonal>();
        }
        private void BMenuReportes_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuReportes);
            AbrirFormularioEnContenedor<FormInformes>();
        }
        private void BMenuDashboard_Click(object sender, EventArgs e)
        {
            IrAlDashboard();
        }
        private void BMenuMisVentas_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuMisVentas);
            AbrirFormularioEnContenedor<FormMisVentas>();
        }
    }
}