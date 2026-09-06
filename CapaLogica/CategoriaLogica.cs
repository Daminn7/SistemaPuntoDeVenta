using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CategoriaLogica
    {
        private readonly ApiClient _apiClient;

        public CategoriaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<List<CategoriaDto>> ObtenerTodos() => await _apiClient.GetCategoriasAsync();
        public async Task<CategoriaDto> ObtenerPorId(int id) => await _apiClient.GetCategoriaAsync(id);
        public async Task<CategoriaDto> Crear(CategoriaDto c) => await _apiClient.CreateCategoriaAsync(c);
        public async Task<CategoriaDto> Actualizar(int id, CategoriaDto c) => await _apiClient.UpdateCategoriaAsync(id, c);
        public async Task Eliminar(int id) => await _apiClient.DeleteCategoriaAsync(id);
    }
}