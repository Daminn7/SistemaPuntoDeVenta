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
    public partial class FormModalAperturaCaja : Form
    {
        public decimal FondoInicial { get; private set; } = 0m;

        public FormModalAperturaCaja()
        {
            InitializeComponent();
        }

        private void FormModalAperturaCaja_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void TBMontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (TBMontoApertura.Text.Contains(",") || TBMontoApertura.Text.Contains("."))
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

        private void BAbrir_Click(object sender, EventArgs e)
        {
            string texto = TBMontoApertura.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto) || monto < 0)
            {
                MessageBox.Show("Debe ingresar un monto numérico válido mayor o igual a 0.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMontoApertura.Focus();
                return;
            }

            FondoInicial = monto;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
