using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PERSONAL DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/personal, GET /api/personal/{id}
    //    ✅ MODIFICADO: Alineado con la respuesta real de la API
    // ============================================================
    public class PersonalDto
    {
        // ✅ La API devuelve "idPersonal", no "id"
        [JsonProperty("idPersonal")]
        public int IdPersonal { get; set; }

        // ✅ La API devuelve "codUsuario"
        [JsonProperty("codUsuario")]
        public string CodUsuario { get; set; }

        // ✅ La API devuelve "perfilId"
        [JsonProperty("perfilId")]
        public int PerfilId { get; set; }

        // ✅ La API devuelve "perfil" (string)
        [JsonProperty("perfil")]
        public string Perfil { get; set; }

        // ✅ NUEVO: La API devuelve "usuarioId"
        [JsonProperty("usuarioId")]
        public int UsuarioId { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        // ✅ La API solo devuelve Dni/CuilCuit en GET/{id}
        [JsonProperty("dni")]
        public string Dni { get; set; }

        [JsonProperty("cuilCuit")]
        public string CuilCuit { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty("fechaBaja")]
        public DateTime? FechaBaja { get; set; }

        [JsonProperty("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR PERSONAL DTO - PARA CREACIÓN (POST)
    //    ✅ MODIFICADO: Alineado con CrearUsuarioDto de la API
    // ============================================================
    public class CrearPersonalDto
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

        [JsonProperty("codUsuario")]
        public string CodUsuario { get; set; }

        [JsonProperty("contrasena")]
        public string Contrasena { get; set; }

        [JsonProperty("perfilId")]
        public int? PerfilId { get; set; }

        // ✅ NUEVO: La API necesita saber que es Personal
        [JsonProperty("esPersonal")]
        public bool EsPersonal { get; set; } = true;

        [JsonProperty("direccionId")]
        public int? DireccionId { get; set; }

        [JsonProperty("telefonoId")]
        public int? TelefonoId { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PERSONAL DTO - PARA MODIFICACIÓN (PUT)
    //    ✅ MODIFICADO: Alineado con ActualizarUsuarioDto de la API
    // ============================================================
    public class ActualizarPersonalDto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("dni")]
        public string Dni { get; set; }

        [JsonProperty("cuilCuit")]
        public string CuilCuit { get; set; }
        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        // ✅ NUEVO: La API permite cambiar el código de usuario
        [JsonProperty("codUsuario")]
        public string CodUsuario { get; set; }

        // ✅ NUEVO: La API permite cambiar la contraseña (opcional)
        [JsonProperty("nuevaContrasena")]
        public string NuevaContrasena { get; set; }

        // ✅ MODIFICADO: int? para que la API distinga null de 0
        [JsonProperty("perfilId")]
        public int? PerfilId { get; set; }

        // ✅ MODIFICADO: bool? para que la API distinga null de false
        [JsonProperty("estado")]
        public bool? Estado { get; set; }
    }
}