using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - TELÉFONO
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de teléfonos.
    // ============================================================

    public class TelefonoLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public TelefonoLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todos los teléfonos registrados.
        /// Se usa en: GET /api/telefonos
        /// </summary>
        public async Task<List<TelefonoDto>> ObtenerTodos() => await _apiClient.GetTelefonosAsync();

        /// <summary>
        /// Obtiene un teléfono por su ID.
        /// Se usa en: GET /api/telefonos/{id}
        /// </summary>
        public async Task<TelefonoDto> ObtenerPorId(int id) => await _apiClient.GetTelefonoAsync(id);

        /// <summary>
        /// Crea un nuevo teléfono.
        /// Se usa en: POST /api/telefonos
        /// </summary>
        /// <param name="t">Datos del teléfono a crear</param>
        public async Task<TelefonoDto> Crear(CrearTelefonoDto t) => await _apiClient.CreateTelefonoAsync(t);

        /// <summary>
        /// Actualiza un teléfono existente.
        /// Se usa en: PUT /api/telefonos/{id}
        /// </summary>
        /// <param name="id">ID del teléfono a actualizar</param>
        /// <param name="t">Datos actualizados del teléfono</param>
        public async Task<TelefonoDto> Actualizar(int id, ActualizarTelefonoDto t) => await _apiClient.UpdateTelefonoAsync(id, t);

        /// <summary>
        /// Elimina (desactiva) un teléfono por su ID.
        /// Se usa en: DELETE /api/telefonos/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeleteTelefonoAsync(id);
    }
}