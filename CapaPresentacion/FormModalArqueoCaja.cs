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
    public partial class FormModalArqueoCaja : Form
    {
        private readonly decimal _efectivoEsperado;

        // Propiedades públicas para que FormCierreCaja consuma el resultado
        public decimal EfectivoReal { get; private set; } = 0m;
        public decimal Diferencia { get; private set; } = 0m;
        public string Observaciones { get; private set; } = string.Empty;

        public FormModalArqueoCaja(decimal efectivoEsperado)
        {
            InitializeComponent();
            _efectivoEsperado = efectivoEsperado;
            TBEfectivoEsperado.Text = _efectivoEsperado.ToString("N2");
        }

        private void FormModalArqueoCaja_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void TBEfectivoReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (TBEfectivoReal.Text.Contains(",") || TBEfectivoReal.Text.Contains("."))
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

        private void TBEfectivoReal_TextChanged(object sender, EventArgs e)
        {
            string texto = TBEfectivoReal.Text.Trim().Replace(',', '.');

            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal real))
            {
                decimal diferencia = real - _efectivoEsperado;
                TBDiferencia.Text = diferencia.ToString("N2");

                if (diferencia == 0m)
                {
                    TBDiferencia.ForeColor = Color.FromArgb(39, 174, 96); // Verde: caja cuadrada
                }
                else if (diferencia < 0m)
                {
                    TBDiferencia.ForeColor = Color.FromArgb(231, 76, 60); // Rojo: faltante
                }
                else
                {
                    TBDiferencia.ForeColor = Color.FromArgb(52, 152, 219); // Azul: sobrante
                }
            }
            else
            {
                TBDiferencia.Text = "0,00";
                TBDiferencia.ForeColor = Color.White;
            }
        }

        private void BConfirmarCierre_Click(object sender, EventArgs e)
        {
            string texto = TBEfectivoReal.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal real) || real < 0)
            {
                MessageBox.Show("Debe ingresar un monto válido de efectivo físico en caja.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBEfectivoReal.Focus();
                return;
            }

            decimal diferencia = real - _efectivoEsperado;

            // Si hay descuadre y el cajero no escribió observación, se advierte
            if (diferencia != 0m && string.IsNullOrWhiteSpace(TBObservaciones.Text))
            {
                string tipo = diferencia < 0 ? "FALTANTE" : "SOBRANTE";
                DialogResult advertencia = MessageBox.Show(
                    $"Se detectó un {tipo} de $ {Math.Abs(diferencia):N2} sin justificación.\n\n¿Desea ingresar una observación antes de cerrar?",
                    "Aviso de Descuadre",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (advertencia == DialogResult.Yes)
                {
                    TBObservaciones.Focus();
                    return;
                }
            }

            EfectivoReal = real;
            Diferencia = diferencia;
            Observaciones = TBObservaciones.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
