using System;

namespace CapaDatos.Helpers
{
    public static class FechaHelper
    {
        private static readonly TimeZoneInfo ArgentinaTz = ObtenerZonaArgentina();

        private static TimeZoneInfo ObtenerZonaArgentina()
        {
            try
            {
                // Funciona en .NET 6+ y Windows moderno
                return TimeZoneInfo.FindSystemTimeZoneById("America/Argentina/Buenos_Aires");
            }
            catch
            {
                // Fallback para Windows clásico / .NET Framework
                return TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            }
        }

        /// <summary>
        /// Convierte una fecha UTC (que viene de la API) a hora Argentina.
        /// Si la fecha ya es local, la devuelve tal cual.
        /// </summary>
        public static DateTime ToArgentina(DateTime utc)
        {
            if (utc.Kind == DateTimeKind.Local) return utc;

            // La API manda las fechas sin "Kind" especificado, forzamos UTC
            var utcSpecified = DateTime.SpecifyKind(utc, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(utcSpecified, ArgentinaTz);
        }

        /// <summary>
        /// Formatea una fecha UTC como string en hora Argentina.
        /// </summary>
        public static string ToArgentinaString(DateTime utc, string format = "dd/MM/yyyy HH:mm")
            => ToArgentina(utc).ToString(format);

        /// <summary>
        /// Convierte una fecha Argentina (input del usuario) a UTC para enviar a la API.
        /// </summary>
        public static DateTime ToUtc(DateTime argentina)
        {
            var unspecified = DateTime.SpecifyKind(argentina, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTimeToUtc(unspecified, ArgentinaTz);
        }
    }
}