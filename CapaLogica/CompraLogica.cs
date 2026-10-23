using System.Collections.Generic;
using System.Threading.Tasks;
using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;

namespace CapaLogica
{
    public class CompraLogica
    {
        private readonly ApiClient _apiClient;

        public CompraLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<List<CompraDto>> ObtenerTodas()
            => await _apiClient.GetComprasAsync();

        public async Task<CompraDto> ObtenerPorId(int id)
            => await _apiClient.GetCompraAsync(id);

        public async Task<dynamic> Crear(CrearCompraDto compra)
            => await _apiClient.CreateCompraAsync(compra);
    }
}