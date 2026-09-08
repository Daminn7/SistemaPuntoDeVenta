using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia con el login (descomentado)
            Application.Run(new FormPrincipal("Gastón", "Administrador")); //FormLogin()
        }
    }
}