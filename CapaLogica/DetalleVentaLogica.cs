using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - DETALLE VENTA (DETALLE ORDEN)
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (ApiClient).
    // Contiene la lógica de negocio para la gestión de detalles de orden de venta.
    // ============================================================

    public class DetalleVentaLogica
    {
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // Inicializa el cliente API con la URL base.
        // Si el usuario ya está autenticado, asigna el token automáticamente.
        // ============================================================
        public DetalleVentaLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Obtiene todos los detalles de una orden específica.
        /// Se usa en: GET /api/ordenventa/{id}/detalles
        /// </summary>
        /// <param name="ordenId">ID de la orden</param>
        public async Task<dynamic> ObtenerPorOrdenId(int ordenId) => await _apiClient.GetDetallesByOrdenIdAsync(ordenId);

        /// <summary>
        /// Agrega un nuevo detalle a una orden.
        /// Se usa en: POST /api/ordenventa/{id}/detalles
        /// </summary>
        /// <param name="ordenId">ID de la orden</param>
        /// <param name="detalle">Datos del detalle</param>
        public async Task<dynamic> Agregar(int ordenId, CrearDetalleOrdenDto detalle)
        {
            // Validaciones de negocio
            if (ordenId <= 0)
                throw new System.Exception("Debe especificar una orden válida.");

            if (detalle.ProductoId <= 0)
                throw new System.Exception("Debe seleccionar un producto válido.");

            if (detalle.Cantidad <= 0)
                throw new System.Exception("La cantidad debe ser mayor a cero.");

            if (detalle.PrecioUnitario <= 0)
                throw new System.Exception("El precio unitario debe ser mayor a cero.");

            return await _apiClient.AddDetalleToOrdenAsync(ordenId, detalle);
        }

        /// <summary>
        /// Actualiza un detalle de orden existente.
        /// Se usa en: PUT /api/detalleorden/{id}
        /// </summary>
        /// <param name="id">ID del detalle</param>
        /// <param name="detalle">Datos actualizados</param>
        public async Task<dynamic> Actualizar(int id, ActualizarDetalleOrdenDto detalle)
        {
            // Validaciones de negocio
            if (id <= 0)
                throw new System.Exception("Debe especificar un detalle válido.");

            if (detalle.Cantidad <= 0)
                throw new System.Exception("La cantidad debe ser mayor a cero.");

            if (detalle.PrecioUnitario <= 0)
                throw new System.Exception("El precio unitario debe ser mayor a cero.");

            return await _apiClient.UpdateDetalleOrdenAsync(id, detalle);
        }

        /// <summary>
        /// Elimina un detalle de orden por su ID.
        /// Se usa en: DELETE /api/detalleorden/{id}
        /// </summary>
        public async Task Eliminar(int id)
        {
            if (id <= 0)
                throw new System.Exception("Debe especificar un detalle válido.");

            await _apiClient.DeleteDetalleOrdenAsync(id);
        }
    }
}