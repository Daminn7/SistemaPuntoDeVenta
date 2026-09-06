namespace CapaDatos.DTOs
{
    public class PersonalDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public string CodUsuario { get; set; }
        public int PerfilId { get; set; }
        public string Perfil { get; set; }
        public bool Estado { get; set; }
    }
}