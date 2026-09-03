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
    public partial class FormHistorialVentas : Form
    {
        public FormHistorialVentas()
        {
            InitializeComponent();
        }
        private void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            // Aquí cargaremos los datos iniciales al arrancar la pantalla
            pbIconoTitulo.Image = GenerarIconoHistorial(Color.FromArgb(212, 131, 53));
        }

        private Image GenerarIconoHistorial(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Reloj circular de historial
                    g.DrawEllipse(pen, 3.5f, 3.5f, 24f, 24f);
                    // Agujas del reloj marcando la hora
                    g.DrawLine(pen, 15.5f, 9f, 15.5f, 15.5f);
                    g.DrawLine(pen, 15.5f, 15.5f, 21f, 15.5f);
                    // Centro del reloj
                    g.FillEllipse(brush, 14f, 14f, 3.5f, 3.5f);
                }
            }
            return bmp;
        }

    }
}
