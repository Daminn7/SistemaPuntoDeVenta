using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - DIRECCIÓN
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de direcciones.
    // ============================================================

    public class DireccionLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public DireccionLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todas las direcciones registradas.
        /// Se usa en: GET /api/direcciones
        /// </summary>
        public async Task<List<DireccionDto>> ObtenerTodos() => await _apiClient.GetDireccionesAsync();

        /// <summary>
        /// Obtiene una dirección por su ID.
        /// Se usa en: GET /api/direcciones/{id}
        /// </summary>
        public async Task<DireccionDto> ObtenerPorId(int id) => await _apiClient.GetDireccionAsync(id);

        /// <summary>
        /// Crea una nueva dirección.
        /// Se usa en: POST /api/direcciones
        /// </summary>
        /// <param name="d">Datos de la dirección a crear</param>
        public async Task<DireccionDto> Crear(CrearDireccionDto d) => await _apiClient.CreateDireccionAsync(d);

        /// <summary>
        /// Actualiza una dirección existente.
        /// Se usa en: PUT /api/direcciones/{id}
        /// </summary>
        /// <param name="id">ID de la dirección a actualizar</param>
        /// <param name="d">Datos actualizados de la dirección</param>
        public async Task<DireccionDto> Actualizar(int id, ActualizarDireccionDto d) => await _apiClient.UpdateDireccionAsync(id, d);

        /// <summary>
        /// Elimina (desactiva) una dirección por su ID.
        /// Se usa en: DELETE /api/direcciones/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeleteDireccionAsync(id);
    }
}