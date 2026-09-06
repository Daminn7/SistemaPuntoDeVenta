using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ReporteLogica
    {
        private readonly ApiClient _apiClient;

        public ReporteLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<dynamic> VentasDelDia() => await _apiClient.GetReporteVentasDiaAsync();
        public async Task<dynamic> VentasDeLaSemana() => await _apiClient.GetReporteVentasSemanaAsync();
        public async Task<dynamic> ProductosMasVendidos() => await _apiClient.GetReporteProductosMasVendidosAsync();
        public async Task<dynamic> StockBajo() => await _apiClient.GetReporteStockBajoAsync();
        public async Task<dynamic> ResumenCajaDia() => await _apiClient.GetReporteCajaDiaAsync();
        public async Task<dynamic> ResumenGeneral() => await _apiClient.GetResumenGeneralAsync();
    }
}