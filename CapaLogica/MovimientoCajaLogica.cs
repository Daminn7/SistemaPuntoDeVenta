using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - MOVIMIENTO CAJA
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de movimientos de caja.
    // ============================================================

    public class MovimientoCajaLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public MovimientoCajaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene los movimientos de una caja específica.
        /// Se usa en: GET /api/caja/{id}/movimientos
        /// </summary>
        /// <param name="cajaId">ID de la caja</param>
        public async Task<dynamic> ObtenerPorCajaId(int cajaId) => await _apiClient.GetMovimientosCajaAsync(cajaId);

        /// <summary>
        /// Registra un nuevo movimiento de caja.
        /// Se usa en: POST /api/caja/movimiento
        /// </summary>
        /// <param name="movimiento">Datos del movimiento</param>
        public async Task<dynamic> Registrar(CrearMovimientoCajaDto movimiento)
        {
            // Validaciones de negocio
            if (movimiento.CajaId <= 0)
                throw new System.Exception("Debe especificar una caja válida.");

            if (movimiento.PersonalId <= 0)
                throw new System.Exception("Debe especificar un personal válido.");

            if (movimiento.TipoMovimientoId <= 0)
                throw new System.Exception("Debe especificar un tipo de movimiento válido.");

            if (movimiento.Monto <= 0)
                throw new System.Exception("El monto del movimiento debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(movimiento.Descripcion))
                throw new System.Exception("Debe especificar una descripción del movimiento.");

            return await _apiClient.RegistrarMovimientoCajaAsync(movimiento);
        }
    }
}