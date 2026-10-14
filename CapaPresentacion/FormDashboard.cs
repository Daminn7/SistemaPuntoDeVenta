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
using CapaLogica;
using CapaDatos.DTOs;
using Newtonsoft.Json.Linq;
using CapaDatos.Services;      // ✅ Para ApiClient

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

        // ✅ Lógica de la API
        private readonly OrdenVentaLogica _ordenVentaLogica = new OrdenVentaLogica();
        private readonly ApiClient _apiClient;

        public FormDashboard()
        {
            InitializeComponent();

            // ✅ Inicializar ApiClient
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (CapaDatos.Helpers.TokenManager.IsAuthenticated)
                _apiClient.SetToken(CapaDatos.Helpers.TokenManager.Token);

            if (pbIconoTitulo != null)
                pbIconoTitulo.Image = GenerarIconoDashboard(Color.FromArgb(212, 131, 53));
        }

        // ✅ MODIFICADO: Ahora es async
        private async void FormDashboard_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosVisualesCards();
            await CargarDatosRealesAsync();
        }

        private void ConfigurarEstilosVisualesCards()
        {
            pnlKpiVentas.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiVentas, ColorOcre);
            pnlKpiCaja.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiCaja, ColorVerde);
            pnlKpiClientes.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiClientes, ColorGrafito);
            pnlKpiStock.Paint += (s, e) => DibujarAcentoCard(e.Graphics, pnlKpiStock, ColorRojoAlerta);

            pnlCardIzquierda.Paint += (s, e) => DibujarBordeSimple(e.Graphics, pnlCardIzquierda);
            pnlCardDerecha.Paint += (s, e) => DibujarBordeSimple(e.Graphics, pnlCardDerecha);

            dgvStockCritico.CellFormatting += DgvStockCritico_CellFormatting;
        }

        private void DibujarAcentoCard(Graphics g, Control ctrl, Color colorAcento)
        {
            g.SmoothingMode = SmoothingMode.None;

            using (Brush brushBlanco = new SolidBrush(Color.White))
            {
                g.FillRectangle(brushBlanco, 0, 0, ctrl.Width, ctrl.Height);
            }

            using (Pen penBorde = new Pen(ColorBordeCard, 1))
            {
                g.DrawRectangle(penBorde, 0, 0, ctrl.Width - 1, ctrl.Height - 1);
            }

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
            if (dgvStockCritico.Columns[e.ColumnIndex].Name == "colStockActual" && e.Value != null)
            {
                e.CellStyle.BackColor = Color.FromArgb(253, 237, 236);
                e.CellStyle.ForeColor = ColorRojoAlerta;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        // ============================================================
        // ✅ NUEVO: Carga datos reales desde la API
        // ============================================================
        private async Task CargarDatosRealesAsync()
        {
            try
            {
                await CargarResumenAsync();
                await CargarUltimasVentasAsync();
                await CargarStockBajoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ✅ NUEVO: Carga los KPIs desde /api/reportes/resumen
        // ============================================================
        private async Task CargarResumenAsync()
        {
            try
            {
                var resumen = await _apiClient.GetResumenGeneralAsync();

                if (resumen == null) return;

                // ✅ KPI 1: Ventas de hoy
                int ventasCantidad = resumen.ventasHoy?.cantidad ?? 0;
                decimal ventasTotal = resumen.ventasHoy?.total ?? 0;
                lblKpiVentasValor.Text = ventasTotal.ToString("C2");
                lblKpiVentasSub.Text = $"{ventasCantidad} comprobantes";

                // ✅ KPI 2: Caja
                decimal fondoInicial = resumen.caja?.fondoInicial ?? 0;
                decimal totalVentasCaja = resumen.caja?.totalVentas ?? 0;
                decimal efectivoEnCaja = fondoInicial + totalVentasCaja;
                bool cajaAbierta = resumen.caja?.abierta ?? false;

                lblKpiCajaValor.Text = efectivoEnCaja.ToString("C2");
                lblKpiCajaSub.Text = cajaAbierta ? "Turno abierto" : "Sin caja abierta";

                // ✅ KPI 3: Clientes
                int clientes = resumen.clientes ?? 0;
                lblKpiClientesValor.Text = clientes.ToString();
                lblKpiClientesSub.Text = "Cartera activa";

                // ✅ KPI 4: Stock crítico
                int stockBajo = resumen.inventario?.stockBajo ?? 0;
                lblKpiStockValor.Text = stockBajo.ToString();
                lblKpiStockSub.Text = "Insumos a reponer";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar resumen: {ex.Message}");
            }
        }

        // ============================================================
        // ✅ NUEVO: Carga las últimas ventas desde /api/ordenesventa
        // ============================================================
        private async Task CargarUltimasVentasAsync()
        {
            try
            {
                var ordenes = await _ordenVentaLogica.ObtenerTodas();

                dgvUltimasVentas.Rows.Clear();

                if (ordenes == null || ordenes.Count == 0)
                {
                    dgvUltimasVentas.ClearSelection();
                    return;
                }

                // ✅ Tomar las últimas 5
                var ultimas = ordenes
                    .OrderByDescending(o => o.FechaCreacion)
                    .Take(5)
                    .ToList();

                foreach (var orden in ultimas)
                {
                    dgvUltimasVentas.Rows.Add(
                        orden.IdOrden,
                        orden.FechaCreacion.ToString("HH:mm"),
                        orden.NumeroPresupuesto ?? $"#{orden.IdOrden}",
                        orden.ClienteNombre ?? "Consumidor Final",
                        orden.Total.ToString("C2")
                    );
                }

                dgvUltimasVentas.ClearSelection();
                if (dgvUltimasVentas.CurrentCell != null)
                    dgvUltimasVentas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar últimas ventas: {ex.Message}");
            }
        }

        // ============================================================
        // ✅ NUEVO: Carga el stock bajo desde /api/reportes/stock-bajo
        // ============================================================
        private async Task CargarStockBajoAsync()
        {
            try
            {
                var reporte = await _apiClient.GetReporteStockBajoAsync();

                dgvStockCritico.Rows.Clear();

                if (reporte == null) return;

                // ✅ El reporte trae un objeto con "total" y "productos"
                var json = reporte as JObject;
                if (json == null) return;

                var productos = json["productos"] as JArray;
                if (productos == null || productos.Count == 0)
                {
                    dgvStockCritico.ClearSelection();
                    return;
                }

                foreach (var prod in productos)
                {
                    string codigo = prod["codBarras"]?.ToString() ?? "";
                    string nombre = prod["nombre"]?.ToString() ?? "";
                    int stockActual = prod["stockActual"]?.Value<int>() ?? 0;
                    int stockMinimo = prod["stockMinimo"]?.Value<int>() ?? 0;

                    dgvStockCritico.Rows.Add(
                        codigo,
                        nombre,
                        stockActual.ToString(),
                        stockMinimo.ToString()
                    );
                }

                dgvStockCritico.ClearSelection();
                if (dgvStockCritico.CurrentCell != null)
                    dgvStockCritico.CurrentCell = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar stock bajo: {ex.Message}");
            }
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
                    g.DrawRectangle(pen, 3f, 4f, 26f, 24f);
                    g.DrawLine(pen, 3f, 21f, 29f, 21f);

                    g.FillRectangle(brush, 7f, 13f, 4f, 8f);
                    g.FillRectangle(brush, 14f, 8f, 4f, 13f);
                    g.FillRectangle(brush, 21f, 11f, 4f, 10f);
                }
            }
            return bmp;
        }

        // ✅ MODIFICADO: Ahora es async
        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnActualizar.Text = "Actualizando...";

            try
            {
                await CargarDatosRealesAsync();
            }
            finally
            {
                btnActualizar.Enabled = true;
                btnActualizar.Text = "↻ Actualizar";
            }
        }
    }
}