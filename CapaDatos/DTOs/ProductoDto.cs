using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PRODUCTO DTO - PARA CONSULTAS (GET)
    //    ✅ MODIFICADO: Alineado con la respuesta real de la API
    //    La API devuelve "categoria" y "proveedor" como string,
    //    no los IDs.
    // ============================================================
    public class ProductoDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("codBarras")]
        public string CodBarras { get; set; }

        [JsonProperty("codigoInterno")]
        public string CodigoInterno { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("costo")]
        public decimal Costo { get; set; }

        [JsonProperty("precioMinorista")]
        public decimal PrecioMinorista { get; set; }

        [JsonProperty("precioMayorista")]
        public decimal? PrecioMayorista { get; set; }

        [JsonProperty("stockActual")]
        public int StockActual { get; set; }

        [JsonProperty("stockMinimo")]
        public int StockMinimo { get; set; }

        [JsonProperty("stockMaximo")]
        public int StockMaximo { get; set; }

        // ✅ La API manda el NOMBRE de la categoría
        [JsonProperty("categoria")]
        public string CategoriaNombre { get; set; }

        // ✅ La API manda el NOMBRE del proveedor
        [JsonProperty("proveedor")]
        public string ProveedorNombre { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        // ⚠️ La API no devuelve estos campos en el GET
        //    (hasta que modifiquemos el controller)
        [JsonIgnore]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public int? ProveedorId { get; set; }
    }

    // ============================================================
    // 2. CREAR PRODUCTO DTO - PARA POST Y PUT
    //    ✅ MODIFICADO: Se eliminó ActualizarProductoDto porque
    //    la API usa CrearProductoDto para PUT también
    // ============================================================
    public class CrearProductoDto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("codBarras")]
        public string CodBarras { get; set; }

        [JsonProperty("codigoInterno")]
        public string CodigoInterno { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("costo")]
        public decimal Costo { get; set; }

        [JsonProperty("precioMinorista")]
        public decimal PrecioMinorista { get; set; }

        [JsonProperty("precioMayorista")]
        public decimal? PrecioMayorista { get; set; }

        [JsonProperty("stockActual")]
        public int StockActual { get; set; }

        [JsonProperty("stockMinimo")]
        public int StockMinimo { get; set; }

        [JsonProperty("stockMaximo")]
        public int StockMaximo { get; set; }

        [JsonProperty("categoriaId")]
        public int CategoriaId { get; set; }

        [JsonProperty("proveedorId")]
        public int? ProveedorId { get; set; }
    }

    // ✅ Eliminado: ActualizarProductoDto (la API usa CrearProductoDto para PUT)
}