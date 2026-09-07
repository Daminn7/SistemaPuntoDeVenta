using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - TABLAS MAESTRAS
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la obtención de tablas maestras
    // (datos de referencia utilizados en toda la aplicación).
    // ============================================================

    public class TablasMaestrasLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public TablasMaestrasLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS - TABLAS MAESTRAS
        // ============================================================

        /// <summary>
        /// Obtiene todas las provincias.
        /// Se usa en: GET /api/provincias
        /// </summary>
        public async Task<List<ProvinciaDto>> GetProvincias() => await _apiClient.GetProvinciasAsync();

        /// <summary>
        /// Obtiene todas las localidades.
        /// Se usa en: GET /api/localidades
        /// </summary>
        public async Task<List<LocalidadDto>> GetLocalidades() => await _apiClient.GetLocalidadesAsync();

        /// <summary>
        /// Obtiene todos los perfiles de usuario.
        /// Se usa en: GET /api/perfiles
        /// </summary>
        public async Task<List<PerfilDto>> GetPerfiles() => await _apiClient.GetPerfilesAsync();

        /// <summary>
        /// Obtiene todos los tipos de documento.
        /// Se usa en: GET /api/tipodocumentos
        /// </summary>
        public async Task<List<TipoDocumentoDto>> GetTipoDocumentos() => await _apiClient.GetTipoDocumentosAsync();

        /// <summary>
        /// Obtiene todos los estados de venta.
        /// Se usa en: GET /api/estadoventas
        /// </summary>
        public async Task<List<EstadoVentaDto>> GetEstadoVentas() => await _apiClient.GetEstadoVentasAsync();

        /// <summary>
        /// Obtiene todos los medios de pago.
        /// Se usa en: GET /api/mediopagos
        /// </summary>
        public async Task<List<MedioPagoDto>> GetMedioPagos() => await _apiClient.GetMedioPagosAsync();

        /// <summary>
        /// Obtiene todos los tipos de movimiento.
        /// Se usa en: GET /api/tipomovimientos
        /// </summary>
        public async Task<List<TipoMovimientoDto>> GetTipoMovimientos() => await _apiClient.GetTipoMovimientosAsync();
    }
}