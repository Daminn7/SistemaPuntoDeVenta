using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - ORDEN DE VENTA
    // ============================================================
    public class OrdenVentaLogica
    {
        private readonly ApiClient _apiClient;

        public OrdenVentaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        /// <summary>
        /// Obtiene todas las órdenes activas.
        /// Se usa en: GET /api/ordenesventa
        /// </summary>
        public async Task<List<OrdenVentaDto>> ObtenerTodas()
            => await _apiClient.GetOrdenesVentaAsync();

        /// <summary>
        /// Obtiene una orden por su ID (con detalles).
        /// Se usa en: GET /api/ordenesventa/{id}
        /// </summary>
        public async Task<OrdenVentaDto> ObtenerPorId(int id)
            => await _apiClient.GetOrdenVentaAsync(id);

        /// <summary>
        /// Obtiene solo las órdenes Confirmadas (para el Cajero).
        /// Se usa en: GET /api/ordenesventa/confirmadas
        /// </summary>
        public async Task<List<OrdenVentaDto>> ObtenerConfirmadas()
            => await _apiClient.GetOrdenesVentaConfirmadasAsync();

        /// <summary>
        /// Crea una nueva orden con sus detalles.
        /// Se usa en: POST /api/ordenesventa
        /// </summary>
        public async Task<CrearOrdenVentaResponseDto> Crear(CrearOrdenVentaDto orden)
            => await _apiClient.CreateOrdenVentaAsync(orden);

        /// <summary>
        /// Confirma una orden (Pendiente → Confirmada).
        /// Se usa en: PUT /api/ordenesventa/{id}/confirmar
        /// </summary>
        public async Task<dynamic> Confirmar(int id)
            => await _apiClient.ConfirmarOrdenVentaAsync(id);

        /// <summary>
        /// Cancela una orden.
        /// Se usa en: PUT /api/ordenesventa/{id}/cancelar
        /// </summary>
        public async Task<dynamic> Cancelar(int id)
            => await _apiClient.CancelarOrdenVentaAsync(id);
        /// <summary>
        /// Anula una orden Finalizada (repone stock + anula venta asociada).
        /// Se usa en: PUT /api/ordenesventa/{id}/anular
        /// </summary>
        public async Task<dynamic> Anular(int id)
            => await _apiClient.AnularOrdenVentaAsync(id);
    }
}