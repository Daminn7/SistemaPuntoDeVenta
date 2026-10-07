using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PROVEEDOR DTO - PARA CONSULTAS (GET)
    //    ✅ MODIFICADO: Alineado con la respuesta real de la API
    // ============================================================
    public class ProveedorDto
    {
        [JsonProperty("idProveedor")]
        public int Id { get; set; }

        [JsonProperty("usuarioId")]
        public int UsuarioId { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("estadoDescripcion")]
        public string EstadoDescripcion { get; set; }

        [JsonProperty("fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty("fechaBaja")]
        public DateTime? FechaBaja { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dni")]
        public string Dni { get; set; }

        [JsonProperty("cuilCuit")]
        public string CuilCuit { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("localidadId")]
        public int LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string Localidad { get; set; }

        [JsonProperty("provincia")]
        public string Provincia { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }
    }

    // ============================================================
    // 2. CREAR PROVEEDOR DTO - PARA POST Y PUT
    //    ✅ MODIFICADO: Estructura anidada con Direccion y Telefono
    // ============================================================
    public class CrearProveedorDto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("dni")]
        public string Dni { get; set; }

        [JsonProperty("cuilCuit")]
        public string CuilCuit { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("direccion")]
        public DireccionCrearDto Direccion { get; set; }

        [JsonProperty("telefono")]
        public TelefonoCrearDto Telefono { get; set; }

        [JsonProperty("estado")]
        public bool? Estado { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PROVEEDOR DTO
    //    ✅ MODIFICADO: Ahora es alias de CrearProveedorDto
    //    (la API usa el mismo DTO para PUT)
    // ============================================================
    public class ActualizarProveedorDto : CrearProveedorDto
    {
    }
}