using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - CATEGORIA
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de categorías.
    // ============================================================

    public class CategoriaLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public CategoriaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todas las categorías registradas.
        /// Se usa en: GET /api/categorias
        /// </summary>
        public async Task<List<CategoriaDto>> ObtenerTodos() => await _apiClient.GetCategoriasAsync();

        /// <summary>
        /// Obtiene una categoría por su ID.
        /// Se usa en: GET /api/categorias/{id}
        /// </summary>
        public async Task<CategoriaDto> ObtenerPorId(int id) => await _apiClient.GetCategoriaAsync(id);

        /// <summary>
        /// Crea una nueva categoría.
        /// Se usa en: POST /api/categorias
        /// </summary>
        /// <param name="c">Datos de la categoría a crear</param>
        public async Task<CategoriaDto> Crear(CrearCategoriaDto c) => await _apiClient.CreateCategoriaAsync(c);

        /// <summary>
        /// Actualiza una categoría existente.
        /// Se usa en: PUT /api/categorias/{id}
        /// </summary>
        /// <param name="id">ID de la categoría a actualizar</param>
        /// <param name="c">Datos actualizados de la categoría</param>
        public async Task<CategoriaDto> Actualizar(int id, ActualizarCategoriaDto c) => await _apiClient.UpdateCategoriaAsync(id, c);

        /// <summary>
        /// Elimina (desactiva) una categoría por su ID.
        /// Se usa en: DELETE /api/categorias/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeleteCategoriaAsync(id);
    }
}