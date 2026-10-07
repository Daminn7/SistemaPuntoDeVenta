using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    public class CategoriaDto
    {
        // ✅ La API devuelve "idCategoria" (no "id")
        [JsonProperty("idCategoria")]
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

    public class CrearCategoriaDto
    {
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
    }

    public class ActualizarCategoriaDto
    {
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}