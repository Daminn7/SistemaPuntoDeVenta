using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormModalMovimientoMenor : Form
    {
        // Tipo fijo: 1 = Ingreso, 2 = Egreso
        private readonly int _tipoMovimientoId;
        private readonly decimal _maximoDisponible;
        // Propiedades de salida
        public decimal Monto { get; private set; } = 0m;
        public string Motivo { get; private set; } = string.Empty;
        // Compatibilidad con código viejo
        public decimal MontoEgreso => Monto;
        public string MotivoEgreso => Motivo;

        /// <summary>
        /// Constructor nuevo.
        /// tipoMovimientoId: 1 = Ingreso, 2 = Egreso
        /// maximoDisponible: tope para egresos (ignorado en ingresos)
        /// </summary>
        public FormModalMovimientoMenor(int tipoMovimientoId, decimal maximoDisponible)
        {
            InitializeComponent();
            _tipoMovimientoId = tipoMovimientoId;
            _maximoDisponible = maximoDisponible;
        }
        // Constructor viejo (compatibilidad con el código anterior)
        public FormModalMovimientoMenor(decimal maximoDisponible)
            : this(2, maximoDisponible)
        {
        }
        // LOAD: Configurar título/colores según tipo
        private void FormModalMovimientoMenor_Load(object sender, EventArgs e)
        {
            if (_tipoMovimientoId == 1)
            {
                // INGRESO
                LTitulo.Text = "REGISTRAR INGRESO";
                LTitulo.ForeColor = Color.FromArgb(39, 174, 96);
                PFranjaColor.BackColor = Color.FromArgb(39, 174, 96);
                BRegistrar.BackColor = Color.FromArgb(39, 174, 96);
                TBTipo.Text = "INGRESO";
                LMonto.Text = "Importe a Ingresar ($): *";
                LSubtitulo.Text = "Agregar efectivo a la gaveta de la caja";
            }
            else
            {
                // EGRESO
                LTitulo.Text = "REGISTRAR EGRESO";
                LTitulo.ForeColor = Color.FromArgb(192, 57, 43);
                PFranjaColor.BackColor = Color.FromArgb(192, 57, 43);
                BRegistrar.BackColor = Color.FromArgb(192, 57, 43);
                TBTipo.Text = "EGRESO";
                LMonto.Text = "Importe a Retirar ($): *";
                LSubtitulo.Text = "Extraer efectivo de la gaveta de la caja";
            }
        }
        // Paint del borde
        private void FormModalMovimientoMenor_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
        // KeyPress del monto
        private void TBMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (TBMonto.Text.Contains(",") || TBMonto.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
                e.KeyChar = ',';
                return;
            }

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        // Botón Registrar
        private void BRegistrar_Click(object sender, EventArgs e)
        {
            // 1) Validar monto
            string textoMonto = TBMonto.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(textoMonto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMonto.Focus();
                return;
            }

            // 2) Si es egreso, validar que no supere el disponible
            if (_tipoMovimientoId == 2 && monto > _maximoDisponible)
            {
                MessageBox.Show($"El monto no puede superar el efectivo disponible en gaveta ($ {_maximoDisponible:N2}).",
                                "Fondo Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMonto.Focus();
                return;
            }

            // 3) Validar concepto
            string motivo = TBMotivo.Text.Trim();
            if (string.IsNullOrWhiteSpace(motivo) || motivo.Length < 4)
            {
                MessageBox.Show("Debe ingresar un concepto que justifique el movimiento de efectivo.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMotivo.Focus();
                return;
            }

            // 4) Guardar resultados
            Monto = monto;
            Motivo = motivo;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}