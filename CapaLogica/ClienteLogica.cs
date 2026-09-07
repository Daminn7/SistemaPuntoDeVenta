using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - CLIENTE
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de clientes.
    // ============================================================

    public class ClienteLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public ClienteLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todos los clientes registrados.
        /// Se usa en: GET /api/clientes
        /// </summary>
        public async Task<List<ClienteResponseDto>> ObtenerTodos() => await _apiClient.GetClientesAsync();

        /// <summary>
        /// Obtiene un cliente por su ID.
        /// Se usa en: GET /api/clientes/{id}
        /// </summary>
        public async Task<ClienteResponseDto> ObtenerPorId(int id) => await _apiClient.GetClienteAsync(id);

        /// <summary>
        /// Crea un nuevo cliente completo (usuario + dirección + teléfono).
        /// Se usa en: POST /api/clientes
        /// </summary>
        /// <param name="c">Datos completos del cliente</param>
        public async Task<dynamic> Crear(CrearClienteDto c) => await _apiClient.CreateClienteAsync(c);

        /// <summary>
        /// Actualiza un cliente completo (usuario + dirección + teléfono).
        /// Se usa en: PUT /api/clientes/{id}
        /// </summary>
        /// <param name="id">ID del cliente a actualizar</param>
        /// <param name="c">Datos actualizados del cliente</param>
        public async Task<dynamic> Actualizar(int id, CrearClienteDto c) => await _apiClient.UpdateClienteAsync(id, c);

        /// <summary>
        /// Elimina (desactiva) un cliente por su ID.
        /// Se usa en: DELETE /api/clientes/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeleteClienteAsync(id);
    }
}