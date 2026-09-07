using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - PROVEEDOR
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de proveedores.
    // ============================================================

    public class ProveedorLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public ProveedorLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todos los proveedores registrados.
        /// Se usa en: GET /api/proveedores
        /// </summary>
        public async Task<List<ProveedorDto>> ObtenerTodos() => await _apiClient.GetProveedoresAsync();

        /// <summary>
        /// Obtiene un proveedor por su ID.
        /// Se usa en: GET /api/proveedores/{id}
        /// </summary>
        public async Task<ProveedorDto> ObtenerPorId(int id) => await _apiClient.GetProveedorAsync(id);

        /// <summary>
        /// Crea un nuevo proveedor.
        /// Se usa en: POST /api/proveedores
        /// </summary>
        /// <param name="p">Datos del proveedor a crear</param>
        public async Task<ProveedorDto> Crear(CrearProveedorDto p) => await _apiClient.CreateProveedorAsync(p);

        /// <summary>
        /// Actualiza un proveedor existente.
        /// Se usa en: PUT /api/proveedores/{id}
        /// </summary>
        /// <param name="id">ID del proveedor a actualizar</param>
        /// <param name="p">Datos actualizados del proveedor</param>
        public async Task<ProveedorDto> Actualizar(int id, ActualizarProveedorDto p) => await _apiClient.UpdateProveedorAsync(id, p);

        /// <summary>
        /// Elimina (desactiva) un proveedor por su ID.
        /// Se usa en: DELETE /api/proveedores/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeleteProveedorAsync(id);
    }
}