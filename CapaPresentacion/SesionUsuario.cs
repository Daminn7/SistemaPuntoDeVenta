namespace CapaPresentacion
{
    // ============================================================
    // ✅ NUEVO: Clase estática GLOBAL de sesión
    //    Antes estaba anidada dentro de FormPrincipal,
    //    ahora es accesible desde TODOS los formularios.
    // ============================================================
    public static class SesionUsuario
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Rol { get; set; }
    }
}