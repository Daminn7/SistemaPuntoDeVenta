using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormModalMovimientoMenor : Form
    {
        private readonly decimal _maximoDisponible;

        public decimal MontoEgreso { get; private set; } = 0m;
        public string MotivoEgreso { get; private set; } = string.Empty;

        public FormModalMovimientoMenor(decimal maximoDisponible)
        {
            InitializeComponent();
            _maximoDisponible = maximoDisponible;
        }

        private void FormModalMovimientoMenor_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

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

        private void BRegistrar_Click(object sender, EventArgs e)
        {
            string textoMonto = TBMonto.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(textoMonto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMonto.Focus();
                return;
            }

            if (monto > _maximoDisponible)
            {
                MessageBox.Show($"El monto no puede superar el efectivo disponible en gaveta ($ {_maximoDisponible:N2}).",
                                "Fondo Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMonto.Focus();
                return;
            }

            string motivo = TBMotivo.Text.Trim();
            if (string.IsNullOrWhiteSpace(motivo) || motivo.Length < 4)
            {
                MessageBox.Show("Debe ingresar un motivo o concepto que justifique el comprobante de salida.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMotivo.Focus();
                return;
            }

            MontoEgreso = monto;
            MotivoEgreso = motivo;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
