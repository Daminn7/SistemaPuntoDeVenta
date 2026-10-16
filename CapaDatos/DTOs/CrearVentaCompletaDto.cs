using System.Collections.Generic;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // CREAR VENTA COMPLETA - PARA POST /api/ventas
    // ============================================================
    public class CrearVentaCompletaDto
    {
        [JsonProperty("ordenId")]
        public int OrdenId { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("cajaId")]
        public int CajaId { get; set; }

        [JsonProperty("descuentoAplicado")]
        public decimal DescuentoAplicado { get; set; } = 0;

        [JsonProperty("recargoAplicado")]
        public decimal RecargoAplicado { get; set; } = 0;

        [JsonProperty("pagos")]
        public List<PagoInputDto> Pagos { get; set; } = new List<PagoInputDto>();
    }

    // ============================================================
    // PAGO INPUT
    // ============================================================
    public class PagoInputDto
    {
        [JsonProperty("medioPagoId")]
        public int MedioPagoId { get; set; }

        [JsonProperty("monto")]
        public decimal Monto { get; set; }

        [JsonProperty("detalle")]
        public string Detalle { get; set; }
    }
}