using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - PERSONAL
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de personal (empleados).
    // ============================================================

    public class PersonalLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public PersonalLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todo el personal registrado.
        /// Se usa en: GET /api/personal
        /// </summary>
        public async Task<List<PersonalDto>> ObtenerTodos() => await _apiClient.GetPersonalAsync();

        /// <summary>
        /// Obtiene un empleado por su ID.
        /// Se usa en: GET /api/personal/{id}
        /// </summary>
        public async Task<PersonalDto> ObtenerPorId(int id) => await _apiClient.GetPersonalByIdAsync(id);

        /// <summary>
        /// Crea un nuevo empleado.
        /// Se usa en: POST /api/personal
        /// </summary>
        /// <param name="p">Datos del empleado a crear</param>
        public async Task<PersonalDto> Crear(CrearPersonalDto p) => await _apiClient.CreatePersonalAsync(p);

        /// <summary>
        /// Actualiza un empleado existente.
        /// Se usa en: PUT /api/personal/{id}
        /// </summary>
        /// <param name="id">ID del empleado a actualizar</param>
        /// <param name="p">Datos actualizados del empleado</param>
        public async Task<PersonalDto> Actualizar(int id, ActualizarPersonalDto p) => await _apiClient.UpdatePersonalAsync(id, p);

        /// <summary>
        /// Elimina (desactiva) un empleado por su ID.
        /// Se usa en: DELETE /api/personal/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeletePersonalAsync(id);
    }
}