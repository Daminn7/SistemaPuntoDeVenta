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

        public async Task<List<VentaDto>> ObtenerTodos() => await _apiClient.GetVentasAsync();
        public async Task<VentaDto> ObtenerPorId(int id) => await _apiClient.GetVentaAsync(id);
        public async Task<VentaDto> Crear(VentaDto v) => await _apiClient.CreateVentaAsync(v);
        public async Task<VentaDto> Actualizar(int id, VentaDto v) => await _apiClient.UpdateVentaAsync(id, v);
        public async Task Eliminar(int id) => await _apiClient.DeleteVentaAsync(id);
        public async Task<dynamic> Anular(int id) => await _apiClient.AnularVentaAsync(id);
    }
}