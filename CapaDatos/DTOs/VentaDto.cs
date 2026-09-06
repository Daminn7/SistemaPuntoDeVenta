namespace CapaDatos.DTOs
{
    public class VentaDto
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int PersonalId { get; set; }
        public int CajaId { get; set; }
        public decimal TotalCobrado { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal RecargoAplicado { get; set; }
        public DateTime Fecha { get; set; }
    }
}