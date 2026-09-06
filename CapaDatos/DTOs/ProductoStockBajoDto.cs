namespace CapaDatos.DTOs
{
    public class ProductoStockBajoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoInterno { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int Diferencia { get; set; }
    }
}