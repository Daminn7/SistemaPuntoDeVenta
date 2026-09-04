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
    public partial class FormDashboard : Form
    {
        // Paleta aplicación
        private readonly Color ColorOcre = Color.FromArgb(212, 131, 53);
        private readonly Color ColorVerde = Color.FromArgb(39, 174, 96);
        private readonly Color ColorGrafito = Color.FromArgb(38, 40, 44);
        private readonly Color ColorRojoAlerta = Color.FromArgb(192, 57, 43);
        private readonly Color ColorBordeCard = Color.FromArgb(226, 221, 214);
        public FormDashboard()
        {
            InitializeComponent();
            // Generación de icono vectorial en el constructor para evitar PictureBox vacío
            if (pbIconoTitulo != null)
                pbIconoTitulo.Image = GenerarIconoDashboard(Color.FromArgb(212, 131, 53));
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            CargarDatosMuestra();
           // if (pbIconoTitulo != null)
             //   pbIconoTitulo.Image = GenerarIconoDashboard(ColorOcre);

            ConfigurarEstilosVisualesCards();
        }
        private void ConfigurarEstilosVisualesCards()
        {
            // Pinta una línea superior de acento temático y un borde fino a cada KPI
            pnlKpiVentas.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiVentas, ColorOcre);
            pnlKpiCaja.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiCaja, ColorVerde);
            pnlKpiClientes.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiClientes, ColorGrafito);
            pnlKpiStock.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiStock, ColorRojoAlerta);

            // Borde sutil a las tarjetas contenedoras de las tablas
            pnlCardIzquierda.Paint += (s, e) => DibujarBordeSimple(e.Graphics, pnlCardIzquierda);
            pnlCardDerecha.Paint += (s, e) => DibujarBordeSimple(e.Graphics, pnlCardDerecha);

            // Formateo condicional en la celda de stock
            dgvStockCritico.CellFormatting += DgvStockCritico_CellFormatting;
        }
        private void DibujarAcentoCard(Graphics g, Control ctrl, Color colorAcento)
        {
            g.SmoothingMode = SmoothingMode.None;

            // Relleno blanco asegurado
            using (Brush brushBlanco = new SolidBrush(Color.White))
            {
                g.FillRectangle(brushBlanco, 0, 0, ctrl.Width, ctrl.Height);
            }

            // Borde perimetral fino
            using (Pen penBorde = new Pen(ColorBordeCard, 1))
            {
                g.DrawRectangle(penBorde, 0, 0, ctrl.Width - 1, ctrl.Height - 1);
            }

            // Franja de acento superior (4px)
            using (Brush brushAcento = new SolidBrush(colorAcento))
            {
                g.FillRectangle(brushAcento, 1, 1, ctrl.Width - 2, 4);
            }
        }

        private void DibujarBordeSimple(Graphics g, Control ctrl)
        {
            g.SmoothingMode = SmoothingMode.None;
            using (Pen penBorde = new Pen(ColorBordeCard, 1))
            {
                g.DrawRectangle(penBorde, 0, 0, ctrl.Width - 1, ctrl.Height - 1);
            }
        }

        private void DgvStockCritico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Resalta con fondo rojo suave las celdas de stock bajo
            if (dgvStockCritico.Columns[e.ColumnIndex].Name == "colStockActual" && e.Value != null)
            {
                e.CellStyle.BackColor = Color.FromArgb(253, 237, 236);
                e.CellStyle.ForeColor = ColorRojoAlerta;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        public void CargarDatosMuestra()
        {
            // Métricas KPI
            lblKpiVentasValor.Text = "$ 148.500,00";
            lblKpiVentasSub.Text = "12 comprobantes emitidos hoy";

            lblKpiCajaValor.Text = "$ 92.300,00";
            lblKpiCajaSub.Text = "Turno en curso";

            lblKpiClientesValor.Text = "48";
            lblKpiClientesSub.Text = "3 incorporados este mes";

            lblKpiStockValor.Text = "4";
            lblKpiStockSub.Text = "Insumos bajo el nivel seguro";

            // Últimas ventas registradas
            dgvUltimasVentas.Rows.Clear();
            dgvUltimasVentas.Rows.Add("1", "18:42", "FAC-B 0001-0000142", "Herrería San José", "$ 45.200,00");
            dgvUltimasVentas.Rows.Add("2", "17:15", "REC-X 0001-0000089", "Consumidor Final", "$ 12.800,00");
            dgvUltimasVentas.Rows.Add("3", "15:30", "FAC-A 0001-0000210", "Metalúrgica Del Nordeste", "$ 78.000,00");
            dgvUltimasVentas.Rows.Add("4", "11:05", "REC-X 0001-0000088", "Carlos Romero", "$ 12.500,00");
            dgvUltimasVentas.ClearSelection();

            // Stock crítico
            dgvStockCritico.Rows.Clear();
            dgvStockCritico.Rows.Add("HI-014", "Hierro Ángulo 1 1/2 x 1/8", "3", "10");
            dgvStockCritico.Rows.Add("EL-6013", "Electrodo Punta Azul 2.5mm", "2", "8");
            dgvStockCritico.Rows.Add("CH-C20", "Chapa Negra Lisa C20", "1", "5");
            dgvStockCritico.Rows.Add("DI-CUT", "Disco Corte Acero 115mm", "4", "15");
            dgvStockCritico.ClearSelection();
        }

        private Image GenerarIconoDashboard(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Marco de gráfica
                    g.DrawRectangle(pen, 3f, 4f, 26f, 24f);
                    g.DrawLine(pen, 3f, 21f, 29f, 21f);

                    // Barras
                    g.FillRectangle(brush, 7f, 13f, 4f, 8f);
                    g.FillRectangle(brush, 14f, 8f, 4f, 13f);
                    g.FillRectangle(brush, 21f, 11f, 4f, 10f);
                }
            }
            return bmp;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatosMuestra();
        }
    }
}
