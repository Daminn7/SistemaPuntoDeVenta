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
    public partial class FormMovimientosCaja : Form
    {
        public FormMovimientosCaja()
        {
            InitializeComponent();
        }

        private void FormMovimientosCaja_Load(object sender, EventArgs e)
        {
            // Genera el icono vectorial del título en ocre
            pbIconoTitulo.Image = GenerarIconoCaja(Color.FromArgb(212, 131, 53));
            InicializarTablaBalance();
        }

        private Image GenerarIconoCaja(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Cuerpo de la caja / caja registradora con márgenes seguros de 3.5px
                    g.DrawRectangle(pen, 3.5f, 6.5f, 25f, 18f);

                    // Gaveta / ranura inferior
                    g.DrawLine(pen, 3.5f, 19.5f, 28.5f, 19.5f);

                    // Perno / cerradura central
                    g.FillEllipse(brush, 13.5f, 10.5f, 5f, 5f);

                    // Patas de la caja
                    g.FillRectangle(brush, 5.5f, 24.5f, 4f, 2f);
                    g.FillRectangle(brush, 22.5f, 24.5f, 4f, 2f);
                }
            }
            return bmp;
        }
        private void InicializarTablaBalance()
        {
            dgvBalance.Rows.Clear();
            // Agregamos las filas
            int idxInicial = dgvBalance.Rows.Add("Fondo Inicial", "$ 0,00");
            int idxVentas = dgvBalance.Rows.Add("Ventas en Efectivo (+)", "$ 0,00");
            int idxDigital = dgvBalance.Rows.Add("Cobros Digitales / QR (+)", "$ 0,00");
            int idxIngreso = dgvBalance.Rows.Add("Ingresos Manuales (+)", "$ 0,00");
            int idxEgreso = dgvBalance.Rows.Add("Retiros / Gastos (-)", "$ 0,00");

            // Colores semánticos directos en los montos para máxima legibilidad
            dgvBalance.Rows[idxVentas].Cells[1].Style.ForeColor = Color.FromArgb(39, 174, 96);   // Verde
            dgvBalance.Rows[idxDigital].Cells[1].Style.ForeColor = Color.FromArgb(39, 174, 96);  // Verde
            dgvBalance.Rows[idxIngreso].Cells[1].Style.ForeColor = Color.FromArgb(39, 174, 96);  // Verde
            dgvBalance.Rows[idxEgreso].Cells[1].Style.ForeColor = Color.FromArgb(192, 57, 43); // Rojo
            dgvBalance.ClearSelection();
        }
    }
}
