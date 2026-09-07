using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PRODUCTO DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/productos, GET /api/productos/{id}
    // ============================================================
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodBarras { get; set; }
        public string CodigoInterno { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioMinorista { get; set; }
        public decimal? PrecioMayorista { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int? ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR PRODUCTO DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/productos
    // ============================================================
    public class CrearProductoDto
    {
        public string Nombre { get; set; }
        public string CodBarras { get; set; }
        public string CodigoInterno { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioMinorista { get; set; }
        public decimal? PrecioMayorista { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int? ProveedorId { get; set; }
        public int CategoriaId { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PRODUCTO DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/productos/{id}
    // ============================================================
    public class ActualizarProductoDto
    {
        public string Nombre { get; set; }
        public string CodBarras { get; set; }
        public string CodigoInterno { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioMinorista { get; set; }
        public decimal? PrecioMayorista { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int? ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public bool Estado { get; set; }
    }
}