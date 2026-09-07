using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PROVINCIA DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/provincias, GET /api/provincias/{id}
    // ============================================================
    public class ProvinciaDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR PROVINCIA DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/provincias
    // ============================================================
    public class CrearProvinciaDto
    {
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PROVINCIA DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/provincias/{id}
    // ============================================================
    public class ActualizarProvinciaDto
    {
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}