using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ProductoLogica
    {
        private readonly ApiClient _apiClient;

        public ProductoLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<List<ProductoDto>> ObtenerTodos() => await _apiClient.GetProductosAsync();
        public async Task<ProductoDto> ObtenerPorId(int id) => await _apiClient.GetProductoAsync(id);
        public async Task<ProductoDto> Crear(ProductoDto p) => await _apiClient.CreateProductoAsync(p);
        public async Task<ProductoDto> Actualizar(int id, ProductoDto p) => await _apiClient.UpdateProductoAsync(id, p);
        public async Task Eliminar(int id) => await _apiClient.DeleteProductoAsync(id);
        public async Task<List<ProductoStockBajoDto>> ObtenerStockBajo() => await _apiClient.GetProductosStockBajoAsync();
    }
}