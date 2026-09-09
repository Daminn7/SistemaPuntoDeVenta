using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PRODUCTO STOCK BAJO DTO - PARA CONSULTAS (GET)
    //    Devuelve los productos que tienen stock por debajo del mínimo.
    //    Se usa en: GET /api/productos/stock-bajo
    // ============================================================
    public class ProductoStockBajoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoInterno { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int Diferencia { get; set; }  // StockMinimo - StockActual (cantidad que falta)
    }
}