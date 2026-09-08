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
    public partial class FormProveedores : Form
    {
        private DataTable _dtProveedores = new DataTable();
        private int _idProveedorSeleccionado = 0;
        public FormProveedores()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            if (PBIconoTitulo != null)
            {
                // Color Ocre (#D48335) para mantener la identidad visual del título
                PBIconoTitulo.Image = GenerarIconoProveedores(Color.FromArgb(212, 131, 53));
            }
            AsignarEstiloEIconos();
            CargarDesplegablesSimulados();
            CargarHistorialProveedoresSimulado();

            // Arranque limpio: panel lateral en blanco y sin fila marcada
            LimpiarFormulario();
            DGVProveedores.ClearSelection();
            DGVProveedores.CurrentCell = null;
        }

        // =========================================================================
        // ÍCONO VECTORIAL: PROVEEDORES (Camión de distribución y logística)
        // =========================================================================
        private Image GenerarIconoProveedores(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Acoplado / Caja de carga del camión (3.5px a 18px)
                    g.DrawRectangle(pen, 3.5f, 8.5f, 15f, 12f);

                    // Cabina de transporte
                    PointF[] cabina = new PointF[]
                    {
                new PointF(18.5f, 12.5f), // Unión con acoplado
                new PointF(23.5f, 12.5f), // Techo cabina
                new PointF(27.5f, 16.5f), // Parabrisas inclinado
                new PointF(27.5f, 20.5f), // Paragolpes delantero
                new PointF(18.5f, 20.5f)  // Chasis inferior cabina
                    };
                    g.DrawLines(pen, cabina);

                    // Ventanilla lateral de la cabina
                    g.DrawLine(pen, 20.5f, 14.5f, 24.5f, 14.5f);

                    // Ruedas del camión (delantera y trasera)
                    g.FillEllipse(brush, 6.5f, 20.5f, 5f, 5f);
                    g.FillEllipse(brush, 21.5f, 20.5f, 5f, 5f);
                }
            }
            return bmp;
        }

        // =========================================================================
        // 1. ESCALADO DE ICONOS (ESTÁNDAR CLIENTES)
        // =========================================================================
        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            if (imagenOriginal == null) return null;

            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
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

        // =========================================================================
        // 2. RESTRICCIONES Y CONFIGURACIONES REACTIVAS
        // =========================================================================
        private void InicializarComportamiento()
        {
            // CUIT solo dígitos y guiones
            TBCuit.MaxLength = 13;
            TBCuit.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
                    e.Handled = true;
            };

            // TELÉFONO: Solo dígitos (sin guiones) y opcionalmente el '+' inicial
            TBTelefono.MaxLength = 18;
            TBTelefono.KeyPress += (s, e) =>
            {
                // Permite teclas de control (borrar, etc.)
                if (char.IsControl(e.KeyChar)) return;

                // Permite '+' solo en la primera posición
                if (e.KeyChar == '+' && TBTelefono.SelectionStart == 0 && !TBTelefono.Text.Contains("+"))
                    return;

                // Bloquea cualquier cosa que no sea número
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // VINCULACIÓN EN CASCADA PROVINCIA -> LOCALIDADES
            CBProvincia.SelectedIndexChanged += (s, e) =>
            {
                CBLocalidad.Items.Clear();

                if (CBProvincia.SelectedIndex != -1 && _localidadesPorProvincia.ContainsKey(CBProvincia.Text))
                {
                    CBLocalidad.Items.AddRange(_localidadesPorProvincia[CBProvincia.Text]);
                    CBLocalidad.Enabled = true;
                    CBLocalidad.SelectedIndex = -1;
                }
                else
                {
                    CBLocalidad.Enabled = false;
                }
            };

            ConfigurarFiltrosDinamicos();
        }

        private void ConfigurarFiltrosDinamicos()
        {
            TBBuscar.TextChanged += (s, e) => AplicarFiltroGrilla();
            CBFiltroLocalidad.SelectedIndexChanged += (s, e) => AplicarFiltroGrilla();
            BLimpiarFiltros.Click += (s, e) =>
            {
                TBBuscar.Clear();
                CBFiltroLocalidad.SelectedIndex = -1;
                AplicarFiltroGrilla();
            };
        }

        private void AplicarFiltroGrilla()
        {
            if (_dtProveedores == null || _dtProveedores.DefaultView == null) return;

            string texto = TBBuscar.Text.Trim().Replace("'", "''");
            string filtro = "";

            if (!string.IsNullOrEmpty(texto))
            {
                filtro += $"(ColCuit LIKE '%{texto}%' OR ColRazonSocial LIKE '%{texto}%' OR ColContacto LIKE '%{texto}%')";
            }

            if (CBFiltroLocalidad.SelectedIndex != -1 && !string.IsNullOrEmpty(CBFiltroLocalidad.Text))
            {
                string loc = CBFiltroLocalidad.Text.Replace("'", "''");
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"ColLocalidad = '{loc}'";
            }

            _dtProveedores.DefaultView.RowFilter = filtro;
        }

        // =========================================================================
        // 3. DATOS SIMULADOS PARA REVISIÓN VISUAL
        // =========================================================================
        private void CargarDesplegablesSimulados()
        {
            // Carga de Provincias
            CBProvincia.Items.Clear();
            CBProvincia.Items.AddRange(_localidadesPorProvincia.Keys.ToArray());
            CBProvincia.SelectedIndex = -1;

            // Localidades arranca vacío hasta que se elija una provincia
            CBLocalidad.Items.Clear();
            CBLocalidad.Enabled = false;

            // Filtro superior de la barra (aquí listamos todas las localidades para búsqueda global)
            CBFiltroLocalidad.Items.Clear();
            var todasLasLocalidades = _localidadesPorProvincia.Values.SelectMany(x => x).Distinct().OrderBy(x => x).ToArray();
            CBFiltroLocalidad.Items.AddRange(todasLasLocalidades);
            CBFiltroLocalidad.SelectedIndex = -1;
        }

        private void CargarHistorialProveedoresSimulado()
        {
            if (_dtProveedores.Columns.Count == 0)
            {
                _dtProveedores.Columns.Add("ColIdProveedor", typeof(int));
                _dtProveedores.Columns.Add("ColCuit", typeof(string));
                _dtProveedores.Columns.Add("ColRazonSocial", typeof(string));
                _dtProveedores.Columns.Add("ColContacto", typeof(string));
                _dtProveedores.Columns.Add("ColTelefono", typeof(string));
                _dtProveedores.Columns.Add("ColEmail", typeof(string));
                _dtProveedores.Columns.Add("ColLocalidad", typeof(string));
                _dtProveedores.Columns.Add("ColDireccion", typeof(string));
                _dtProveedores.Columns.Add("ColEstado", typeof(string));

                _dtProveedores.Rows.Add(1, "30-50001091-2", "Acindar S.A.", "Ing. Carlos Mendoza", "01143209000", "ventas@acindar.com.ar", "Rosario", "Av. San Martín 450", "Habilitado");
                _dtProveedores.Rows.Add(2, "30-54628472-5", "Siderca Techint", "Martín Gómez", "01140182000", "pedidos@tenaris.com", "Buenos Aires", "Leandro N. Alem 1067", "Habilitado");
                _dtProveedores.Rows.Add(3, "30-71452899-4", "Distribuidora Metalúrgica S.R.L.", "Alejandro Varela", "3624458921", "contacto@distrimetal.com.ar", "Resistencia", "Av. Alvear 1850", "Habilitado");
            }

            DGVProveedores.AutoGenerateColumns = false;
            ColIdProveedor.DataPropertyName = "ColIdProveedor";
            ColCuit.DataPropertyName = "ColCuit";
            ColRazonSocial.DataPropertyName = "ColRazonSocial";
            ColContacto.DataPropertyName = "ColContacto";
            ColTelefono.DataPropertyName = "ColTelefono";
            ColEmail.DataPropertyName = "ColEmail";
            ColLocalidad.DataPropertyName = "ColLocalidad";
            ColDireccion.DataPropertyName = "ColDireccion";
            ColEstado.DataPropertyName = "ColEstado";

            DGVProveedores.DataSource = _dtProveedores;
        }
        // Estructura en memoria que simula la relación 1 a N de la base de datos
        private readonly Dictionary<string, string[]> _localidadesPorProvincia = new Dictionary<string, string[]>()
        {
            { "Chaco", new[] { "Resistencia", "Barranqueras", "Fontana", "Presidencia Roque Sáenz Peña", "Villa Ángela", "Charata" } },
            { "Corrientes", new[] { "Corrientes Capital", "Goya", "Paso de los Libres", "Curuzú Cuatiá", "Mercedes", "Bella Vista" } },
            { "Misiones", new[] { "Posadas", "Oberá", "Eldorado", "Puerto Iguazú", "Apóstoles" } },
            { "Santa Fe", new[] { "Santa Fe Capital", "Rosario", "Rafaela", "Venado Tuerto", "Reconquista" } },
            { "Buenos Aires", new[] { "La Plata", "Mar del Plata", "Bahía Blanca", "Tandil", "San Nicolás" , "Buenos Aires", "CABA"} },
        };

        // =========================================================================
        // 4. ACCIONES DE BOTONES
        // =========================================================================
        private bool ValidarFormulario(out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(TBCuit.Text))
            {
                mensajeError = "Debe ingresar el CUIT del proveedor.";
                TBCuit.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBRazonSocial.Text))
            {
                mensajeError = "Debe ingresar la Razón Social o Nombre del proveedor.";
                TBRazonSocial.Focus();
                return false;
            }

            return true;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(error, "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulamos alta en memoria para validación visual
            string estado = ChBProveedorHabilitado.Checked ? "Habilitado" : "Deshabilitado";
            string direccionCompleta = $"{TBCalle.Text.Trim()} {TBNro.Text.Trim()}".Trim();

            _dtProveedores.Rows.Add(
                _dtProveedores.Rows.Count + 1,
                TBCuit.Text.Trim(),
                TBRazonSocial.Text.Trim(),
                TBContacto.Text.Trim(),
                TBTelefono.Text.Trim(),
                TBEmail.Text.Trim(),
                CBLocalidad.Text,
                direccionCompleta,
                estado
            );

            MessageBox.Show("Proveedor registrado con éxito en la vista previa.", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            TBCuit.Focus();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (_idProveedorSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un proveedor de la grilla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Modo edición activado para: {TBRazonSocial.Text}", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BDesactivar_Click(object sender, EventArgs e)
        {
            if (_idProveedorSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un proveedor de la grilla para dar de baja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de dar de baja al proveedor {TBRazonSocial.Text}?",
                "Dar de Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                foreach (DataRow fila in _dtProveedores.Rows)
                {
                    if (Convert.ToInt32(fila["ColIdProveedor"]) == _idProveedorSeleccionado)
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

        private void DGVProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = DGVProveedores.Rows[e.RowIndex];
            _idProveedorSeleccionado = Convert.ToInt32(fila.Cells["ColIdProveedor"].Value ?? 0);

            TBCuit.Text = fila.Cells["ColCuit"].Value?.ToString() ?? "";
            TBRazonSocial.Text = fila.Cells["ColRazonSocial"].Value?.ToString() ?? "";
            TBContacto.Text = fila.Cells["ColContacto"].Value?.ToString() ?? "";
            TBTelefono.Text = fila.Cells["ColTelefono"].Value?.ToString() ?? "";
            TBEmail.Text = fila.Cells["ColEmail"].Value?.ToString() ?? "";

            // Obtener localidad seleccionada
            string localidadGuardada = fila.Cells["ColLocalidad"].Value?.ToString() ?? "";

            // Buscar a qué provincia pertenece para sincronizar ambos combos
            string provEncontrada = _localidadesPorProvincia
                .FirstOrDefault(kvp => kvp.Value.Contains(localidadGuardada)).Key;

            if (!string.IsNullOrEmpty(provEncontrada))
            {
                CBProvincia.Text = provEncontrada;
                CBLocalidad.Text = localidadGuardada;
            }
            else
            {
                CBProvincia.SelectedIndex = -1;
                CBLocalidad.Text = localidadGuardada;
            }

            string dir = fila.Cells["ColDireccion"].Value?.ToString() ?? "";
            TBCalle.Text = dir;
            TBNro.Clear();

            string estado = fila.Cells["ColEstado"].Value?.ToString() ?? "Habilitado";
            ChBProveedorHabilitado.Checked = (estado == "Habilitado");
        }

        private void LimpiarFormulario()
        {
            _idProveedorSeleccionado = 0;
            TBCuit.Clear();
            TBRazonSocial.Clear();
            TBContacto.Clear();
            TBTelefono.Clear();
            TBEmail.Clear();
            TBCalle.Clear();
            TBNro.Clear();

            CBProvincia.SelectedIndex = -1;
            CBLocalidad.Items.Clear();
            CBLocalidad.Enabled = false;

            ChBProveedorHabilitado.Checked = true;

            DGVProveedores.ClearSelection();
            if (DGVProveedores.CurrentCell != null)
                DGVProveedores.CurrentCell = null;
        }
    }
}
