using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - VENTA
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de ventas.
    // ============================================================

    public class VentaLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public VentaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todas las ventas registradas.
        /// Se usa en: GET /api/ventas
        /// </summary>
        public async Task<List<VentaDto>> ObtenerTodos() => await _apiClient.GetVentasAsync();

        /// <summary>
        /// Obtiene una venta por su ID.
        /// Se usa en: GET /api/ventas/{id}
        /// </summary>
        public async Task<VentaDto> ObtenerPorId(int id) => await _apiClient.GetVentaAsync(id);

        /// <summary>
        /// Crea una nueva venta.
        /// Se usa en: POST /api/ventas
        /// </summary>
        /// <param name="v">Datos de la venta a crear</param>
        public async Task<VentaDto> Crear(CrearVentaDto v) => await _apiClient.CreateVentaAsync(v);

        /// <summary>
        /// Actualiza una venta existente.
        /// Se usa en: PUT /api/ventas/{id}
        /// </summary>
        /// <param name="id">ID de la venta a actualizar</param>
        /// <param name="v">Datos actualizados de la venta</param>
        public async Task<VentaDto> Actualizar(int id, ActualizarVentaDto v) => await _apiClient.UpdateVentaAsync(id, v);

        /// <summary>
        /// Elimina (desactiva) una venta por su ID.
        /// Se usa en: DELETE /api/ventas/{id}
        /// </summary>
        public async Task Eliminar(int id) => await _apiClient.DeleteVentaAsync(id);

        /// <summary>
        /// Anula una venta por su ID.
        /// Se usa en: POST /api/ventas/{id}/anular
        /// </summary>
        /// <param name="id">ID de la venta a anular</param>
        /// <param name="motivo">Motivo de la anulación</param>
        public async Task<dynamic> Anular(int id, string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
                throw new System.Exception("Debe especificar un motivo para la anulación.");

            var anulacion = new AnularVentaDto { Motivo = motivo };
            return await _apiClient.AnularVentaAsync(id, anulacion);
        }
    }
}