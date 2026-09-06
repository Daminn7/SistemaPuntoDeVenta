namespace CapaDatos.DTOs
{
    public class CajaDto
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public decimal FondoInicial { get; set; }
        public decimal? FondoFinal { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public bool Estado { get; set; }
    }
}