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
using static CapaPresentacion.FormPrincipal;

namespace CapaPresentacion
{
    public partial class FormMisVentas : Form
    {
        private DataTable _dtMisVentas = new DataTable();
        private int _idVentaSeleccionada = 0;

        public FormMisVentas()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private void FormMisVentas_Load(object sender, EventArgs e)
        {
            AsignarIconoTitulo();
            CargarDesplegableEstados();
            CargarHistorialPersonalSimulado();
            RecalcularMetricasPersonales();

            DGVVentas.ClearSelection();
            DGVVentas.CurrentCell = null;
        }
        //Ícono del encabezado
        private Image DibujarIconoMisVentas(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 5f, 4f, 22f, 24f);
                    g.DrawLine(pen, 9f, 9f, 18f, 9f);
                    g.DrawLine(pen, 9f, 14f, 23f, 14f);

                    PointF[] check = new PointF[]
                    {
                        new PointF(9f, 21f),
                        new PointF(13f, 24f),
                        new PointF(21f, 18f)
                    };
                    g.DrawLines(pen, check);
                }
            }
            return bmp;
        }

        private void AsignarIconoTitulo()
        {
            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = DibujarIconoMisVentas(Color.FromArgb(212, 131, 53));
        }
        //Configuración y filtrado
        private void InicializarComportamiento()
        {
            DTPFechaDesde.Value = DateTime.Now.AddDays(-15);
            DTPFechaHasta.Value = DateTime.Now;

            TBBuscar.TextChanged += (s, e) => AplicarFiltros();
            CBFiltroEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            DTPFechaDesde.ValueChanged += (s, e) => AplicarFiltros();
            DTPFechaHasta.ValueChanged += (s, e) => AplicarFiltros();

            BLimpiarFiltros.Click += (s, e) =>
            {
                TBBuscar.Clear();
                CBFiltroEstado.SelectedIndex = 0;
                DTPFechaDesde.Value = DateTime.Now.AddDays(-15);
                DTPFechaHasta.Value = DateTime.Now;
                AplicarFiltros();
            };

            // Pintar celdas de Estado con color representativo
            DGVVentas.CellFormatting += (s, e) =>
            {
                if (DGVVentas.Columns[e.ColumnIndex].Name == "ColEstado" && e.Value != null)
                {
                    string estado = e.Value.ToString();
                    if (estado == "Cobrado")
                        e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                    else if (estado == "Pendiente")
                        e.CellStyle.ForeColor = Color.FromArgb(212, 131, 53);
                    else if (estado == "Anulado")
                        e.CellStyle.ForeColor = Color.FromArgb(192, 57, 43);

                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            };

            DGVVentas.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    _idVentaSeleccionada = Convert.ToInt32(DGVVentas.Rows[e.RowIndex].Cells["ColIdVenta"].Value ?? 0);
                }
            };
        }
        private void CargarDesplegableEstados()
        {
            CBFiltroEstado.Items.Clear();
            CBFiltroEstado.Items.AddRange(new object[] { "Todos", "Cobrado", "Pendiente", "Anulado" });
            CBFiltroEstado.SelectedIndex = 0;
        }
        private void CargarHistorialPersonalSimulado()
        {
            if (_dtMisVentas.Columns.Count == 0)
            {
                _dtMisVentas.Columns.Add("ColIdVenta", typeof(int));
                _dtMisVentas.Columns.Add("ColFecha", typeof(string));
                _dtMisVentas.Columns.Add("ColComprobante", typeof(string));
                _dtMisVentas.Columns.Add("ColCliente", typeof(string));
                _dtMisVentas.Columns.Add("ColCantItems", typeof(int));
                _dtMisVentas.Columns.Add("ColTotal", typeof(decimal));
                _dtMisVentas.Columns.Add("ColEstado", typeof(string));

                _dtMisVentas.Rows.Add(1, "05/09/2026 18:42", "FAC-B 0001-0000142", "Herrería San José", 6, 45200m, "Cobrado");
                _dtMisVentas.Rows.Add(2, "05/09/2026 17:15", "REC-X 0001-0000089", "Consumidor Final", 2, 12800m, "Cobrado");
                _dtMisVentas.Rows.Add(3, "05/09/2026 15:30", "FAC-A 0001-0000210", "Metalúrgica Del Nordeste", 14, 78000m, "Cobrado");
                _dtMisVentas.Rows.Add(4, "05/09/2026 11:05", "PV-260905-410", "Carlos Romero", 3, 12500m, "Pendiente");
                _dtMisVentas.Rows.Add(5, "04/09/2026 16:20", "FAC-B 0001-0000140", "Herrería El Yunque", 5, 34000m, "Cobrado");
                _dtMisVentas.Rows.Add(6, "03/09/2026 10:12", "REC-X 0001-0000085", "Consumidor Final", 1, 4500m, "Anulado");
            }

            DGVVentas.AutoGenerateColumns = false;
            ColIdVenta.DataPropertyName = "ColIdVenta";
            ColFecha.DataPropertyName = "ColFecha";
            ColComprobante.DataPropertyName = "ColComprobante";
            ColCliente.DataPropertyName = "ColCliente";
            ColCantItems.DataPropertyName = "ColCantItems";
            ColTotal.DataPropertyName = "ColTotal";
            ColEstado.DataPropertyName = "ColEstado";

            ColTotal.DefaultCellStyle.Format = "C2";

            DGVVentas.DataSource = _dtMisVentas;
        }
        private void AplicarFiltros()
        {
            if (_dtMisVentas == null || _dtMisVentas.DefaultView == null) return;

            string texto = TBBuscar.Text.Trim().Replace("'", "''");
            string filtro = "";

            if (!string.IsNullOrEmpty(texto))
            {
                filtro += $"(ColComprobante LIKE '%{texto}%' OR ColCliente LIKE '%{texto}%')";
            }

            if (CBFiltroEstado.SelectedIndex > 0)
            {
                string estado = CBFiltroEstado.Text;
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"ColEstado = '{estado}'";
            }

            _dtMisVentas.DefaultView.RowFilter = filtro;
            RecalcularMetricasPersonales();
        }
        //Recálculo de métricas
        private void RecalcularMetricasPersonales()
        {
            decimal totalFacturado = 0m;
            int operacionesCobradas = 0;

            DataView dv = _dtMisVentas.DefaultView;
            foreach (DataRowView drv in dv)
            {
                string estado = drv["ColEstado"].ToString();
                decimal total = Convert.ToDecimal(drv["ColTotal"]);

                if (estado == "Cobrado")
                {
                    totalFacturado += total;
                    operacionesCobradas++;
                }
            }

            decimal comision = totalFacturado * 0.025m; // 2.5% de comisión

            LValorTotalVentas.Text = totalFacturado.ToString("C2");
            LValorOperaciones.Text = $"{operacionesCobradas} operaciones";
            LValorComision.Text = comision.ToString("C2");
        }
        // Acciones de botones
        private void BReimprimirTicket_Click(object sender, EventArgs e)
        {
            if (DGVVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un comprobante de la grilla para reimprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = $"Reimpresion_{DGVVentas.CurrentRow.Cells["ColComprobante"].Value}";
                pd.PrintPage += ImprimirTicket_PrintPage;

                PrintPreviewDialog prev = new PrintPreviewDialog
                {
                    Document = pd,
                    Width = 800,
                    Height = 600,
                    StartPosition = FormStartPosition.CenterScreen
                };
                prev.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reimprimir comprobante:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ImprimirTicket_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = 50;
            float y = 50;

            DataGridViewRow fila = DGVVentas.CurrentRow;

            using (Font fTitulo = new Font("Segoe UI", 15, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 9.5f))
            using (Font fBold = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Brush bOcre = new SolidBrush(Color.FromArgb(212, 131, 53)))
            using (Brush bGrafito = new SolidBrush(Color.FromArgb(38, 40, 44)))
            using (Brush bGris = new SolidBrush(Color.Gray))
            using (Pen penLinea = new Pen(Color.FromArgb(210, 215, 220), 1))
            {
                g.DrawString("HIERRO Y FORJA", fTitulo, bOcre, x, y);
                g.DrawString("DUPLICADO DE COMPROBANTE DE VENTA", fSub, bGrafito, x, y + 26);
                g.DrawString($"Emisión original: {fila.Cells["ColFecha"].Value}  |  Vendedor: {SesionUsuario.Nombre}", fSub, bGris, x, y + 46);

                y += 75;
                g.DrawLine(penLinea, x, y, 700, y);
                y += 15;

                g.DrawString($"Comprobante: {fila.Cells["ColComprobante"].Value}", fBold, bGrafito, x, y);
                g.DrawString($"Cliente: {fila.Cells["ColCliente"].Value}", fBold, bGrafito, x + 300, y);
                y += 25;
                g.DrawString($"Estado actual: {fila.Cells["ColEstado"].Value}", fSub, bGrafito, x, y);
                g.DrawString($"Artículos: {fila.Cells["ColCantItems"].Value} unidades", fSub, bGrafito, x + 300, y);

                y += 40;
                g.DrawLine(penLinea, x, y, 700, y);
                y += 15;

                g.DrawString($"IMPORTE TOTAL: {Convert.ToDecimal(fila.Cells["ColTotal"].Value):C2}", fTitulo, bOcre, x + 300, y);
            }
        }   
        private void BExportarExcel_Click(object sender, EventArgs e)
        {
            if (_dtMisVentas.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros en la grilla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Declaración explícita con nombre completo para evitar cualquier ambigüedad
            using (System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog())
            {
                sfd.Filter = "Libro de Excel (*.xls)|*.xls";
                sfd.FileName = $"MisVentas_{DateTime.Now:yyyyMMdd_HHmm}.xls";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        System.Text.StringBuilder xml = new System.Text.StringBuilder();

                        // 1. Declaración XML y encabezado compatible con Excel
                        xml.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        xml.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
                        xml.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                        xml.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
                        xml.AppendLine(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
                        xml.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                        xml.AppendLine(" xmlns:html=\"http://www.w3.org/TR/REC-html40\">");

                        // 2. Estilos visuales institucionales
                        xml.AppendLine(" <Styles>");
                        xml.AppendLine("  <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
                        xml.AppendLine("   <Alignment ss:Vertical=\"Center\"/>");
                        xml.AppendLine("   <Font ss:FontName=\"Segoe UI\" ss:Size=\"10\" ss:Color=\"#333333\"/>");
                        xml.AppendLine("  </Style>");

                        xml.AppendLine("  <Style ss:ID=\"sTitulo\">");
                        xml.AppendLine("   <Font ss:FontName=\"Segoe UI\" ss:Size=\"14\" ss:Bold=\"1\" ss:Color=\"#D48335\"/>");
                        xml.AppendLine("  </Style>");

                        xml.AppendLine("  <Style ss:ID=\"sSubtitulo\">");
                        xml.AppendLine("   <Font ss:FontName=\"Segoe UI\" ss:Size=\"9\" ss:Italic=\"1\" ss:Color=\"#666666\"/>");
                        xml.AppendLine("  </Style>");

                        xml.AppendLine("  <Style ss:ID=\"sHeader\">");
                        xml.AppendLine("   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>");
                        xml.AppendLine("   <Borders>");
                        xml.AppendLine("    <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#26282C\"/>");
                        xml.AppendLine("   </Borders>");
                        xml.AppendLine("   <Font ss:FontName=\"Segoe UI\" ss:Size=\"10\" ss:Bold=\"1\" ss:Color=\"#FFFFFF\"/>");
                        xml.AppendLine("   <Interior ss:Color=\"#26282C\" ss:Pattern=\"Solid\"/>");
                        xml.AppendLine("  </Style>");

                        xml.AppendLine("  <Style ss:ID=\"sTextoCentrado\">");
                        xml.AppendLine("   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>");
                        xml.AppendLine("  </Style>");

                        xml.AppendLine("  <Style ss:ID=\"sMoneda\">");
                        xml.AppendLine("   <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Center\"/>");
                        xml.AppendLine("   <NumberFormat ss:Format=\"$#,##0.00\"/>");
                        xml.AppendLine("  </Style>");

                        xml.AppendLine("  <Style ss:ID=\"sNumero\">");
                        xml.AppendLine("   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/>");
                        xml.AppendLine("   <NumberFormat ss:Format=\"0\"/>");
                        xml.AppendLine("  </Style>");
                        xml.AppendLine(" </Styles>");

                        // 3. Hoja de Trabajo y Dimensiones de Columnas
                        xml.AppendLine(" <Worksheet ss:Name=\"Mis Ventas\">");
                        xml.AppendLine("  <Table ss:DefaultRowHeight=\"20\">");
                        xml.AppendLine("   <Column ss:Width=\"50\"/>");
                        xml.AppendLine("   <Column ss:Width=\"120\"/>");
                        xml.AppendLine("   <Column ss:Width=\"140\"/>");
                        xml.AppendLine("   <Column ss:Width=\"220\"/>");
                        xml.AppendLine("   <Column ss:Width=\"70\"/>");
                        xml.AppendLine("   <Column ss:Width=\"110\"/>");
                        xml.AppendLine("   <Column ss:Width=\"90\"/>");

                        // 4. Filas de Título Institucional
                        xml.AppendLine("   <Row ss:Height=\"26\">");
                        xml.AppendLine("    <Cell ss:StyleID=\"sTitulo\"><Data ss:Type=\"String\">HIERRO Y FORJA - HISTORIAL DE VENTAS</Data></Cell>");
                        xml.AppendLine("   </Row>");
                        xml.AppendLine("   <Row ss:Height=\"18\">");
                        xml.AppendLine($"    <Cell ss:StyleID=\"sSubtitulo\"><Data ss:Type=\"String\">Vendedor: {SesionUsuario.Nombre} | Exportado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</Data></Cell>");
                        xml.AppendLine("   </Row>");
                        xml.AppendLine("   <Row ss:Height=\"10\"/>");

                        // 5. Fila de Encabezados
                        xml.AppendLine("   <Row ss:Height=\"24\">");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">ID</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Fecha / Hora</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">N° Comprobante</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Cliente</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Ítems</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Total</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Estado</Data></Cell>");
                        xml.AppendLine("   </Row>");

                        // 6. Filas de Datos
                        System.Data.DataView dv = _dtMisVentas.DefaultView;
                        foreach (System.Data.DataRowView drv in dv)
                        {
                            int id = Convert.ToInt32(drv["ColIdVenta"]);
                            string fecha = drv["ColFecha"].ToString();
                            string comprobante = drv["ColComprobante"].ToString();
                            string cliente = System.Security.SecurityElement.Escape(drv["ColCliente"].ToString());
                            int cantItems = Convert.ToInt32(drv["ColCantItems"]);
                            decimal total = Convert.ToDecimal(drv["ColTotal"]);
                            string estado = drv["ColEstado"].ToString();

                            xml.AppendLine("   <Row>");
                            xml.AppendLine($"    <Cell ss:StyleID=\"sNumero\"><Data ss:Type=\"Number\">{id}</Data></Cell>");
                            xml.AppendLine($"    <Cell ss:StyleID=\"sTextoCentrado\"><Data ss:Type=\"String\">{fecha}</Data></Cell>");
                            xml.AppendLine($"    <Cell><Data ss:Type=\"String\">{comprobante}</Data></Cell>");
                            xml.AppendLine($"    <Cell><Data ss:Type=\"String\">{cliente}</Data></Cell>");
                            xml.AppendLine($"    <Cell ss:StyleID=\"sNumero\"><Data ss:Type=\"Number\">{cantItems}</Data></Cell>");
                            xml.AppendLine($"    <Cell ss:StyleID=\"sMoneda\"><Data ss:Type=\"Number\">{total.ToString(System.Globalization.CultureInfo.InvariantCulture)}</Data></Cell>");
                            xml.AppendLine($"    <Cell ss:StyleID=\"sTextoCentrado\"><Data ss:Type=\"String\">{estado}</Data></Cell>");
                            xml.AppendLine("   </Row>");
                        }

                        xml.AppendLine("  </Table>");
                        xml.AppendLine(" </Worksheet>");
                        xml.AppendLine("</Workbook>");

                        // 7. Guardado dentro del ámbito seguro de 'sfd'
                        System.IO.File.WriteAllText(sfd.FileName, xml.ToString(), System.Text.Encoding.UTF8);

                        MessageBox.Show("El historial de ventas se exportó exitosamente como planilla de Excel.", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al generar la planilla de Excel:\n{ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
