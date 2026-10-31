using System;
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
using CapaLogica;
using Newtonsoft.Json.Linq;

namespace CapaPresentacion
{
    public partial class FormInformes : Form
    {
        private readonly ReporteLogica _reporteLogica = new ReporteLogica();
        private CancellationTokenSource _ctsCarga;

        // Datos reales para los gráficos
        private string[] _meses = { };
        private float[] _ventasMes = { };
        private float[] _comprasMes = { };
        private string[] _mediosPago = { };
        private float[] _porcentajesPago = { };
        private readonly Color[] _coloresDonut = {
            Color.FromArgb(212, 131, 53),  // Ocre
            Color.FromArgb(41, 128, 185),  // Azul
            Color.FromArgb(39, 174, 96),   // Verde
            Color.FromArgb(155, 89, 182),  // Violeta
            Color.FromArgb(230, 126, 34),  // Naranja
            Color.FromArgb(52, 73, 94)     // Gris oscuro
        };

        public FormInformes()
        {
            InitializeComponent();
            InicializarComponentesAdicionales();

            // NUEVO: Conectar el cambio de tipo de reporte
            CBTipoReporte.SelectedIndexChanged += CBTipoReporte_SelectedIndexChanged;
        }

        private async void FormInformes_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            AsignarIconoTitulo();
            CargarTiposReporte();

            try
            {
                await CargarTodosLosDatosAsync(token);
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
        private async Task CargarProductosMasVendidosAsync()
        {
            try
            {
                var resultado = await _reporteLogica.ObtenerProductosMasVendidos(10);
                if (this.IsDisposed) return;

                if (resultado is JArray productos)
                {
                    var dt = new System.Data.DataTable();
                    dt.Columns.Add("Producto", typeof(string));
                    dt.Columns.Add("Cantidad Vendida", typeof(int));
                    dt.Columns.Add("Total Vendido", typeof(string));

                    foreach (var p in productos)
                    {
                        dt.Rows.Add(
                            p["nombre"]?.ToString() ?? "",
                            p["cantidadVendida"]?.Value<int>() ?? 0,
                            (p["totalVendido"]?.Value<decimal>() ?? 0).ToString("C2")
                        );
                    }

                    // Reconfiguramos las columnas de la grilla temporalmente
                    DGVResumen.SuspendLayout();

                    // Ocultamos las columnas viejas y mostramos las nuevas
                    DGVResumen.DataSource = null;
                    DGVResumen.Columns.Clear();

                    DGVResumen.AutoGenerateColumns = true;
                    DGVResumen.DataSource = dt;

                    DGVResumen.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar productos más vendidos: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        private async Task CargarTodosLosDatosAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                DateTime desde = DTPFechaDesde.Value.Date;
                DateTime hasta = DTPFechaHasta.Value.Date;

                await CargarEvolucionAsync(desde, hasta, token);
                if (token.IsCancellationRequested) return;

                await CargarMediosPagoAsync(desde, hasta, token);
                if (token.IsCancellationRequested) return;

                await CargarRentabilidadAsync(desde, hasta, token);
                if (token.IsCancellationRequested) return;

                if (!this.IsDisposed)
                {
                    PPanelGraficoBarras.Invalidate();
                    PPanelGraficoTorta.Invalidate();
                }
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
        private async Task CargarEvolucionAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            var resultado = await _reporteLogica.ObtenerEvolucion(desde, hasta);
            if (token.IsCancellationRequested || this.IsDisposed) return;

            if (resultado is JObject json)
            {
                var periodos = json["periodos"] as JArray;
                if (periodos == null) return;

                int n = periodos.Count;
                _meses = new string[n];
                _ventasMes = new float[n];
                _comprasMes = new float[n];

                for (int i = 0; i < n; i++)
                {
                    var p = periodos[i];
                    _meses[i] = p["etiqueta"]?.ToString() ?? "";
                    _ventasMes[i] = (float)(p["ingresos"]?.Value<decimal>() ?? 0);
                    _comprasMes[i] = (float)(p["costos"]?.Value<decimal>() ?? 0);
                }

                ActualizarTablaEvolucion(json);
            }
        }
        private void ActualizarTablaEvolucion(JObject json)
        {
            var periodos = json["periodos"] as JArray;
            if (periodos == null) return;

            var dt = new System.Data.DataTable();
            dt.Columns.Add("ColPeriodo", typeof(string));
            dt.Columns.Add("ColCantVentas", typeof(int));
            dt.Columns.Add("ColTotalVentas", typeof(string));
            dt.Columns.Add("ColTotalCompras", typeof(string));
            dt.Columns.Add("ColGananciaNeta", typeof(string));
            dt.Columns.Add("ColMargen", typeof(string));

            foreach (var p in periodos)
            {
                string periodo = p["etiqueta"]?.ToString() ?? "";
                int cantVentas = p["cantidadVentas"]?.Value<int>() ?? 0;
                decimal ingresos = p["ingresos"]?.Value<decimal>() ?? 0;
                decimal costos = p["costos"]?.Value<decimal>() ?? 0;
                decimal margen = p["margen"]?.Value<decimal>() ?? 0;
                decimal porcentajeMargen = ingresos > 0 ? (margen / ingresos) * 100 : 0;

                dt.Rows.Add(
                    periodo,
                    cantVentas,
                    ingresos.ToString("C2"),
                    costos.ToString("C2"),
                    margen.ToString("C2"),
                    $"{porcentajeMargen:F1} %"
                );
            }

            DGVResumen.SuspendLayout();
            DGVResumen.AutoGenerateColumns = false;
            ColPeriodo.DataPropertyName = "ColPeriodo";
            ColCantVentas.DataPropertyName = "ColCantVentas";
            ColTotalVentas.DataPropertyName = "ColTotalVentas";
            ColTotalCompras.DataPropertyName = "ColTotalCompras";
            ColGananciaNeta.DataPropertyName = "ColGananciaNeta";
            ColMargen.DataPropertyName = "ColMargen";
            DGVResumen.DataSource = dt;
            DGVResumen.ResumeLayout();
        }
        private async Task CargarMediosPagoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            var resultado = await _reporteLogica.ObtenerMediosPago(desde, hasta);
            if (token.IsCancellationRequested || this.IsDisposed) return;

            if (resultado is JObject json)
            {
                var medios = json["medios"] as JArray;
                if (medios == null) return;

                int n = medios.Count;
                _mediosPago = new string[n];
                _porcentajesPago = new float[n];

                for (int i = 0; i < n; i++)
                {
                    var m = medios[i];
                    _mediosPago[i] = m["descripcion"]?.ToString() ?? "";
                    _porcentajesPago[i] = (float)(m["porcentaje"]?.Value<decimal>() ?? 0);
                }
            }
        }
        private async Task CargarRentabilidadAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            var resultado = await _reporteLogica.ObtenerRentabilidad(desde, hasta);
            if (token.IsCancellationRequested || this.IsDisposed) return;

            if (resultado is JObject json)
            {
                decimal totalIngresos = json["totalIngresos"]?.Value<decimal>() ?? 0;
                decimal margenBruto = json["margenBruto"]?.Value<decimal>() ?? 0;
                int cantidadVentas = json["cantidadVentas"]?.Value<int>() ?? 0;

                LValorFacturado.Text = totalIngresos.ToString("C2");
                LValorGanancia.Text = margenBruto.ToString("C2");
                LValorTickets.Text = $"{cantidadVentas} facturas";
            }
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

            DTPFechaDesde.Value = DateTime.Now.AddMonths(-6);
            DTPFechaHasta.Value = DateTime.Now;
        }
        // NUEVO: Al cambiar el tipo de reporte, se ocultan/muestran paneles
        private void CBTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBTipoReporte.SelectedIndex < 0) return;

            string opcion = CBTipoReporte.Text;

            switch (opcion)
            {
                case "Ventas y Rentabilidad Consolidada":
                    DGVResumen.Visible = true;
                    PPanelGraficoBarras.Visible = true;
                    PPanelGraficoTorta.Visible = true;

                    // Restaurar las columnas de evolución
                    RestaurarColumnasEvolucion();
                    break;

                case "Comparativa Ingresos vs. Egresos":
                    DGVResumen.Visible = false;
                    PPanelGraficoBarras.Visible = true;
                    PPanelGraficoTorta.Visible = false;
                    break;

                case "Rotación de Stock e Insumos":
                    // Vista de productos más vendidos
                    DGVResumen.Visible = true;
                    PPanelGraficoBarras.Visible = false;
                    PPanelGraficoTorta.Visible = false;

                    // Llamamos a cargar la grilla con productos
                    _ = CargarProductosMasVendidosAsync();
                    break;

                case "Resumen por Medio de Cobro":
                    DGVResumen.Visible = false;
                    PPanelGraficoBarras.Visible = false;
                    PPanelGraficoTorta.Visible = true;
                    break;

                default:
                    DGVResumen.Visible = true;
                    PPanelGraficoBarras.Visible = true;
                    PPanelGraficoTorta.Visible = true;
                    break;
            }

            PPanelGraficoBarras.Invalidate();
            PPanelGraficoTorta.Invalidate();
        }
        private void RestaurarColumnasEvolucion()
        {
            if (DGVResumen.Columns.Count > 0 && DGVResumen.Columns[0].Name == "ColPeriodo") return; // Ya está

            DGVResumen.SuspendLayout();
            DGVResumen.DataSource = null;
            DGVResumen.Columns.Clear();
            DGVResumen.AutoGenerateColumns = false;

            // Recrear columnas
            var colPeriodo = new DataGridViewTextBoxColumn { Name = "ColPeriodo", DataPropertyName = "ColPeriodo", HeaderText = "Período" };
            var colCantVentas = new DataGridViewTextBoxColumn { Name = "ColCantVentas", DataPropertyName = "ColCantVentas", HeaderText = "Comprobantes" };
            var colTotalVentas = new DataGridViewTextBoxColumn { Name = "ColTotalVentas", DataPropertyName = "ColTotalVentas", HeaderText = "Ingresos" };
            var colTotalCompras = new DataGridViewTextBoxColumn { Name = "ColTotalCompras", DataPropertyName = "ColTotalCompras", HeaderText = "Costos" };
            var colGananciaNeta = new DataGridViewTextBoxColumn { Name = "ColGananciaNeta", DataPropertyName = "ColGananciaNeta", HeaderText = "Margen" };
            var colMargen = new DataGridViewTextBoxColumn { Name = "ColMargen", DataPropertyName = "ColMargen", HeaderText = "Rentabilidad" };

            DGVResumen.Columns.AddRange(colPeriodo, colCantVentas, colTotalVentas, colTotalCompras, colGananciaNeta, colMargen);

            // Volver a cargar la evolución (esto rellena los datos)
            _ = CargarEvolucionYTablaAsync();
        }
        private async Task CargarEvolucionYTablaAsync()
        {
            DateTime desde = DTPFechaDesde.Value.Date;
            DateTime hasta = DTPFechaHasta.Value.Date;
            var token = _ctsCarga?.Token ?? CancellationToken.None;
            await CargarEvolucionAsync(desde, hasta, token);
        }
        private void PPanelGraficoBarras_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ancho = PPanelGraficoBarras.Width;
            int alto = PPanelGraficoBarras.Height;

            using (Font fontTitulo = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Brush brushTexto = new SolidBrush(Color.FromArgb(40, 40, 40)))
            {
                g.DrawString("EVOLUCIÓN MENSUAL: INGRESOS VS COSTOS ($)", fontTitulo, brushTexto, 14, 12);
            }

            float margenIzq = 45f;
            float margenDer = 20f;
            float margenSup = 55f;
            float margenInf = 45f;
            float plotAncho = ancho - margenIzq - margenDer;
            float plotAlto = alto - margenSup - margenInf;

            if (plotAncho <= 0 || plotAlto <= 0 || _meses.Length == 0) return;

            using (Pen penEje = new Pen(Color.FromArgb(215, 220, 225), 1.5f))
            {
                g.DrawLine(penEje, margenIzq, margenSup + plotAlto, margenIzq + plotAncho, margenSup + plotAlto);
            }

            float valorMax = 1f;
            foreach (var v in _ventasMes) if (v > valorMax) valorMax = v;
            foreach (var v in _comprasMes) if (v > valorMax) valorMax = v;
            if (valorMax <= 0) valorMax = 1f;

            int cantGrupos = _meses.Length;
            float anchoGrupoIdeal = Math.Min(plotAncho / cantGrupos, 90f);
            float anchoTotalConjunto = anchoGrupoIdeal * cantGrupos;
            float inicioXCentrado = margenIzq + ((plotAncho - anchoTotalConjunto) / 2f);
            float anchoBarra = Math.Min(24f, anchoGrupoIdeal * 0.35f);

            using (Brush bVenta = new SolidBrush(Color.FromArgb(212, 131, 53)))
            using (Brush bCompra = new SolidBrush(Color.FromArgb(90, 95, 100)))
            using (Font fLabels = new Font("Segoe UI", 8f))
            using (Brush bTexto = new SolidBrush(Color.FromArgb(70, 70, 70)))
            {
                for (int i = 0; i < cantGrupos; i++)
                {
                    float centroX = inicioXCentrado + (i * anchoGrupoIdeal) + (anchoGrupoIdeal / 2f);

                    float hVenta = (_ventasMes[i] / valorMax) * plotAlto;
                    float hCompra = (_comprasMes[i] / valorMax) * plotAlto;

                    float xVenta = centroX - anchoBarra - 2f;
                    float yVenta = margenSup + (plotAlto - hVenta);
                    g.FillRectangle(bVenta, xVenta, yVenta, anchoBarra, hVenta);

                    float xCompra = centroX + 2f;
                    float yCompra = margenSup + (plotAlto - hCompra);
                    g.FillRectangle(bCompra, xCompra, yCompra, anchoBarra, hCompra);

                    string label = _meses[i].Length > 3 ? _meses[i].Substring(0, 3) : _meses[i];
                    SizeF sizeMes = g.MeasureString(label, fLabels);
                    g.DrawString(label, fLabels, bTexto, centroX - (sizeMes.Width / 2f), margenSup + plotAlto + 8f);
                }

                g.FillRectangle(bVenta, ancho - 165, 14, 10, 10);
                g.DrawString("Ingresos", fLabels, bTexto, ancho - 150, 12);

                g.FillRectangle(bCompra, ancho - 90, 14, 10, 10);
                g.DrawString("Costos", fLabels, bTexto, ancho - 75, 12);
            }
        }
        private void PPanelGraficoTorta_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ancho = PPanelGraficoTorta.Width;
            int alto = PPanelGraficoTorta.Height;

            using (Font fontTitulo = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Brush brushTexto = new SolidBrush(Color.FromArgb(40, 40, 40)))
            {
                g.DrawString("DISTRIBUCIÓN POR MEDIO DE COBRO", fontTitulo, brushTexto, 14, 12);
            }

            if (_porcentajesPago.Length == 0)
            {
                using (Font fMensaje = new Font("Segoe UI", 9f, FontStyle.Italic))
                using (Brush bMensaje = new SolidBrush(Color.Gray))
                {
                    g.DrawString("Sin datos para el período seleccionado", fMensaje, bMensaje, 14, 45);
                }
                return;
            }

            float diametro = Math.Min(ancho * 0.48f, alto * 0.58f);
            float xDonut = 25f;
            float yDonut = (alto - diametro) / 2f + 10f;
            RectangleF rectExterior = new RectangleF(xDonut, yDonut, diametro, diametro);

            float anguloInicio = -90f;

            for (int i = 0; i < _porcentajesPago.Length; i++)
            {
                float sweep = (_porcentajesPago[i] / 100f) * 360f;
                using (Brush bPorcion = new SolidBrush(_coloresDonut[i % _coloresDonut.Length]))
                {
                    g.FillPie(bPorcion, rectExterior.X, rectExterior.Y, rectExterior.Width, rectExterior.Height, anguloInicio, sweep);
                }
                anguloInicio += sweep;
            }

            float radioHueco = diametro * 0.52f;
            float xHueco = xDonut + (diametro - radioHueco) / 2f;
            float yHueco = yDonut + (diametro - radioHueco) / 2f;
            using (Brush bFondo = new SolidBrush(Color.White))
            {
                g.FillEllipse(bFondo, xHueco, yHueco, radioHueco, radioHueco);
            }

            float xLeyenda = xDonut + diametro + 25f;
            float yLeyenda = yDonut + 10f;

            using (Font fLeyenda = new Font("Segoe UI", 8.5f))
            using (Brush bTexto = new SolidBrush(Color.FromArgb(50, 50, 50)))
            {
                for (int i = 0; i < _mediosPago.Length; i++)
                {
                    using (Brush bCaja = new SolidBrush(_coloresDonut[i % _coloresDonut.Length]))
                    {
                        g.FillRectangle(bCaja, xLeyenda, yLeyenda + (i * 30), 12, 12);
                    }
                    string texto = $"{_mediosPago[i]} ({_porcentajesPago[i]:F1}%)";
                    g.DrawString(texto, fLeyenda, bTexto, xLeyenda + 18, yLeyenda + (i * 30) - 2);
                }
            }
        }
        private void BExportarExcel_Click(object sender, EventArgs e)
        {
            if (DGVResumen.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel delimitado por comas (*.csv)|*.csv";
                sfd.FileName = $"Reporte_HierroYForja_{DateTime.Now:yyyyMMdd_HHmm}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Periodo;Cantidad Comprobantes;Total Ingresos;Total Costos;Margen Bruto;Rentabilidad");

                        foreach (DataGridViewRow row in DGVResumen.Rows)
                        {
                            if (row.IsNewRow) continue;
                            sb.AppendLine(string.Join(";",
                                row.Cells["ColPeriodo"].Value?.ToString() ?? "",
                                row.Cells["ColCantVentas"].Value?.ToString() ?? "",
                                row.Cells["ColTotalVentas"].Value?.ToString() ?? "",
                                row.Cells["ColTotalCompras"].Value?.ToString() ?? "",
                                row.Cells["ColGananciaNeta"].Value?.ToString() ?? "",
                                row.Cells["ColMargen"].Value?.ToString() ?? ""
                            ));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show("El reporte se exportó correctamente para Microsoft Excel.", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al exportar el archivo:\n{ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BExportarPDF_Click(object sender, EventArgs e)
        {
            if (DGVResumen.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en el período para generar el informe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = "Informe_Gerencial_Hierro_y_Forja";
                pd.DefaultPageSettings.Landscape = false;
                pd.PrintPage += ImprimirDocumento_PrintPage;

                PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
                vistaPrevia.Document = pd;
                vistaPrevia.Width = 900;
                vistaPrevia.Height = 700;
                vistaPrevia.StartPosition = FormStartPosition.CenterScreen;
                vistaPrevia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF/Impresión:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = 50;
            float y = 50;

            using (Font fEmpresa = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 9))
            using (Font fFila = new Font("Segoe UI", 9))
            using (Font fHeader = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Brush bOcre = new SolidBrush(Color.FromArgb(212, 131, 53)))
            using (Brush bGrafito = new SolidBrush(Color.FromArgb(38, 40, 44)))
            using (Brush bGris = new SolidBrush(Color.Gray))
            using (Pen penLinea = new Pen(Color.FromArgb(200, 205, 210), 1))
            {
                g.DrawString("HIERRO Y FORJA", fEmpresa, bOcre, x, y);
                g.DrawString($"INFORME GERENCIAL CONSOLIDADO - Período: {DTPFechaDesde.Value:dd/MM/yyyy} al {DTPFechaHasta.Value:dd/MM/yyyy}", fSub, bGrafito, x, y + 28);
                g.DrawString($"Emitido el: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Filtro: {CBTipoReporte.Text}", fSub, bGris, x, y + 46);

                y += 75;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 15;

                g.DrawString($"TOTAL FACTURADO: {LValorFacturado.Text}  |  MARGEN BRUTO: {LValorGanancia.Text}  |  OPERACIONES: {LValorTickets.Text}", fHeader, bGrafito, x, y);
                y += 28;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 20;

                g.DrawString("Período / Detalle", fHeader, bOcre, x, y);
                g.DrawString("Comprobantes", fHeader, bOcre, x + 180, y);
                g.DrawString("Ingresos ($)", fHeader, bOcre, x + 300, y);
                g.DrawString("Costos ($)", fHeader, bOcre, x + 440, y);
                g.DrawString("Margen Bruto", fHeader, bOcre, x + 570, y);

                y += 22;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 10;

                foreach (DataGridViewRow row in DGVResumen.Rows)
                {
                    if (row.IsNewRow) continue;
                    g.DrawString(row.Cells["ColPeriodo"].Value?.ToString() ?? "", fFila, bGrafito, x, y);
                    g.DrawString(row.Cells["ColCantVentas"].Value?.ToString() ?? "", fFila, bGrafito, x + 180, y);
                    g.DrawString(row.Cells["ColTotalVentas"].Value?.ToString() ?? "", fFila, bGrafito, x + 300, y);
                    g.DrawString(row.Cells["ColTotalCompras"].Value?.ToString() ?? "", fFila, bGrafito, x + 440, y);
                    g.DrawString(row.Cells["ColGananciaNeta"].Value?.ToString() ?? "", fFila, bGrafito, x + 570, y);

                    y += 24;
                }

                y += 30;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 10;

                g.DrawString("Documento oficial generado por el Sistema de Gestión Hierro y Forja.", fSub, bGris, x, y);
            }
        }
        private async void BFiltrar_Click(object sender, EventArgs e)
        {
            if (_ctsCarga == null || _ctsCarga.IsCancellationRequested)
                _ctsCarga = new CancellationTokenSource();

            var token = _ctsCarga.Token;

            try
            {
                await CargarTodosLosDatosAsync(token);
                if (token.IsCancellationRequested) return;

                PPanelGraficoBarras.Invalidate();
                PPanelGraficoTorta.Invalidate();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al filtrar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}