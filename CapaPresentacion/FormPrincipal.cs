using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Button _botonMenuActivo = null;
        private bool _cierreConfirmado = false;
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
            // Guardar en la sesión global
            SesionUsuario.Nombre = nombreUsuario;
            SesionUsuario.Rol = rolUsuario?.ToUpper() ?? "ADMINISTRADOR";
            // Intercepta el cierre de la ventana 'X'
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
            // Carga inicial en el Dashboard
            //IrAlDashboard();
        }
        private void ConfigurarSesion()
        {
            if (LUsuarioInfo != null)
                LUsuarioInfo.Text = $"Usuario: {_nombreUsuario} | Rol: {_rolUsuario.ToUpper()}";
        }
        // Transforma el título HIERRO Y FORJA en un botón de acceso al Dashboard
        private void ConfigurarBotonLogoInicio()
        {
            // Asume que el label o picturebox se llama LTitulo o PBLogo en el designer
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
            ResaltarBotonActivo(null); // Desmarca cualquier botón de módulo
            AbrirFormularioEnContenedor<FormDashboard>();
        }
        // Permisos por rol
        private void AplicarPermisosPorRol()
        {
            // Supongamos que la clase estática de sesión almacena los datos del usuario logueado
            string rolActual = (SesionUsuario.Rol ?? "ADMINISTRADOR").Trim().ToUpper();
            string nombreUsuario = SesionUsuario.Nombre ?? "Usuario Activo";

            LUsuarioInfo.Text = $"Operador: {nombreUsuario}  |  Rol: {rolActual}";

            // Actualiza el indicador visual del usuario en el encabezado
            if (LUsuarioInfo != null)
            {
                LUsuarioInfo.Text = $"Operador: {nombreUsuario}  |  Rol: {rolActual}";
            }
            // 1. Ocultar todos los botones inicialmente para evitar estados inconsistentes
            OcultarTodosLosBotonesMenu();
            // 2. Activar y configurar accesos según el nivel de privilegios
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
        // Rutinas de configuración de menú
        private void OcultarTodosLosBotonesMenu()
        {
            // Asegura que no queden botones visibles residuales
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
            // 1. PreVenta (Presupuestos / Pedidos Mostrador)
            if (BMenuVentas != null)
            {
                BMenuVentas.Text = "PreVenta";
                BMenuVentas.Visible = true;
            }
            // 2. Clientes (Consulta y alta de clientes)
            if (BMenuClientes != null)
            {
                BMenuClientes.Text = "Clientes";
                BMenuClientes.Visible = true;
            }
            // 3. Ver Productos (Catálogo en modo consulta/stock)
            if (BMenuProductos != null)
            {
                BMenuProductos.Text = "Ver Productos";
                BMenuProductos.Visible = true;
            }
            // 4. Mis Ventas (Historial y comisiones del vendedor logueado)
            if (BMenuMisVentas != null)
            {
                BMenuMisVentas.Text = "Mis Ventas";
                BMenuMisVentas.Visible = true;
            }
            // Pantalla por defecto al iniciar sesión: PreVenta
            BMenuVentas_Click(null, EventArgs.Empty);
        }
        private void ConfigurarMenuCajero()
        {
            // 1. Caja (Aperturas, Cierres de caja y arqueo diario)
            if (BMenuCaja != null)
            {
                BMenuCaja.Text = "Caja";
                BMenuCaja.Visible = true;
            }
            // 2. Ventas / Cobranza (Facturación y cobro de pedidos emitidos por preventa)
            if (BMenuVentas != null)
            {
                BMenuVentas.Text = "Cobro";
                BMenuVentas.Visible = true;
            }
            // 3. Clientes (Para asociar comprobantes fiscales o consultar saldo de cuenta)
            if (BMenuClientes != null)
            {
                BMenuClientes.Text = "Clientes";
                BMenuClientes.Visible = true;
            }
            // 4. Ver Productos (Consulta rápida de precios de caja)
            if (BMenuProductos != null)
            {
                BMenuProductos.Text = "Ver Productos";
                BMenuProductos.Visible = true;
            }
            // Al iniciar sesión como Cajero, aterriza directamente en Cobro
            BMenuVentas_Click(BMenuVentas, EventArgs.Empty);
        }
        private void ConfigurarMenuAdministrador()
        {
            // Restaura textos originales y hace visibles todos los módulos
            if (BMenuVentas != null) { BMenuVentas.Text = "Ventas"; BMenuVentas.Visible = true; }
            if (BMenuClientes != null) { BMenuClientes.Text = "Clientes"; BMenuClientes.Visible = true; }
            if (BMenuProductos != null) { BMenuProductos.Text = "Productos"; BMenuProductos.Visible = true; }
            if (BMenuCaja != null) { BMenuCaja.Text = "Caja"; BMenuCaja.Visible = true; }
            if (BMenuCompras != null) { BMenuCompras.Text = "Compras"; BMenuCompras.Visible = true; }
            if (BMenuProveedores != null) { BMenuProveedores.Text = "Proveedores"; BMenuProveedores.Visible = true; }
            if (BMenuUsuarios != null) { BMenuUsuarios.Text = "Personal"; BMenuUsuarios.Visible = true; }
            if (BMenuReportes != null) { BMenuReportes.Text = "Informes"; BMenuReportes.Visible = true; }
            // Pantalla por defecto para Administrador: Dashboard o Catálogo
            BMenuDashboard_Click(null, EventArgs.Empty);
        }
        // Simulación usuario
        public static class SesionUsuario
        {
            public static int IdUsuario { get; set; }
            public static string Nombre { get; set; }

            // Cambia este valor aquí para probar los diferentes perfiles:
            // Opciones: "ADMINISTRADOR", "VENDEDOR", "CAJERO"
            public static string Rol { get; set; }
        }
        //
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
        // Navegación y apertura de formularios hijos
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
        // Generación de botones e iconos vectoriales
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

                // Si es Proveedores le damos más ancho para que nunca se quiebre el texto
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
                    // Canasta
                    g.DrawLines(pen, new[] {
                        new Point(6, 12),
                        new Point(12, 12),
                        new Point(16, 30),
                        new Point(34, 30),
                        new Point(38, 16),
                        new Point(14, 16)
                    });
                    g.FillEllipse(brush, 17, 33, 4.5f, 4.5f);
                    g.FillEllipse(brush, 31, 33, 4.5f, 4.5f);
                    // Flecha de entrada / compra
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
                    // Chasis caja de carga
                    g.DrawRectangle(pen, 5, 12, 20, 18);
                    // Cabina
                    Point[] cabina = {
                        new Point(25, 18),
                        new Point(33, 18),
                        new Point(38, 23),
                        new Point(38, 30),
                        new Point(25, 30)
                    };
                    g.DrawPolygon(pen, cabina);
                    // Ruedas
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
                    // Libreta / Factura de ventas
                    g.DrawRectangle(pen, 8, 6, 28, 32);
                    // Líneas del documento
                    g.DrawLine(pen, 14, 14, 26, 14);
                    g.DrawLine(pen, 14, 20, 30, 20);
                    // Tilde de venta completada en la esquina inferior
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
        // Diálogo personalizado de confirmación de salida
        private bool ConfirmarCierreSesion()
        {
            using (Form modal = new Form())
            {
                modal.FormBorderStyle = FormBorderStyle.None;
                modal.StartPosition = FormStartPosition.CenterParent;
                modal.Size = new Size(420, 160);
                modal.BackColor = Color.FromArgb(34, 36, 40); // color del negocio
                modal.ShowInTaskbar = false;
                // Marco exterior y franja Ocre lateral
                modal.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    // Marco perimetral
                    using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
                    {
                        e.Graphics.DrawRectangle(penBorde, 0, 0, modal.Width - 1, modal.Height - 1);
                    }
                    // Acento lateral izquierdo ocre
                    using (Brush brushOcre = new SolidBrush(ColorOcre))
                    {
                        e.Graphics.FillRectangle(brushOcre, 0, 0, 5, modal.Height);
                    }
                    // Icono interrogación circular en Ocre
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
                    BackColor = Color.FromArgb(192, 57, 43), // Rojo discreto
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
        // Intercepta tanto el botón 'X' de Windows como llamadas directas
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cierreConfirmado) return;

            if (ConfirmarCierreSesion())
            {
                _cierreConfirmado = true;
                if (_timerReloj != null)
                {
                    _timerReloj.Stop();
                    _timerReloj.Dispose();
                }
            }
            else
            {
                e.Cancel = true; // Cancela el cierre de la ventana
            }
        }
        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); // Dispara automáticamente FormPrincipal_FormClosing
        }
        // Eventos de click de navegación
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
                    AbrirFormularioEnContenedor<FormCobroVenta>(); // Terminal de cobro solo para Cajero
                    break;

                case "ADMINISTRADOR":
                default:
                    AbrirFormularioEnContenedor<FormHistorialVentas>(); // Historial para Administrador
                    break;
            }
        }
        private void BMenuCaja_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo(BMenuCaja);

            // Si el rol es Cajero, podés enviarlo a la caja del día o a movimientos:
            if (SesionUsuario.Rol == "CAJERO" || SesionUsuario.Rol == " CAJERO / OPERADOR" || SesionUsuario.Rol == "OPERADOR")
            {
                AbrirFormularioEnContenedor<FormMovimientosCaja>();
            }
            else // ADMINISTRADOR
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
