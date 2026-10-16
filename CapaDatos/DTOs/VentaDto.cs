using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. VENTA DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/ventas, GET /api/ventas/{id}
    // ============================================================
    public class VentaDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ordenId")]
        public int OrdenId { get; set; }

        [JsonProperty("numeroPresupuesto")]
        public string NumeroPresupuesto { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("personalNombre")]
        public string PersonalNombre { get; set; }

        [JsonProperty("cajaId")]
        public int CajaId { get; set; }

        // ✅ NUEVOS: cliente
        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("clienteNombre")]
        public string ClienteNombre { get; set; }

        [JsonProperty("clienteDocumento")]
        public string ClienteDocumento { get; set; }

        [JsonProperty("totalCobrado")]
        public decimal TotalCobrado { get; set; }

        [JsonProperty("descuentoAplicado")]
        public decimal DescuentoAplicado { get; set; }

        [JsonProperty("recargoAplicado")]
        public decimal RecargoAplicado { get; set; }

        [JsonProperty("fechaCobro")]
        public DateTime FechaCobro { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        // ✅ NUEVO: forma de pago
        [JsonProperty("formaPago")]
        public string FormaPago { get; set; }
    }

    // ============================================================
    // 2. CREAR VENTA DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/ventas
    // ============================================================
    public class CrearVentaDto
    {
        public int OrdenId { get; set; }
        public int PersonalId { get; set; }
        public int CajaId { get; set; }
        public decimal TotalCobrado { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal RecargoAplicado { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR VENTA DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/ventas/{id}
    // ============================================================
    public class ActualizarVentaDto
    {
        public decimal TotalCobrado { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal RecargoAplicado { get; set; }
        public bool Estado { get; set; }
    }
}