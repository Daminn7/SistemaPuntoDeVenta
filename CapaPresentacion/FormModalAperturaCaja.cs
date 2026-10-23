using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.DTOs;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class FormModalAperturaCaja : Form
    {
        // ✅ NUEVO: número de caja elegido + fondo
        public int NumeroCajaSeleccionada { get; private set; } = 0;
        public decimal FondoInicial { get; private set; } = 0m;

        private readonly CajaLogica _cajaLogica = new CajaLogica();

        public FormModalAperturaCaja()
        {
            InitializeComponent();
        }

        // ============================================================
        // LOAD: Cargar cajas y deshabilitar las ocupadas
        // ============================================================
        private async void FormModalAperturaCaja_Load(object sender, EventArgs e)
        {
            await CargarCajasAsync();
        }

        private async Task CargarCajasAsync()
        {
            CBCaja.Items.Clear();

            // Números de caja fijos: 1, 2, 3
            var numerosCaja = new[] { 1, 2, 3 };

            // Traer cajas abiertas para saber cuáles están ocupadas
            List<CajaDto> abiertas = new List<CajaDto>();
            try
            {
                abiertas = await _cajaLogica.ObtenerAbiertas();
            }
            catch
            {
                // Si falla, dejamos el combo con las 3 cajas libres
                abiertas = new List<CajaDto>();
            }

            foreach (var numero in numerosCaja)
            {
                var ocupada = abiertas.FirstOrDefault(c => c.NumeroCaja == numero);

                string texto;
                if (ocupada != null)
                {
                    string cajero = string.IsNullOrWhiteSpace(ocupada.PersonalNombre) ? "otro cajero" : ocupada.PersonalNombre;
                    texto = $"Caja {numero} — OCUPADA ({cajero})";
                }
                else
                {
                    texto = $"Caja {numero} — Disponible";
                }

                var item = new CajaComboItem
                {
                    NumeroCaja = numero,
                    Texto = texto,
                    Ocupada = ocupada != null
                };

                CBCaja.Items.Add(item);
            }

            // Seleccionar la primera caja disponible
            var primeraDisponible = CBCaja.Items.Cast<CajaComboItem>().FirstOrDefault(i => !i.Ocupada);
            if (primeraDisponible != null)
            {
                CBCaja.SelectedItem = primeraDisponible;
            }
            else
            {
                CBCaja.SelectedIndex = 0;
            }
        }

        // ============================================================
        // Paint del borde
        // ============================================================
        private void FormModalAperturaCaja_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        // ============================================================
        // KeyPress del monto (solo números y coma)
        // ============================================================
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

        // ============================================================
        // Botón Abrir
        // ============================================================
        private void BAbrir_Click(object sender, EventArgs e)
        {
            // 1) Validar caja seleccionada
            if (!(CBCaja.SelectedItem is CajaComboItem item))
            {
                MessageBox.Show("Debe seleccionar una caja.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBCaja.Focus();
                return;
            }

            if (item.Ocupada)
            {
                MessageBox.Show($"La Caja {item.NumeroCaja} ya está ocupada. Elegí otra.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBCaja.Focus();
                return;
            }

            // 2) Validar monto
            string texto = TBMontoApertura.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto) || monto < 0)
            {
                MessageBox.Show("Debe ingresar un monto numérico válido mayor o igual a 0.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMontoApertura.Focus();
                return;
            }

            NumeroCajaSeleccionada = item.NumeroCaja;
            FondoInicial = monto;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ============================================================
        // Clase auxiliar para el combo
        // ============================================================
        private class CajaComboItem
        {
            public int NumeroCaja { get; set; }
            public string Texto { get; set; }
            public bool Ocupada { get; set; }

            public override string ToString() => Texto;
        }
    }
}