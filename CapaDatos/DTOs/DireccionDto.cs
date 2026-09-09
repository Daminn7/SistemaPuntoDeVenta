using System;
using Newtonsoft.Json;  // ← AGREGAR ESTE USING

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. DIRECCION DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/direcciones, GET /api/direcciones/{id}
    // ============================================================
    public class DireccionDto
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int? Numero { get; set; }
        public int? Edificio { get; set; }
        public int? Piso { get; set; }
        public string Departamento { get; set; }
        public string Descripcion { get; set; }
        public int LocalidadId { get; set; }
        public string LocalidadNombre { get; set; }
        public string ProvinciaNombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR DIRECCION DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/direcciones
    // ============================================================
    public class CrearDireccionDto
    {
        [JsonProperty("calle")]         // ← AGREGAR
        public string Calle { get; set; }

        [JsonProperty("numero")]        // ← AGREGAR
        public int? Numero { get; set; }

        [JsonProperty("edificio")]      // ← AGREGAR
        public int? Edificio { get; set; }

        [JsonProperty("piso")]          // ← AGREGAR
        public int? Piso { get; set; }

        [JsonProperty("departamento")]  // ← AGREGAR
        public string Departamento { get; set; }

        [JsonProperty("descripcion")]   // ← AGREGAR
        public string Descripcion { get; set; }

        [JsonProperty("localidadId")]   // ← AGREGAR
        public int LocalidadId { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR DIRECCION DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/direcciones/{id}
    // ============================================================
    public class ActualizarDireccionDto
    {
        [JsonProperty("calle")]
        public string Calle { get; set; }

        [JsonProperty("numero")]
        public int? Numero { get; set; }

        [JsonProperty("edificio")]
        public int? Edificio { get; set; }

        [JsonProperty("piso")]
        public int? Piso { get; set; }

        [JsonProperty("departamento")]
        public string Departamento { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("localidadId")]
        public int LocalidadId { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}