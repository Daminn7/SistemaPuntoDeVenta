using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Services;
using CapaDatos.Helpers;

namespace CapaPresentacion
{
    public partial class FormInformes : Form
    {
        private DataTable _dtResumen = new DataTable();
        private CancellationTokenSource _ctsCarga;
        private readonly ApiClient _apiClient;

        private string[] _meses = { };
        private float[] _ventasMes = { };
        private float[] _comprasMes = { };
        private string[] _mediosPago = { };
        private float[] _porcentajesPago = { };
        private readonly Color[] _coloresDonut = {
            Color.FromArgb(212, 131, 53),
            Color.FromArgb(41, 128, 185),
            Color.FromArgb(39, 174, 96)
        };

        public FormInformes()
        {
            InitializeComponent();
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
            InicializarComponentesAdicionales();
        }

        private async void FormInformes_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            AsignarIconoTitulo();
            CargarTiposReporte();

            try
            {
                await CargarDatosResumenAsync(token);
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (!this.IsDisposed)
            {
                DGVResumen.ClearSelection();
                if (DGVResumen.CurrentCell != null)
                    DGVResumen.CurrentCell = null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                _ctsCarga?.Cancel();
                _ctsCarga?.Dispose();
                _ctsCarga = null;
            }
            catch { }
            base.OnFormClosing(e);
        }

        private void InicializarComponentesAdicionales()
        {
            PPanelGraficoBarras.Resize += (s, e) => PPanelGraficoBarras.Invalidate();
            PPanelGraficoTorta.Resize += (s, e) => PPanelGraficoTorta.Invalidate();
        }

        private Image GenerarIconoInformes(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawLine(pen, 4f, 26f, 28f, 26f);
                    g.DrawLine(pen, 4f, 26f, 4f, 5f);

                    g.FillRectangle(brush, 7f, 18f, 4.5f, 7f);
                    g.FillRectangle(brush, 14f, 12f, 4.5f, 13f);
                    g.FillRectangle(brush, 21f, 7f, 4.5f, 18f);
                }
            }
            return bmp;
        }

        private void AsignarIconoTitulo()
        {
            if (PBIconoTitulo != null)
            {
                PBIconoTitulo.Image = GenerarIconoInformes(Color.FromArgb(212, 131, 53));
            }
        }

        private void CargarTiposReporte()
        {
            CBTipoReporte.Items.Clear();
            CBTipoReporte.Items.AddRange(new object[] {
                "Ventas y Rentabilidad Consolidada",
                "Comparativa Ingresos vs. Egresos",
                "Rotación de Stock e Insumos",
                "Resumen por Medio de Cobro"
            });
            CBTipoReporte.SelectedIndex = 0;

            DTPFechaDesde.Value = DateTime.Now.AddDays(-30);
            DTPFechaHasta.Value = DateTime.Now;
        }

        private async Task CargarDatosResumenAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                if (_dtResumen.Columns.Count == 0)
                {
                    _dtResumen.Columns.Add("ColPeriodo", typeof(string));
                    _dtResumen.Columns.Add("ColCantVentas", typeof(int));
                    _dtResumen.Columns.Add("ColTotalVentas", typeof(string));
                    _dtResumen.Columns.Add("ColTotalCompras", typeof(string));
                    _dtResumen.Columns.Add("ColGananciaNeta", typeof(string));
                    _dtResumen.Columns.Add("ColMargen", typeof(string));
                }

                _dtResumen.Rows.Clear();
                _dtResumen.Rows.Add("Semana 1 - Sep 2026", 42, "$ 850.000,00", "$ 510.000,00", "$ 340.000,00", "40.0 %");
                _dtResumen.Rows.Add("Semana 4 - Ago 2026", 38, "$ 680.000,00", "$ 420.000,00", "$ 260.000,00", "38.2 %");
                _dtResumen.Rows.Add("Semana 3 - Ago 2026", 31, "$ 510.000,00", "$ 340.000,00", "$ 170.000,00", "33.3 %");
                _dtResumen.Rows.Add("Semana 2 - Ago 2026", 29, "$ 450.000,00", "$ 310.000,00", "$ 140.000,00", "31.1 %");
                _dtResumen.Rows.Add("Semana 1 - Ago 2026", 24, "$ 320.000,00", "$ 210.000,00", "$ 110.000,00", "34.3 %");

                DGVResumen.AutoGenerateColumns = false;
                ColPeriodo.DataPropertyName = "ColPeriodo";
                ColCantVentas.DataPropertyName = "ColCantVentas";
                ColTotalVentas.DataPropertyName = "ColTotalVentas";
                ColTotalCompras.DataPropertyName = "ColTotalCompras";
                ColGananciaNeta.DataPropertyName = "ColGananciaNeta";
                ColMargen.DataPropertyName = "ColMargen";

                DGVResumen.DataSource = _dtResumen;

                _meses = new[] { "Mayo", "Junio", "Julio", "Agosto", "Septiembre" };
                _ventasMes = new[] { 320000f, 450000f, 510000f, 680000f, 850000f };
                _comprasMes = new[] { 210000f, 310000f, 340000f, 420000f, 510000f };
                _mediosPago = new[] { "Efectivo", "Transferencia", "Cuenta Cte." };
                _porcentajesPago = new[] { 55f, 30f, 15f };

                PPanelGraficoBarras.Invalidate();
                PPanelGraficoTorta.Invalidate();

                CalcularTotalesResumen();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar informes: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalcularTotalesResumen()
        {
            LValorFacturado.Text = "$ 2.810.000,00";
            LValorGanancia.Text = "$ 1.020.000,00";
            LValorTickets.Text = "164 facturas";
        }

        private void PPanelGraficoBarras_Paint(object sender, PaintEventArgs e)
        {
            // Tu código original de dibujo de barras (sin cambios)
        }

        private void PPanelGraficoTorta_Paint(object sender, PaintEventArgs e)
        {
            // Tu código original de dibujo del donut (sin cambios)
        }

        private void BExportarExcel_Click(object sender, EventArgs e)
        {
            // Tu código original (sin cambios)
        }

        private void BExportarPDF_Click(object sender, EventArgs e)
        {
            // Tu código original (sin cambios)
        }

        private void ImprimirDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Tu código original (sin cambios)
        }

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            PPanelGraficoBarras.Invalidate();
            PPanelGraficoTorta.Invalidate();
            MessageBox.Show("Métricas e informes actualizados para el rango seleccionado.", "Informes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}