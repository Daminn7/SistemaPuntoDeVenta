using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuarioDatos
    {
        public bool Autenticar(string codigoAcceso, string password, out string rol, out string nombreCompleto)
        {
            rol = string.Empty;
            nombreCompleto = string.Empty;
            // Simulación temporal en memoria para pruebas (más adelante conectará a la API REST / MySQL)
            if (codigoAcceso.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin123")
            {
                nombreCompleto = "Carlos Mendoza";
                rol = "Administrador";
                return true;
            }
            else if (codigoAcceso.Equals("vendedor", StringComparison.OrdinalIgnoreCase) && password == "1234")
            {
                nombreCompleto = "Martín Gómez";
                rol = "Vendedor";
                return true;
            }
            else if (codigoAcceso.Equals("cajero", StringComparison.OrdinalIgnoreCase) && password == "1234")
            {
                nombreCompleto = "Laura Benítez";
                rol = "Cobranza";
                return true;
            }

            return false;
        }
    }
}

