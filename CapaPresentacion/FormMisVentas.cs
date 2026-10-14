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
using CapaLogica;
using CapaDatos.DTOs;

namespace CapaPresentacion
{
    public partial class FormMisVentas : Form
    {
        // ✅ API: Órdenes de venta
        private readonly OrdenVentaLogica _ordenVentaLogica = new OrdenVentaLogica();
        private List<OrdenVentaDto> _ordenesOriginales = new List<OrdenVentaDto>();
        private int _idOrdenSeleccionada = 0;
        private OrdenVentaDto _ordenDetalleActual = null;

        public FormMisVentas()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        // ✅ MODIFICADO: Ahora es async para cargar de la API
        private async void FormMisVentas_Load(object sender, EventArgs e)
        {
            AsignarIconoTitulo();
            CargarDesplegableEstados();
            await CargarOrdenesAsync();

            DGVVentas.ClearSelection();
            DGVVentas.CurrentCell = null;
            DGVDetalle.Rows.Clear();
        }

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

        private void InicializarComportamiento()
        {
            DTPFechaDesde.Value = DateTime.Now.AddDays(-30);
            DTPFechaHasta.Value = DateTime.Now;

            TBBuscar.TextChanged += (s, e) => AplicarFiltros();
            CBFiltroEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            DTPFechaDesde.ValueChanged += (s, e) => AplicarFiltros();
            DTPFechaHasta.ValueChanged += (s, e) => AplicarFiltros();

            BLimpiarFiltros.Click += (s, e) =>
            {
                TBBuscar.Clear();
                CBFiltroEstado.SelectedIndex = 0;
                DTPFechaDesde.Value = DateTime.Now.AddDays(-30);
                DTPFechaHasta.Value = DateTime.Now;
                AplicarFiltros();
            };

            // ✅ Coloración de estados
            DGVVentas.CellFormatting += (s, e) =>
            {
                if (DGVVentas.Columns[e.ColumnIndex].Name == "ColEstado" && e.Value != null)
                {
                    string estado = e.Value.ToString();

                    switch (estado)
                    {
                        case "Pendiente":
                            e.CellStyle.ForeColor = Color.FromArgb(212, 131, 53);   // Ocre
                            break;
                        case "Confirmada":
                            e.CellStyle.ForeColor = Color.FromArgb(41, 128, 185);   // Azul
                            break;
                        case "Finalizada":
                            e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);    // Verde
                            break;
                        case "Cancelada":
                            e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34);   // Naranja
                            break;
                        case "Anulada":
                            e.CellStyle.ForeColor = Color.FromArgb(192, 57, 43);    // Rojo
                            break;
                        default:
                            e.CellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                            break;
                    }

                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            };

            // ✅ Al hacer clic en una fila, cargar el detalle desde la API
            DGVVentas.CellClick += async (s, e) =>
            {
                if (e.RowIndex < 0) return;
                await CargarDetalleOrdenAsync(e.RowIndex);
            };
        }

        // ============================================================
        // ✅ Carga las órdenes del vendedor logueado desde la API
        // ============================================================
        private async Task CargarOrdenesAsync()
        {
            try
            {
                var todas = await _ordenVentaLogica.ObtenerTodas();

                _ordenesOriginales = todas?
                    .Where(o => o.PersonalId == SesionUsuario.IdPersonal)
                    .OrderByDescending(o => o.FechaCreacion)
                    .ToList() ?? new List<OrdenVentaDto>();

                MostrarOrdenes(_ordenesOriginales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar órdenes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ✅ Muestra las órdenes en la grilla
        // ============================================================
        private void MostrarOrdenes(List<OrdenVentaDto> ordenes)
        {
            DGVVentas.Rows.Clear();

            foreach (var orden in ordenes)
            {
                int cantItems = orden.Detalles?.Sum(d => d.Cantidad) ?? 0;

                DGVVentas.Rows.Add(
                    orden.IdOrden,
                    orden.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                    orden.NumeroPresupuesto ?? $"#{orden.IdOrden}",
                    orden.ClienteNombre ?? "Consumidor Final",
                    cantItems,
                    orden.Total,
                    orden.EstadoVentaDescripcion ?? ""
                );
            }

            RecalcularMetricasPersonales();
        }

        // ============================================================
        // ✅ Carga el detalle de la orden seleccionada desde la API
        // ============================================================
        private async Task CargarDetalleOrdenAsync(int rowIndex)
        {
            try
            {
                var idValue = DGVVentas.Rows[rowIndex].Cells["ColIdVenta"].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int idOrden = Convert.ToInt32(idValue);
                _idOrdenSeleccionada = idOrden;

                // Buscar la orden completa con detalles
                var orden = await _ordenVentaLogica.ObtenerPorId(idOrden);
                _ordenDetalleActual = orden;

                DGVDetalle.Rows.Clear();
                if (orden?.Detalles != null)
                {
                    foreach (var d in orden.Detalles)
                    {
                        DGVDetalle.Rows.Add(
                            d.ProductoCodigo ?? "",
                            d.ProductoNombre ?? "",
                            d.Cantidad,
                            d.PrecioUnitario,
                            d.Subtotal
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalle: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ✅ Carga el desplegable con TODOS los estados reales
        // ============================================================
        private void CargarDesplegableEstados()
        {
            CBFiltroEstado.Items.Clear();
            CBFiltroEstado.Items.AddRange(new object[]
            {
                "Todos",
                "Pendiente",
                "Confirmada",
                "Finalizada",
                "Cancelada",
                "Anulada"
            });
            CBFiltroEstado.SelectedIndex = 0;
        }

        // ============================================================
        // ✅ Aplica los filtros sobre la grilla
        // ============================================================
        private void AplicarFiltros()
        {
            string texto = TBBuscar.Text.Trim().ToLower();
            string estadoFiltro = CBFiltroEstado.SelectedIndex > 0 ? CBFiltroEstado.Text : "";
            DateTime fechaDesde = DTPFechaDesde.Value.Date;
            DateTime fechaHasta = DTPFechaHasta.Value.Date.AddDays(1);

            foreach (DataGridViewRow row in DGVVentas.Rows)
            {
                if (row.IsNewRow) continue;

                string comprobante = row.Cells["ColComprobante"].Value?.ToString().ToLower() ?? "";
                string cliente = row.Cells["ColCliente"].Value?.ToString().ToLower() ?? "";
                string estado = row.Cells["ColEstado"].Value?.ToString() ?? "";
                string fechaStr = row.Cells["ColFecha"].Value?.ToString() ?? "";

                DateTime.TryParse(fechaStr, out DateTime fecha);
                bool coincideFecha = fecha >= fechaDesde && fecha < fechaHasta;

                bool coincideTexto = string.IsNullOrEmpty(texto) ||
                                     comprobante.Contains(texto) ||
                                     cliente.Contains(texto);

                bool coincideEstado = string.IsNullOrEmpty(estadoFiltro) ||
                                      estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase);

                row.Visible = coincideTexto && coincideEstado && coincideFecha;
            }

            RecalcularMetricasPersonales();

            // Limpiar el detalle al aplicar nuevos filtros
            DGVDetalle.Rows.Clear();
            _idOrdenSeleccionada = 0;
            _ordenDetalleActual = null;
        }

        // ============================================================
        // ✅ Recalcula métricas:
        //    - Total Facturado = Confirmadas + Finalizadas
        //    - Ventas Cobradas = cantidad de Finalizadas
        //    - Comisión = 2.5% × (Confirmadas + Finalizadas)
        //    - Canceladas/Anuladas NO cuentan
        // ============================================================
        private void RecalcularMetricasPersonales()
        {
            decimal totalFacturado = 0m;
            int operacionesCobradas = 0;

            foreach (DataGridViewRow row in DGVVentas.Rows)
            {
                if (row.IsNewRow || !row.Visible) continue;

                string estado = row.Cells["ColEstado"].Value?.ToString() ?? "";
                decimal total = Convert.ToDecimal(row.Cells["ColTotal"].Value ?? 0);

                switch (estado)
                {
                    case "Confirmada":
                        // ✅ Suma al Total Facturado pero NO cuenta como cobrada
                        totalFacturado += total;
                        break;

                    case "Finalizada":
                        // ✅ Suma al Total Facturado Y cuenta como cobrada
                        totalFacturado += total;
                        operacionesCobradas++;
                        break;

                    case "Pendiente":
                    case "Cancelada":
                    case "Anulada":
                    default:
                        // ❌ No cuenta
                        break;
                }
            }

            // ✅ Comisión sobre el Total Facturado (Confirmadas + Finalizadas)
            decimal comision = totalFacturado * 0.025m;

            LValorTotalVentas.Text = totalFacturado.ToString("C2");
            LValorOperaciones.Text = $"{operacionesCobradas} operaciones";
            LValorComision.Text = comision.ToString("C2");
        }
        // ============================================================
        // ✅ BOTÓN: Reimprimir comprobante (con detalle completo)
        // ============================================================
        private async void BReimprimirTicket_Click(object sender, EventArgs e)
        {
            if (DGVVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un comprobante de la grilla para reimprimir.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int idOrden = Convert.ToInt32(DGVVentas.CurrentRow.Cells["ColIdVenta"].Value ?? 0);

                // Traer la orden completa con detalles
                var orden = await _ordenVentaLogica.ObtenerPorId(idOrden);
                if (orden == null)
                {
                    MessageBox.Show("No se pudo obtener la orden.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _ordenDetalleActual = orden;

                PrintDocument pd = new PrintDocument();
                pd.DocumentName = $"Reimpresion_{orden.NumeroPresupuesto}";
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
                MessageBox.Show($"Error al reimprimir comprobante:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ✅ Impresión del ticket COMPLETO con detalle
        // ============================================================
        private void ImprimirTicket_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_ordenDetalleActual == null) return;

            Graphics g = e.Graphics;
            float x = 50;
            float y = 50;
            var orden = _ordenDetalleActual;
            string vendedor = SesionUsuario.Nombre ?? "Vendedor";

            using (Font fTitulo = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 9.5f))
            using (Font fHeader = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Font fRow = new Font("Segoe UI", 9))
            using (Brush bOcre = new SolidBrush(Color.FromArgb(212, 131, 53)))
            using (Brush bGrafito = new SolidBrush(Color.FromArgb(38, 40, 44)))
            using (Brush bGris = new SolidBrush(Color.Gray))
            using (Pen penLinea = new Pen(Color.FromArgb(210, 215, 220), 1))
            {
                // ============================
                // ENCABEZADO
                // ============================
                g.DrawString("HIERRO Y FORJA", fTitulo, bOcre, x, y);
                g.DrawString($"DUPLICADO - {orden.TipoDocumentoDescripcion?.ToUpper() ?? "COMPROBANTE"}", fSub, bGrafito, x, y + 28);
                g.DrawString($"N° {orden.NumeroPresupuesto}  |  Fecha: {orden.FechaCreacion:dd/MM/yyyy HH:mm}  |  Vendedor: {vendedor}", fSub, bGris, x, y + 48);

                y += 75;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 15;

                // ============================
                // DATOS DEL CLIENTE
                // ============================
                g.DrawString($"Cliente: {orden.ClienteNombre ?? "Consumidor Final"}", fHeader, bGrafito, x, y);
                g.DrawString($"Estado: {orden.EstadoVentaDescripcion}", fHeader, bGrafito, x + 500, y);

                y += 22;
                if (!string.IsNullOrEmpty(orden.ClienteDocumento))
                {
                    g.DrawString($"Documento: {orden.ClienteDocumento}", fSub, bGris, x, y);
                    y += 18;
                }

                if (orden.FechaValidez.HasValue)
                {
                    g.DrawString($"Válido hasta: {orden.FechaValidez.Value:dd/MM/yyyy}", fSub, bGris, x, y);
                    y += 18;
                }

                y += 10;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 15;

                // ============================
                // CABECERAS DE DETALLE
                // ============================
                g.DrawString("Código", fHeader, bOcre, x, y);
                g.DrawString("Descripción", fHeader, bOcre, x + 80, y);
                g.DrawString("Cant.", fHeader, bOcre, x + 420, y);
                g.DrawString("P. Unit.", fHeader, bOcre, x + 490, y);
                g.DrawString("Subtotal", fHeader, bOcre, x + 620, y);

                y += 22;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 10;

                // ============================
                // DETALLES
                // ============================
                if (orden.Detalles != null)
                {
                    foreach (var d in orden.Detalles)
                    {
                        g.DrawString(d.ProductoCodigo ?? "", fRow, bGrafito, x, y);
                        g.DrawString(d.ProductoNombre ?? "", fRow, bGrafito, x + 80, y);
                        g.DrawString(d.Cantidad.ToString(), fRow, bGrafito, x + 430, y);
                        g.DrawString(d.PrecioUnitario.ToString("C2"), fRow, bGrafito, x + 490, y);
                        g.DrawString(d.Subtotal.ToString("C2"), fRow, bGrafito, x + 620, y);

                        y += 22;
                    }
                }

                // ============================
                // TOTAL
                // ============================
                y += 20;
                g.DrawLine(penLinea, x, y, 750, y);
                y += 12;

                g.DrawString($"TOTAL: {orden.Total:C2}", fTitulo, bOcre, x + 500, y);
            }
        }

        // ============================================================
        // ✅ BOTÓN: Exportar Excel (con datos reales)
        // ============================================================
        private void BExportarExcel_Click(object sender, EventArgs e)
        {
            if (DGVVentas.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros en la grilla para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Libro de Excel (*.xls)|*.xls";
                sfd.FileName = $"MisVentas_{DateTime.Now:yyyyMMdd_HHmm}.xls";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder xml = new StringBuilder();

                        xml.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        xml.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
                        xml.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                        xml.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
                        xml.AppendLine(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
                        xml.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                        xml.AppendLine(" xmlns:html=\"http://www.w3.org/TR/REC-html40\">");

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

                        xml.AppendLine(" <Worksheet ss:Name=\"Mis Ventas\">");
                        xml.AppendLine("  <Table ss:DefaultRowHeight=\"20\">");
                        xml.AppendLine("   <Column ss:Width=\"50\"/>");
                        xml.AppendLine("   <Column ss:Width=\"120\"/>");
                        xml.AppendLine("   <Column ss:Width=\"140\"/>");
                        xml.AppendLine("   <Column ss:Width=\"220\"/>");
                        xml.AppendLine("   <Column ss:Width=\"70\"/>");
                        xml.AppendLine("   <Column ss:Width=\"110\"/>");
                        xml.AppendLine("   <Column ss:Width=\"100\"/>");

                        string vendedor = SesionUsuario.Nombre ?? "Vendedor";

                        xml.AppendLine("   <Row ss:Height=\"26\">");
                        xml.AppendLine("    <Cell ss:StyleID=\"sTitulo\"><Data ss:Type=\"String\">HIERRO Y FORJA - HISTORIAL DE VENTAS</Data></Cell>");
                        xml.AppendLine("   </Row>");
                        xml.AppendLine("   <Row ss:Height=\"18\">");
                        xml.AppendLine($"    <Cell ss:StyleID=\"sSubtitulo\"><Data ss:Type=\"String\">Vendedor: {vendedor} | Exportado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</Data></Cell>");
                        xml.AppendLine("   </Row>");
                        xml.AppendLine("   <Row ss:Height=\"10\"/>");

                        xml.AppendLine("   <Row ss:Height=\"24\">");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">ID</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Fecha / Hora</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">N° Comprobante</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Cliente</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Ítems</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Total</Data></Cell>");
                        xml.AppendLine("    <Cell ss:StyleID=\"sHeader\"><Data ss:Type=\"String\">Estado</Data></Cell>");
                        xml.AppendLine("   </Row>");

                        foreach (DataGridViewRow row in DGVVentas.Rows)
                        {
                            if (row.IsNewRow || !row.Visible) continue;

                            int id = Convert.ToInt32(row.Cells["ColIdVenta"].Value ?? 0);
                            string fecha = row.Cells["ColFecha"].Value?.ToString() ?? "";
                            string comprobante = row.Cells["ColComprobante"].Value?.ToString() ?? "";
                            string cliente = System.Security.SecurityElement.Escape(
                                row.Cells["ColCliente"].Value?.ToString() ?? "");
                            int cantItems = Convert.ToInt32(row.Cells["ColCantItems"].Value ?? 0);
                            decimal total = Convert.ToDecimal(row.Cells["ColTotal"].Value ?? 0);
                            string estado = row.Cells["ColEstado"].Value?.ToString() ?? "";

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

                        File.WriteAllText(sfd.FileName, xml.ToString(), Encoding.UTF8);

                        MessageBox.Show("El historial de ventas se exportó exitosamente como planilla de Excel.",
                            "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al generar la planilla de Excel:\n{ex.Message}",
                            "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}