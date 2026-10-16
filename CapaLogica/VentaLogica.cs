using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class VentaLogica
    {
        private readonly ApiClient _apiClient;

        public VentaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<dynamic> Cobrar(CrearVentaCompletaDto venta)
            => await _apiClient.CreateVentaCompletaAsync(venta);

        // ✅ NUEVO: Obtener todas las ventas
        public async Task<List<VentaDto>> ObtenerTodas()
            => await _apiClient.GetVentasAsync();
    }
}