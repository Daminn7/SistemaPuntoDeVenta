using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuarioDatos
    {
        public bool Autenticar(string usuario, string password, out string rol, out string nombreCompleto)
        {
            // Simulación temporal en memoria (más adelante conectará a la API REST / MySQL)
            if (usuario == "admin" && password == "admin123")
            {
                rol = "Administrador";
                nombreCompleto = "Administrador General";
                return true;
            }
            else if (usuario == "vendedor" && password == "1234")
            {
                rol = "Vendedor";
                nombreCompleto = "Vendedor Mostrador";
                return true;
            }
            else if (usuario == "cajero" && password == "1234")
            {
                rol = "Cobranza";
                nombreCompleto = "Cajero Turno Mañana";
                return true;
            }

            rol = string.Empty;
            nombreCompleto = string.Empty;
            return false;
        }
    }
}

