namespace CapaDatos.DTOs
{
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
        public int CategoriaId { get; set; }
        public bool Estado { get; set; }
    }
}