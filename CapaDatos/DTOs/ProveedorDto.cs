using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PROVEEDOR DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/proveedores, GET /api/proveedores/{id}
    // ============================================================
    public class ProveedorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR PROVEEDOR DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/proveedores
    // ============================================================
    public class CrearProveedorDto
    {
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PROVEEDOR DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/proveedores/{id}
    // ============================================================
    public class ActualizarProveedorDto
    {
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}