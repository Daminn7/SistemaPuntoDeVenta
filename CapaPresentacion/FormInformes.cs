using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormInformes : Form
    {
        private DataTable _dtResumen = new DataTable();

        // Datos simulados para los gráficos
        private readonly string[] _meses = { "Mayo", "Junio", "Julio", "Agosto", "Septiembre" };
        private readonly float[] _ventasMes = { 320000f, 450000f, 510000f, 680000f, 850000f };
        private readonly float[] _comprasMes = { 210000f, 310000f, 340000f, 420000f, 510000f };

        // Datos del gráfico Donut (Métodos de Pago)
        private readonly string[] _mediosPago = { "Efectivo", "Transferencia", "Cuenta Cte." };
        private readonly float[] _porcentajesPago = { 55f, 30f, 15f };
        private readonly Color[] _coloresDonut = {
            Color.FromArgb(212, 131, 53),  // Ocre
            Color.FromArgb(41, 128, 185),  // Azul
            Color.FromArgb(39, 174, 96)   // Verde
        };

        public FormInformes()
        {
            InitializeComponent();
            InicializarComponentesAdicionales();
        }

        private void FormInformes_Load(object sender, EventArgs e)
        {
            AsignarIconoTitulo();
            CargarTiposReporte();
            CargarDatosResumen();
            CalcularTotalesResumen();

            DGVResumen.ClearSelection();
            DGVResumen.CurrentCell = null;
        }

        private void InicializarComponentesAdicionales()
        {
            // Redibujar gráficos si la ventana cambia de tamaño
            PPanelGraficoBarras.Resize += (s, e) => PPanelGraficoBarras.Invalidate();
            PPanelGraficoTorta.Resize += (s, e) => PPanelGraficoTorta.Invalidate();
        }

        // =========================================================================
        // 1. ÍCONO VECTORIAL DE INFORMES (GRÁFICO DE BARRAS CONCRETO)
        // =========================================================================
        private Image GenerarIconoInformes(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    // Ejes coordenados X e Y
                    g.DrawLine(pen, 4f, 26f, 28f, 26f);
                    g.DrawLine(pen, 4f, 26f, 4f, 5f);

                    // 3 Barras ascendentes
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

        private void CargarDatosResumen()
        {
            if (_dtResumen.Columns.Count == 0)
            {
                _dtResumen.Columns.Add("ColPeriodo", typeof(string));
                _dtResumen.Columns.Add("ColCantVentas", typeof(int));
                _dtResumen.Columns.Add("ColTotalVentas", typeof(string));
                _dtResumen.Columns.Add("ColTotalCompras", typeof(string));
                _dtResumen.Columns.Add("ColGananciaNeta", typeof(string));
                _dtResumen.Columns.Add("ColMargen", typeof(string));

                _dtResumen.Rows.Add("Semana 1 - Sep 2026", 42, "$ 850.000,00", "$ 510.000,00", "$ 340.000,00", "40.0 %");
                _dtResumen.Rows.Add("Semana 4 - Ago 2026", 38, "$ 680.000,00", "$ 420.000,00", "$ 260.000,00", "38.2 %");
                _dtResumen.Rows.Add("Semana 3 - Ago 2026", 31, "$ 510.000,00", "$ 340.000,00", "$ 170.000,00", "33.3 %");
                _dtResumen.Rows.Add("Semana 2 - Ago 2026", 29, "$ 450.000,00", "$ 310.000,00", "$ 140.000,00", "31.1 %");
                _dtResumen.Rows.Add("Semana 1 - Ago 2026", 24, "$ 320.000,00", "$ 210.000,00", "$ 110.000,00", "34.3 %");
            }

            DGVResumen.AutoGenerateColumns = false;
            ColPeriodo.DataPropertyName = "ColPeriodo";
            ColCantVentas.DataPropertyName = "ColCantVentas";
            ColTotalVentas.DataPropertyName = "ColTotalVentas";
            ColTotalCompras.DataPropertyName = "ColTotalCompras";
            ColGananciaNeta.DataPropertyName = "ColGananciaNeta";
            ColMargen.DataPropertyName = "ColMargen";

            DGVResumen.DataSource = _dtResumen;
        }

        private void CalcularTotalesResumen()
        {
            LValorFacturado.Text = "$ 2.810.000,00";
            LValorGanancia.Text = "$ 1.020.000,00";
            LValorTickets.Text = "164 facturas";
        }

        // =========================================================================
        // 2. RENDERIZADO DE GRÁFICO DE BARRAS VECTORIAL (VENTAS VS COMPRAS)
        // =========================================================================
        private void PPanelGraficoBarras_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
    g.SmoothingMode = SmoothingMode.AntiAlias;

    int ancho = PPanelGraficoBarras.Width;
    int alto = PPanelGraficoBarras.Height;

    // Título superior
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

    if (plotAncho <= 0 || plotAlto <= 0) return;

    // Línea base X
    using (Pen penEje = new Pen(Color.FromArgb(215, 220, 225), 1.5f))
    {
        g.DrawLine(penEje, margenIzq, margenSup + plotAlto, margenIzq + plotAncho, margenSup + plotAlto);
    }

    // Escala
    float valorMax = 1000000f; // 1 millón
    int cantGrupos = _meses.Length;

    // AGRUPAMIENTO COMPACTO: Limitamos el ancho de cada grupo para que no se separen de más
    float anchoGrupoIdeal = Math.Min(plotAncho / cantGrupos, 85f);
    float anchoTotalConjunto = anchoGrupoIdeal * cantGrupos;
    float inicioXCentrado = margenIzq + ((plotAncho - anchoTotalConjunto) / 2f);

    float anchoBarra = 24f; // Ancho sólido y visible para cada barra

    using (Brush bVenta = new SolidBrush(Color.FromArgb(212, 131, 53))) // Ocre institucional
    using (Brush bCompra = new SolidBrush(Color.FromArgb(90, 95, 100)))  // Grafito
    using (Font fLabels = new Font("Segoe UI", 8.5f))
    using (Brush bTexto = new SolidBrush(Color.FromArgb(70, 70, 70)))
    {
        for (int i = 0; i < cantGrupos; i++)
        {
            float centroX = inicioXCentrado + (i * anchoGrupoIdeal) + (anchoGrupoIdeal / 2f);

            // Alturas relativas
            float hVenta = (_ventasMes[i] / valorMax) * plotAlto;
            float hCompra = (_comprasMes[i] / valorMax) * plotAlto;

            // Barra Ventas
            float xVenta = centroX - anchoBarra - 2f;
            float yVenta = margenSup + (plotAlto - hVenta);
            g.FillRectangle(bVenta, xVenta, yVenta, anchoBarra, hVenta);

            // Barra Compras
            float xCompra = centroX + 2f;
            float yCompra = margenSup + (plotAlto - hCompra);
            g.FillRectangle(bCompra, xCompra, yCompra, anchoBarra, hCompra);

            // Etiqueta del Mes
            SizeF sizeMes = g.MeasureString(_meses[i], fLabels);
            g.DrawString(_meses[i], fLabels, bTexto, centroX - (sizeMes.Width / 2f), margenSup + plotAlto + 8f);
        }

        // Leyendas en la esquina superior derecha
        g.FillRectangle(bVenta, ancho - 165, 14, 10, 10);
        g.DrawString("Ventas", fLabels, bTexto, ancho - 150, 12);

        g.FillRectangle(bCompra, ancho - 90, 14, 10, 10);
        g.DrawString("Compras", fLabels, bTexto, ancho - 75, 12);
    
            }
        }

        // =========================================================================
        // 3. RENDERIZADO DE GRÁFICO DE DONUT / TORTA (MEDIOS DE COBRO)
        // =========================================================================
        private void PPanelGraficoTorta_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ancho = PPanelGraficoTorta.Width;
            int alto = PPanelGraficoTorta.Height;

            // Título
            using (Font fontTitulo = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Brush brushTexto = new SolidBrush(Color.FromArgb(40, 40, 40)))
            {
                g.DrawString("DISTRIBUCIÓN POR MEDIO DE COBRO", fontTitulo, brushTexto, 14, 12);
            }

            // Dimensiones del donut
            float diametro = Math.Min(ancho * 0.48f, alto * 0.58f);
            float xDonut = 25f;
            float yDonut = (alto - diametro) / 2f + 10f;
            RectangleF rectExterior = new RectangleF(xDonut, yDonut, diametro, diametro);

            float anguloInicio = -90f;

            for (int i = 0; i < _porcentajesPago.Length; i++)
            {
                float sweep = (_porcentajesPago[i] / 100f) * 360f;
                using (Brush bPorcion = new SolidBrush(_coloresDonut[i]))
                {
                    g.FillPie(bPorcion, rectExterior.X, rectExterior.Y, rectExterior.Width, rectExterior.Height, anguloInicio, sweep);
                }
                anguloInicio += sweep;
            }

            // Círculo central para dar el efecto Donut moderno
            float radioHueco = diametro * 0.52f;
            float xHueco = xDonut + (diametro - radioHueco) / 2f;
            float yHueco = yDonut + (diametro - radioHueco) / 2f;
            using (Brush bFondo = new SolidBrush(Color.White))
            {
                g.FillEllipse(bFondo, xHueco, yHueco, radioHueco, radioHueco);
            }

            // Leyendas a la derecha
            float xLeyenda = xDonut + diametro + 25f;
            float yLeyenda = yDonut + 10f;

            using (Font fLeyenda = new Font("Segoe UI", 8.5f))
            using (Brush bTexto = new SolidBrush(Color.FromArgb(50, 50, 50)))
            {
                for (int i = 0; i < _mediosPago.Length; i++)
                {
                    using (Brush bCaja = new SolidBrush(_coloresDonut[i]))
                    {
                        g.FillRectangle(bCaja, xLeyenda, yLeyenda + (i * 30), 12, 12);
                    }
                    string texto = $"{_mediosPago[i]} ({_porcentajesPago[i]}%)";
                    g.DrawString(texto, fLeyenda, bTexto, xLeyenda + 18, yLeyenda + (i * 30) - 2);
                }
            }
        }

        // =========================================================================
        // 4. EXPORTACIÓN A EXCEL (.CSV FORMATO DIRECTO)
        // =========================================================================
        private void BExportarExcel_Click(object sender, EventArgs e)
        {
            if (_dtResumen.Rows.Count == 0)
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

                        // Encabezados
                        sb.AppendLine("Periodo;Cantidad Comprobantes;Total Ingresos;Total Costos;Margen Bruto;Rentabilidad");

                        // Filas
                        foreach (DataRow fila in _dtResumen.Rows)
                        {
                            sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5}",
                                fila["ColPeriodo"],
                                fila["ColCantVentas"],
                                fila["ColTotalVentas"].ToString().Replace(";", ""),
                                fila["ColTotalCompras"].ToString().Replace(";", ""),
                                fila["ColGananciaNeta"].ToString().Replace(";", ""),
                                fila["ColMargen"]
                            ));
                        }

                        // Codificación UTF-8 con BOM para que Excel abra sin problemas de tildes ni caracteres
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

        // =========================================================================
        // 5. EXPORTACIÓN A PDF / IMPRESIÓN OFICIAL
        // =========================================================================
        private void BExportarPDF_Click(object sender, EventArgs e)
        {
            if (_dtResumen.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en el período para generar el informe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = "Informe_Gerencial_Hierro_y_Forja";
                pd.DefaultPageSettings.Landscape = false; // Orientación vertical estándar A4
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

            // Encabezado institucional
            using (Font fEmpresa = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 9))
            using (Font fFila = new Font("Segoe UI", 9))
            using (Font fHeader = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Brush bOcre = new SolidBrush(Color.FromArgb(212, 131, 53)))
            using (Brush bGrafito = new SolidBrush(Color.FromArgb(38, 40, 44)))
            using (Brush bGris = new SolidBrush(Color.Gray)) // <-- Pincel para textos secundarios
            using (Pen penLinea = new Pen(Color.FromArgb(200, 205, 210), 1))
            {
                // Título
                g.DrawString("HIERRO Y FORJA", fEmpresa, bOcre, x, y);
                g.DrawString($"INFORME GERENCIAL CONSOLIDADO - Período: {DTPFechaDesde.Value:dd/MM/yyyy} al {DTPFechaHasta.Value:dd/MM/yyyy}", fSub, bGrafito, x, y + 28);

                // CORREGIDO: Usando 'bGris' en lugar de 'Color.Gray'
                g.DrawString($"Emitido el: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Filtro: {CBTipoReporte.Text}", fSub, bGris, x, y + 46);

                y += 75;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 15;

                // Tarjeta de Totales Impresa
                g.DrawString($"TOTAL FACTURADO: {LValorFacturado.Text}  |  MARGEN BRUTO: {LValorGanancia.Text}  |  OPERACIONES: {LValorTickets.Text}", fHeader, bGrafito, x, y);
                y += 28;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 20;

                // Cabeceras de tabla
                g.DrawString("Período / Detalle", fHeader, bOcre, x, y);
                g.DrawString("Comprobantes", fHeader, bOcre, x + 180, y);
                g.DrawString("Ingresos ($)", fHeader, bOcre, x + 300, y);
                g.DrawString("Costos ($)", fHeader, bOcre, x + 440, y);
                g.DrawString("Margen Bruto", fHeader, bOcre, x + 570, y);

                y += 22;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 10;

                // Filas
                foreach (DataRow row in _dtResumen.Rows)
                {
                    g.DrawString(row["ColPeriodo"].ToString(), fFila, bGrafito, x, y);
                    g.DrawString(row["ColCantVentas"].ToString(), fFila, bGrafito, x + 180, y);
                    g.DrawString(row["ColTotalVentas"].ToString(), fFila, bGrafito, x + 300, y);
                    g.DrawString(row["ColTotalCompras"].ToString(), fFila, bGrafito, x + 440, y);
                    g.DrawString(row["ColGananciaNeta"].ToString(), fFila, bGrafito, x + 570, y);

                    y += 24;
                }

                y += 30;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 10;

                // CORREGIDO: Usando 'bGris'
                g.DrawString("Documento oficial generado por el Sistema de Gestión Hierro y Forja.", fSub, bGris, x, y);
            }
        }

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            // Forzar actualización y redibujado de gráficos
            PPanelGraficoBarras.Invalidate();
            PPanelGraficoTorta.Invalidate();
            MessageBox.Show("Métricas e informes actualizados para el rango seleccionado.", "Informes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
