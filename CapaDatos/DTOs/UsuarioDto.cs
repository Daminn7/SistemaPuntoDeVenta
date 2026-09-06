namespace CapaDatos.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public string CodUsuario { get; set; }
        public string Contrasena { get; set; }
        public int PerfilId { get; set; }
        public bool EsPersonal { get; set; }
        public bool EsCliente { get; set; }
        public bool EsProveedor { get; set; }
        public bool Estado { get; set; }
    }
}