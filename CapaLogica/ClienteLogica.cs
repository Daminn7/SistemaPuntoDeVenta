using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClienteLogica
    {
        private readonly ApiClient _apiClient;

        public ClienteLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<List<ClienteDto>> ObtenerTodos() => await _apiClient.GetClientesAsync();
        public async Task<ClienteDto> ObtenerPorId(int id) => await _apiClient.GetClienteAsync(id);
        public async Task<ClienteDto> Crear(ClienteDto c) => await _apiClient.CreateClienteAsync(c);
        public async Task<ClienteDto> Actualizar(int id, ClienteDto c) => await _apiClient.UpdateClienteAsync(id, c);
        public async Task Eliminar(int id) => await _apiClient.DeleteClienteAsync(id);
    }
}