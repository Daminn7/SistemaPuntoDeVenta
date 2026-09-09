using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - PRODUCTO
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de productos.
    // ============================================================

    public class ProductoLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public ProductoLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todos los productos registrados.
        /// Se usa en: GET /api/productos
        /// </summary>
        public async Task<List<ProductoDto>> ObtenerTodos() => await _apiClient.GetProductosAsync();

        /// <summary>
        /// Obtiene un producto por su ID.
        /// Se usa en: GET /api/productos/{id}
        /// </summary>
        public async Task<ProductoDto> ObtenerPorId(int id) => await _apiClient.GetProductoAsync(id);

        /// <summary>
        /// Crea un nuevo producto.
        /// Se usa en: POST /api/productos
        /// </summary>
        /// <param name="p">Datos del producto a crear</param>
        public async Task<ProductoDto> Crear(CrearProductoDto p) => await _apiClient.CreateProductoAsync(p);

        /// <summary>
        /// Actualiza un producto existente.
        /// Se usa en: PUT /api/productos/{id}
        /// </summary>
        /// <param name="id">ID del producto a actualizar</param>
        /// <param name="p">Datos actualizados del producto</param>
        public async Task<ProductoDto> Actualizar(int id, ActualizarProductoDto p) => await _apiClient.UpdateProductoAsync(id, p);

        /// <summary>
        /// Elimina (desactiva) un producto por su ID.
        /// Se usa en: DELETE /api/productos/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeleteProductoAsync(id);

        /// <summary>
        /// Obtiene los productos con stock por debajo del mínimo.
        /// Se usa en: GET /api/productos/stock-bajo
        /// </summary>
        public async Task<List<ProductoStockBajoDto>> ObtenerStockBajo() => await _apiClient.GetProductosStockBajoAsync();
    }
}