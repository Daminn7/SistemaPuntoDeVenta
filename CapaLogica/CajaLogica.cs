using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - CAJA
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de caja.
    // ============================================================

    public class CajaLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public CajaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todas las cajas registradas.
        /// Se usa en: GET /api/caja
        /// </summary>
        public async Task<List<CajaDto>> ObtenerTodos() => await _apiClient.GetCajasAsync();

        /// <summary>
        /// Obtiene una caja por su ID.
        /// Se usa en: GET /api/caja/{id}
        /// </summary>
        public async Task<CajaDto> ObtenerPorId(int id) => await _apiClient.GetCajaAsync(id);

        /// <summary>
        /// Obtiene la caja que está actualmente abierta.
        /// Se usa en: GET /api/caja/activa
        /// </summary>
        public async Task<CajaDto> ObtenerActiva() => await _apiClient.GetCajaActivaAsync();

        /// <summary>
        /// Abre una nueva caja con el personal y fondo inicial especificados.
        /// Se usa en: POST /api/caja/apertura
        /// </summary>
        /// <param name="caja">Datos necesarios: PersonalId y FondoInicial</param>
        public async Task<CajaDto> Abrir(CrearCajaDto caja) => await _apiClient.AbrirCajaAsync(caja);

        /// <summary>
        /// Cierra una caja por su ID.
        /// Se usa en: PUT /api/caja/{id}/cierre
        /// </summary>
        public async Task<dynamic> Cerrar(int id) => await _apiClient.CerrarCajaAsync(id);
    }
}