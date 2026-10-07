using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PERFIL DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/perfiles, GET /api/perfiles/{id}
    //    ✅ MODIFICADO: Se agregó [JsonProperty] para mapear
    //    correctamente "idPerfil" (la API devuelve idPerfil, no id)
    // ============================================================
    public class PerfilDto
    {
        // ✅ La API devuelve "idPerfil" (no "id")
        [JsonProperty("idPerfil")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

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
    // 2. CREAR PERFIL DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/perfiles
    // ============================================================
    public class CrearPerfilDto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PERFIL DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/perfiles/{id}
    // ============================================================
    public class ActualizarPerfilDto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}