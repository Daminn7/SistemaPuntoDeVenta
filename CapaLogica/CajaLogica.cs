using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CajaLogica
    {
        private readonly ApiClient _apiClient;

        public CajaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<List<CajaDto>> ObtenerTodos() => await _apiClient.GetCajasAsync();
        public async Task<CajaDto> ObtenerPorId(int id) => await _apiClient.GetCajaAsync(id);
        public async Task<CajaDto> ObtenerActiva() => await _apiClient.GetCajaActivaAsync();
        public async Task<CajaDto> Abrir(CajaDto caja) => await _apiClient.AbrirCajaAsync(caja);
        public async Task<dynamic> Cerrar(int id) => await _apiClient.CerrarCajaAsync(id);
    }
}