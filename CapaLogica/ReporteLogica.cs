using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - REPORTES
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la generación de reportes.
    // ============================================================

    public class ReporteLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public ReporteLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene el reporte de ventas del día actual.
        /// Se usa en: GET /api/reportes/ventas/dia
        /// </summary>
        public async Task<dynamic> VentasDelDia() => await _apiClient.GetReporteVentasDiaAsync();

        /// <summary>
        /// Obtiene el reporte de ventas de la semana actual.
        /// Se usa en: GET /api/reportes/ventas/semana
        /// </summary>
        public async Task<dynamic> VentasDeLaSemana() => await _apiClient.GetReporteVentasSemanaAsync();

        /// <summary>
        /// Obtiene el reporte de productos más vendidos.
        /// Se usa en: GET /api/reportes/productos/mas-vendidos
        /// </summary>
        public async Task<dynamic> ProductosMasVendidos() => await _apiClient.GetReporteProductosMasVendidosAsync();

        /// <summary>
        /// Obtiene el reporte de productos con stock bajo.
        /// Se usa en: GET /api/reportes/stock-bajo
        /// </summary>
        public async Task<dynamic> StockBajo() => await _apiClient.GetReporteStockBajoAsync();

        /// <summary>
        /// Obtiene el resumen de caja del día.
        /// Se usa en: GET /api/reportes/caja/dia
        /// </summary>
        public async Task<dynamic> ResumenCajaDia() => await _apiClient.GetReporteCajaDiaAsync();

        /// <summary>
        /// Obtiene el resumen general del sistema.
        /// Se usa en: GET /api/reportes/resumen
        /// </summary>
        public async Task<dynamic> ResumenGeneral() => await _apiClient.GetResumenGeneralAsync();
    }
}