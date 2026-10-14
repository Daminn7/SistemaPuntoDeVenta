using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDatos.DTOs;

namespace CapaPresentacion
{
    public partial class FormHistorialVentas : Form
    {
        // ✅ API: Órdenes de venta
        private readonly OrdenVentaLogica _ordenVentaLogica = new OrdenVentaLogica();
        private List<OrdenVentaDto> _ordenesOriginales = new List<OrdenVentaDto>();
        private int _idOrdenSeleccionada = 0;
        private OrdenVentaDto _ordenDetalleActual = null;

        public FormHistorialVentas()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        // ✅ MODIFICADO: Ahora es async para cargar de la API
        private async void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            pbIconoTitulo.Image = GenerarIconoHistorial(Color.FromArgb(212, 131, 53));

            ConfigurarFechas();
            CargarDesplegableEstados();
            await CargarOrdenesAsync();

            dgvVentas.ClearSelection();
            dgvVentas.CurrentCell = null;
            dgvDetalle.Rows.Clear();
            lblTotalMonto.Text = "$ 0,00";
        }

        private void InicializarComportamiento()
        {
            // ✅ Eventos de filtros
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            cboEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            dtpDesde.ValueChanged += (s, e) => AplicarFiltros();
            dtpHasta.ValueChanged += (s, e) => AplicarFiltros();

            btnBuscar.Click += (s, e) => AplicarFiltros();

            btnLimpiar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                cboEstado.SelectedIndex = 0;
                ConfigurarFechas();
                AplicarFiltros();
            };

            // ✅ Coloración por estado
            dgvVentas.CellFormatting += (s, e) =>
            {
                if (dgvVentas.Columns[e.ColumnIndex].Name == "colEstado" && e.Value != null)
                {
                    string estado = e.Value.ToString();

                    switch (estado)
                    {
                        case "Pendiente":
                            e.CellStyle.ForeColor = Color.FromArgb(212, 131, 53);
                            break;
                        case "Confirmada":
                            e.CellStyle.ForeColor = Color.FromArgb(41, 128, 185);
                            break;
                        case "Finalizada":
                            e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                            break;
                        case "Cancelada":
                            e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34);
                            break;
                        case "Anulada":
                            e.CellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                            break;
                        default:
                            e.CellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                            break;
                    }

                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            };

            // ✅ Al hacer clic en una fila, cargar el detalle
            dgvVentas.CellClick += async (s, e) =>
            {
                if (e.RowIndex < 0) return;
                await CargarDetalleOrdenAsync(e.RowIndex);
            };

            // ✅ Botón Reimprimir
            btnReimprimir.Click += async (s, e) => await ReimprimirOrdenAsync();

            // ✅ Botón Anular
            btnAnular.Click += async (s, e) => await AnularOrdenAsync();
        }

        private void ConfigurarFechas()
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
        }

        // ============================================================
        // ✅ Carga TODAS las órdenes de TODOS los vendedores
        // ============================================================
        private async Task CargarOrdenesAsync()
        {
            try
            {
                var todas = await _ordenVentaLogica.ObtenerTodas();

                _ordenesOriginales = todas?
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
            dgvVentas.Rows.Clear();

            foreach (var orden in ordenes)
            {
                dgvVentas.Rows.Add(
                    orden.IdOrden,
                    orden.NumeroPresupuesto ?? $"#{orden.IdOrden}",
                    orden.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                    orden.ClienteNombre ?? "Consumidor Final",
                    orden.PersonalNombre ?? "",
                    orden.FormaPago ?? "",
                    orden.Total,
                    orden.EstadoVentaDescripcion ?? ""
                );
            }
        }

        // ============================================================
        // ✅ Carga el detalle de la orden seleccionada
        // ============================================================
        private async Task CargarDetalleOrdenAsync(int rowIndex)
        {
            try
            {
                var idValue = dgvVentas.Rows[rowIndex].Cells["colIdVenta"].Value;
                if (idValue == null || idValue == DBNull.Value) return;

                int idOrden = Convert.ToInt32(idValue);
                _idOrdenSeleccionada = idOrden;

                var orden = await _ordenVentaLogica.ObtenerPorId(idOrden);
                _ordenDetalleActual = orden;

                dgvDetalle.Rows.Clear();
                if (orden?.Detalles != null)
                {
                    foreach (var d in orden.Detalles)
                    {
                        dgvDetalle.Rows.Add(
                            d.Cantidad,
                            d.ProductoNombre ?? "",
                            d.PrecioUnitario.ToString("N2"),
                            d.Subtotal.ToString("N2")
                        );
                    }
                }

                lblTotalMonto.Text = orden?.Total.ToString("C2") ?? "$ 0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalle: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ✅ Carga el desplegable con TODOS los estados
        // ============================================================
        private void CargarDesplegableEstados()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[]
            {
                "Todos",
                "Pendiente",
                "Confirmada",
                "Finalizada",
                "Cancelada",
                "Anulada"
            });
            cboEstado.SelectedIndex = 0;
        }

        // ============================================================
        // ✅ Aplica los filtros sobre la grilla
        // ============================================================
        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim().ToLower();
            string estadoFiltro = cboEstado.SelectedIndex > 0 ? cboEstado.Text : "";
            DateTime fechaDesde = dtpDesde.Value.Date;
            DateTime fechaHasta = dtpHasta.Value.Date.AddDays(1);

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.IsNewRow) continue;

                string ticket = row.Cells["colNroTicket"].Value?.ToString().ToLower() ?? "";
                string cliente = row.Cells["colCliente"].Value?.ToString().ToLower() ?? "";
                string vendedor = row.Cells["colVendedor"].Value?.ToString().ToLower() ?? "";
                string estado = row.Cells["colEstado"].Value?.ToString() ?? "";
                string fechaStr = row.Cells["colFecha"].Value?.ToString() ?? "";

                DateTime.TryParse(fechaStr, out DateTime fecha);
                bool coincideFecha = fecha >= fechaDesde && fecha < fechaHasta;

                bool coincideTexto = string.IsNullOrEmpty(texto) ||
                                     ticket.Contains(texto) ||
                                     cliente.Contains(texto) ||
                                     vendedor.Contains(texto);

                bool coincideEstado = string.IsNullOrEmpty(estadoFiltro) ||
                                      estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase);

                row.Visible = coincideTexto && coincideEstado && coincideFecha;
            }

            // Limpiar el detalle al filtrar
            dgvDetalle.Rows.Clear();
            _idOrdenSeleccionada = 0;
            _ordenDetalleActual = null;
            lblTotalMonto.Text = "$ 0,00";
        }

        // ============================================================
        // ✅ BOTÓN: Reimprimir comprobante (con PDF)
        // ============================================================
        private async Task ReimprimirOrdenAsync()
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta de la grilla para reimprimir.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int idOrden = Convert.ToInt32(dgvVentas.CurrentRow.Cells["colIdVenta"].Value ?? 0);

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
                    Width = 850,
                    Height = 650,
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
            string operador = SesionUsuario.Nombre ?? "Operador";

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
                g.DrawString($"REIMPRESIÓN - {orden.TipoDocumentoDescripcion?.ToUpper() ?? "COMPROBANTE"}", fSub, bGrafito, x, y + 28);
                g.DrawString($"N° {orden.NumeroPresupuesto}  |  Fecha: {orden.FechaCreacion:dd/MM/yyyy HH:mm}  |  Operador: {operador}", fSub, bGris, x, y + 48);

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

                if (!string.IsNullOrEmpty(orden.FormaPago))
                {
                    g.DrawString($"Forma de pago: {orden.FormaPago}", fSub, bGris, x, y);
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
        // ✅ BOTÓN: Anular / Cancelar
        //    - Pendiente o Confirmada → Cancelar (estado 3)
        //    - Finalizada → Anular (estado 5)
        // ============================================================
        private async Task AnularOrdenAsync()
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta de la grilla para anular.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int idOrden = Convert.ToInt32(dgvVentas.CurrentRow.Cells["colIdVenta"].Value ?? 0);
                string estado = dgvVentas.CurrentRow.Cells["colEstado"].Value?.ToString() ?? "";

                // Validación: no se pueden anular las ya anuladas/canceladas
                if (estado == "Anulada" || estado == "Cancelada")
                {
                    MessageBox.Show($"Esta venta ya está {estado.ToLower()} y no se puede anular de nuevo.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Determinar acción según estado
                string accion;
                string mensaje;

                if (estado == "Pendiente" || estado == "Confirmada")
                {
                    accion = "cancelar";
                    mensaje = $"¿Está seguro de CANCELAR la orden #{idOrden}?\n\n" +
                              "Se repondrá el stock de los productos.";
                }
                else if (estado == "Finalizada")
                {
                    accion = "anular";
                    mensaje = $"¿Está seguro de ANULAR la venta #{idOrden}?\n\n" +
                              "Se repondrá el stock y se anulará la venta asociada.";
                }
                else
                {
                    MessageBox.Show($"Estado '{estado}' no reconocido.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show(mensaje, "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                // Llamar al endpoint correspondiente
                if (accion == "cancelar")
                    await _ordenVentaLogica.Cancelar(idOrden);
                else
                    await _ordenVentaLogica.Anular(idOrden);

                MessageBox.Show($"Orden {accion}da correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarOrdenesAsync();
                dgvDetalle.Rows.Clear();
                lblTotalMonto.Text = "$ 0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ÍCONO
        // ============================================================
        private Image GenerarIconoHistorial(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawEllipse(pen, 3.5f, 3.5f, 24f, 24f);
                    g.DrawLine(pen, 15.5f, 9f, 15.5f, 15.5f);
                    g.DrawLine(pen, 15.5f, 15.5f, 21f, 15.5f);
                    g.FillEllipse(brush, 14f, 14f, 3.5f, 3.5f);
                }
            }
            return bmp;
        }
    }
}