using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormPersonal : Form
    {
        private DataTable _dtPersonal = new DataTable();
        private int _idUsuarioSeleccionado = 0;

        // ID del usuario que tiene la sesión activa (ej: Gastón, Administrador con ID = 1)
        // Al conectar la Capa Negocio/Sesión, se alimentará de SesionUsuario.IdUsuario
        public int IdUsuarioActualEnSesion { get; set; } = 1;

        public FormPersonal()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private void FormPersonal_Load(object sender, EventArgs e)
        {
            AsignarEstiloEIconos();
            CargarDesplegablesSimulados();
            CargarHistorialPersonalSimulado();

            LimpiarFormulario();
            DGVPersonal.ClearSelection();
            DGVPersonal.CurrentCell = null;
        }

        // =========================================================================
        // 1. ÍCONO VECTORIAL DE PERSONAL Y ESCALADO DE BOTONERA
        // =========================================================================
        private Image GenerarIconoPersonal(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Credencial / Marco de carnet
                    g.DrawRectangle(pen, 4.5f, 5.5f, 23f, 22f);

                    // Ranura superior para la cinta/llavero
                    g.DrawLine(pen, 12f, 8.5f, 20f, 8.5f);

                    // Cabeza / Usuario
                    g.FillEllipse(brush, 12.5f, 11f, 7f, 7f);

                    // Busto / hombros
                    PointF[] busto = new PointF[]
                    {
                        new PointF(9.5f, 23.5f),
                        new PointF(12f, 19.5f),
                        new PointF(20f, 19.5f),
                        new PointF(22.5f, 23.5f)
                    };
                    g.DrawLines(pen, busto);
                }
            }
            return bmp;
        }

        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            if (imagenOriginal == null) return null;

            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return nuevoBitmap;
        }

        private void AsignarEstiloEIconos()
        {
            try
            {
                if (PBIconoTitulo != null)
                {
                    PBIconoTitulo.Image = GenerarIconoPersonal(Color.FromArgb(212, 131, 53));
                }

                BNuevo.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);
                BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BEditar.Image = EscalarIcono(Properties.Resources.boton_editar_blanco, 32, 32);
                BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
                BLimpiar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
            }
            catch
            {
                // Fallback silencioso
            }
        }

        // =========================================================================
        // 2. RESTRICCIONES DE TECLADO Y FILTRADO
        // =========================================================================
        private void InicializarComportamiento()
        {
            // DNI: solo dígitos
            TBDni.MaxLength = 8;
            TBDni.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };

            // CUIL: dígitos y guiones
            TBCuil.MaxLength = 13;
            TBCuil.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
                    e.Handled = true;
            };

            // Teléfono: dígitos continuos y '+' opcional al principio
            TBTelefono.MaxLength = 18;
            TBTelefono.KeyPress += (s, e) =>
            {
                if (char.IsControl(e.KeyChar)) return;
                if (e.KeyChar == '+' && TBTelefono.SelectionStart == 0 && !TBTelefono.Text.Contains("+"))
                    return;
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            ConfigurarFiltrosDinamicos();
        }

        private void ConfigurarFiltrosDinamicos()
        {
            TBBuscar.TextChanged += (s, e) => AplicarFiltroGrilla();
            CBFiltroRol.SelectedIndexChanged += (s, e) => AplicarFiltroGrilla();
            BLimpiarFiltros.Click += (s, e) =>
            {
                TBBuscar.Clear();
                CBFiltroRol.SelectedIndex = -1;
                AplicarFiltroGrilla();
            };
        }

        private void AplicarFiltroGrilla()
        {
            if (_dtPersonal == null || _dtPersonal.DefaultView == null) return;

            string texto = TBBuscar.Text.Trim().Replace("'", "''");
            string filtro = "";

            if (!string.IsNullOrEmpty(texto))
            {
                filtro += $"(ColDni LIKE '%{texto}%' OR ColNombreCompleto LIKE '%{texto}%')";
            }

            if (CBFiltroRol.SelectedIndex != -1 && !string.IsNullOrEmpty(CBFiltroRol.Text))
            {
                string rol = CBFiltroRol.Text.Replace("'", "''");
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"ColRol = '{rol}'";
            }

            _dtPersonal.DefaultView.RowFilter = filtro;
        }

        // =========================================================================
        // 3. DATOS EN MEMORIA
        // =========================================================================
        private void CargarDesplegablesSimulados()
        {
            string[] roles = { "ADMINISTRADOR", "SUPERVISOR", "CAJERO / OPERADOR", "ENCARGADO DE STOCK" };

            CBRol.Items.Clear();
            CBRol.Items.AddRange(roles);
            CBRol.SelectedIndex = -1;

            CBFiltroRol.Items.Clear();
            CBFiltroRol.Items.AddRange(roles);
            CBFiltroRol.SelectedIndex = -1;
        }

        private void CargarHistorialPersonalSimulado()
        {
            if (_dtPersonal.Columns.Count == 0)
            {
                _dtPersonal.Columns.Add("ColIdUsuario", typeof(int));
                _dtPersonal.Columns.Add("ColDni", typeof(string));
                _dtPersonal.Columns.Add("ColCuil", typeof(string));
                _dtPersonal.Columns.Add("ColNombreCompleto", typeof(string));
                _dtPersonal.Columns.Add("ColRol", typeof(string));
                _dtPersonal.Columns.Add("ColTelefono", typeof(string));
                _dtPersonal.Columns.Add("ColEmail", typeof(string));
                _dtPersonal.Columns.Add("ColEstado", typeof(string));

                // Datos de prueba con el Administrador actual (ID = 1)
                _dtPersonal.Rows.Add(1, "38541200", "20-38541200-4", "Gastón Administrador", "ADMINISTRADOR", "3624501122", "gaston@hierroyforja.com", "Habilitado");
                _dtPersonal.Rows.Add(2, "41250390", "27-41250390-3", "Luciana Fernández", "CAJERO / OPERADOR", "3624890011", "luciana.f@hierroyforja.com", "Habilitado");
                _dtPersonal.Rows.Add(3, "39981240", "20-39981240-8", "Marcos Benítez", "ENCARGADO DE STOCK", "3794125588", "marcos.b@hierroyforja.com", "Habilitado");
            }

            DGVPersonal.AutoGenerateColumns = false;
            ColIdUsuario.DataPropertyName = "ColIdUsuario";
            ColDni.DataPropertyName = "ColDni";
            ColCuil.DataPropertyName = "ColCuil";
            ColNombreCompleto.DataPropertyName = "ColNombreCompleto";
            ColRol.DataPropertyName = "ColRol";
            ColTelefono.DataPropertyName = "ColTelefono";
            ColEmail.DataPropertyName = "ColEmail";
            ColEstado.DataPropertyName = "ColEstado";

            DGVPersonal.DataSource = _dtPersonal;
        }

        // =========================================================================
        // 4. ACCIONES DE BOTONES Y VALIDACIÓN DE AUTO-ELIMINACIÓN
        // =========================================================================
        private bool ValidarFormulario(out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(TBDni.Text) || TBDni.Text.Length < 7)
            {
                mensajeError = "Debe ingresar un DNI válido (mínimo 7 u 8 dígitos).";
                TBDni.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBNombre.Text))
            {
                mensajeError = "Debe ingresar el nombre del personal.";
                TBNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBApellido.Text))
            {
                mensajeError = "Debe ingresar el apellido del personal.";
                TBApellido.Focus();
                return false;
            }

            if (CBRol.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar un Rol para el usuario.";
                CBRol.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBUsuario.Text))
            {
                mensajeError = "Debe asignar un nombre de usuario para el login.";
                TBUsuario.Focus();
                return false;
            }

            // REGLA CRÍTICA DE ADMINISTRADOR SOBRE SÍ MISMO
            if (_idUsuarioSeleccionado == IdUsuarioActualEnSesion)
            {
                // No puede cambiarse el rol a uno no-administrador
                if (CBRol.Text != "ADMINISTRADOR")
                {
                    mensajeError = "No puede revocar sus propios privilegios de ADMINISTRADOR mientras mantenga la sesión activa.";
                    CBRol.Text = "ADMINISTRADOR";
                    return false;
                }

                // No puede deshabilitarse a sí mismo
                if (!ChBUsuarioHabilitado.Checked)
                {
                    mensajeError = "No puede deshabilitar su propia cuenta mientras esté en sesión.";
                    ChBUsuarioHabilitado.Checked = true;
                    return false;
                }
            }

            return true;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(error, "Validación de Personal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string estado = ChBUsuarioHabilitado.Checked ? "Habilitado" : "Deshabilitado";
            string nombreCompleto = $"{TBNombre.Text.Trim()} {TBApellido.Text.Trim()}";

            _dtPersonal.Rows.Add(
                _dtPersonal.Rows.Count + 1,
                TBDni.Text.Trim(),
                TBCuil.Text.Trim(),
                nombreCompleto,
                CBRol.Text,
                TBTelefono.Text.Trim(),
                TBEmail.Text.Trim(),
                estado
            );

            MessageBox.Show("Personal registrado con éxito en la vista previa.", "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            TBDni.Focus();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un registro del personal en la grilla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Modo edición activo para el personal: {TBNombre.Text} {TBApellido.Text}", "Edición de Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BDesactivar_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un usuario de la grilla para dar de baja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // REGLA: El administrador no puede darse de baja a sí mismo
            if (_idUsuarioSeleccionado == IdUsuarioActualEnSesion)
            {
                MessageBox.Show(
                    "Operación denegada: Un Administrador no puede darse de baja ni eliminar su propia cuenta en uso.",
                    "Restricción de Seguridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand
                );
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de dar de baja a este usuario?",
                "Dar de Baja Personal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                foreach (DataRow fila in _dtPersonal.Rows)
                {
                    if (Convert.ToInt32(fila["ColIdUsuario"]) == _idUsuarioSeleccionado)
                    {
                        fila["ColEstado"] = "Deshabilitado";
                        break;
                    }
                }
                LimpiarFormulario();
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void DGVPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = DGVPersonal.Rows[e.RowIndex];
            _idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["ColIdUsuario"].Value ?? 0);

            TBDni.Text = fila.Cells["ColDni"].Value?.ToString() ?? "";
            TBCuil.Text = fila.Cells["ColCuil"].Value?.ToString() ?? "";

            // Desglose tentativo de Nombre y Apellido
            string nombreCompleto = fila.Cells["ColNombreCompleto"].Value?.ToString() ?? "";
            string[] partes = nombreCompleto.Split(new[] { ' ' }, 2);
            TBNombre.Text = partes.Length > 0 ? partes[0] : "";
            TBApellido.Text = partes.Length > 1 ? partes[1] : "";

            CBRol.Text = fila.Cells["ColRol"].Value?.ToString() ?? "";
            TBTelefono.Text = fila.Cells["ColTelefono"].Value?.ToString() ?? "";
            TBEmail.Text = fila.Cells["ColEmail"].Value?.ToString() ?? "";

            TBUsuario.Text = TBNombre.Text.ToLower().Trim();
            TBPassword.Clear();

            string estado = fila.Cells["ColEstado"].Value?.ToString() ?? "Habilitado";
            ChBUsuarioHabilitado.Checked = (estado == "Habilitado");

            // Si el seleccionado es el Administrador actual, se bloquea el botón Dar de Baja
            BDesactivar.Enabled = (_idUsuarioSeleccionado != IdUsuarioActualEnSesion);
        }

        private void LimpiarFormulario()
        {
            _idUsuarioSeleccionado = 0;
            TBDni.Clear();
            TBCuil.Clear();
            TBNombre.Clear();
            TBApellido.Clear();
            TBTelefono.Clear();
            TBEmail.Clear();
            CBRol.SelectedIndex = -1;
            TBUsuario.Clear();
            TBPassword.Clear();
            ChBUsuarioHabilitado.Checked = true;

            // Habilita el botón de baja por defecto
            BDesactivar.Enabled = true;

            DGVPersonal.ClearSelection();
            if (DGVPersonal.CurrentCell != null)
                DGVPersonal.CurrentCell = null;
        }
    }
}
