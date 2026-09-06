using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class TablasMaestrasLogica
    {
        private readonly ApiClient _apiClient;

        public TablasMaestrasLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        public async Task<List<ProvinciaDto>> GetProvincias() => await _apiClient.GetProvinciasAsync();
        public async Task<List<LocalidadDto>> GetLocalidades() => await _apiClient.GetLocalidadesAsync();
        public async Task<List<PerfilDto>> GetPerfiles() => await _apiClient.GetPerfilesAsync();
        public async Task<List<TipoDocumentoDto>> GetTipoDocumentos() => await _apiClient.GetTipoDocumentosAsync();
        public async Task<List<EstadoVentaDto>> GetEstadoVentas() => await _apiClient.GetEstadoVentasAsync();
        public async Task<List<MedioPagoDto>> GetMedioPagos() => await _apiClient.GetMedioPagosAsync();
        public async Task<List<TipoMovimientoDto>> GetTipoMovimientos() => await _apiClient.GetTipoMovimientosAsync();
    }
}