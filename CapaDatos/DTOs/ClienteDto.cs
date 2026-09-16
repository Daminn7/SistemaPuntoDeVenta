using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. CLIENTE RESPONSE DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/clientes, GET /api/clientes/{id}
    //    Coincide con la respuesta de la API
    // ============================================================
    public class ClienteResponseDto
    {
        public int IdCliente { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Direccion { get; set; }
        public object DireccionCompleta { get; set; }
        public string Telefono { get; set; }
        public object TelefonoCompleto { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Estado { get; set; }

        // ✅ CAMPOS DIRECTOS (vienen de la API)
        public int? LocalidadId { get; set; }
        public string Localidad { get; set; }
        public int? LocalidadCodigoPostal { get; set; }
        public int? ProvinciaId { get; set; }
        public string Provincia { get; set; }
    }

    // ============================================================
    // 2. CREAR CLIENTE DTO - PARA CREACIÓN (POST) Y ACTUALIZACIÓN (PUT)
    //    ✅ MODIFICADO: Ahora contiene todos los datos del cliente
    //    (usuario + dirección + teléfono) para enviar en una sola petición.
    //    Se usa en: POST /api/clientes, PUT /api/clientes/{id}
    // ============================================================
    public class CrearClienteDto
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

        // ✅ NUEVO: Dirección anidada
        [JsonProperty("direccion")]
        public DireccionCrearDto Direccion { get; set; }

        // ✅ NUEVO: Teléfono anidado
        [JsonProperty("telefono")]
        public TelefonoCrearDto Telefono { get; set; }
    }

    // ============================================================
    // 3. DIRECCION DTO - PARA ANIDAR DENTRO DE CrearClienteDto
    //    ✅ NUEVO: Se usa dentro de CrearClienteDto para enviar
    //    la dirección junto con el cliente en una sola petición.
    // ============================================================
    public class DireccionCrearDto
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
    }

    // ============================================================
    // 4. TELEFONO DTO - PARA ANIDAR DENTRO DE CrearClienteDto
    //    ✅ NUEVO: Se usa dentro de CrearClienteDto para enviar
    //    el teléfono junto con el cliente en una sola petición.
    // ============================================================
    public class TelefonoCrearDto
    {
        [JsonProperty("caracteristica")]
        public string Caracteristica { get; set; }

        [JsonProperty("numero")]
        public long Numero { get; set; }
    }
}