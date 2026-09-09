using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. CLIENTE DTO - PARA CONSULTAS BASICAS (GET)
    //    Se usa en: GET /api/clientes, GET /api/clientes/{id}
    // ============================================================
    public class ClienteDto
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
    }

    // ============================================================
    // 2. CREAR CLIENTE DTO - PARA CREACIÓN (POST)
    //    Solo necesita el UsuarioId (el usuario ya debe existir)
    //    Se usa en: POST /api/clientes
    // ============================================================
    public class CrearClienteDto
    {
        public int UsuarioId { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR CLIENTE DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/clientes/{id}
    // ============================================================
    public class ActualizarClienteDto
    {
        public bool Estado { get; set; }
        public DateTime? FechaBaja { get; set; }
    }

    // ============================================================
    // 4. CLIENTE RESPONSE DTO - PARA CONSULTAS (GET) COMPLETAS
    //    Se usa en: GET /api/clientes, GET /api/clientes/{id}
    //    ✅ INCLUYE CAMPOS DIRECTOS DE LOCALIDAD Y PROVINCIA
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

        // ✅ NUEVOS CAMPOS DIRECTOS (vienen de la API)
        public int? LocalidadId { get; set; }
        public string Localidad { get; set; }
        public int? LocalidadCodigoPostal { get; set; }
        public int? ProvinciaId { get; set; }
        public string Provincia { get; set; }
    }
}