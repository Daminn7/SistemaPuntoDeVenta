using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. MEDIO PAGO DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/mediopagos
    // ============================================================
    public class MedioPagoDto
    {
        // ✅ La API devuelve "id"
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idMedioPago")]
        public int IdMedioPago { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        public override string ToString() => Descripcion;
    }

    // ============================================================
    // 2. CREAR MEDIO PAGO DTO
    // ============================================================
    public class CrearMedioPagoDto
    {
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR MEDIO PAGO DTO
    // ============================================================
    public class ActualizarMedioPagoDto
    {
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}