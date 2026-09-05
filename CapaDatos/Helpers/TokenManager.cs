using System;

namespace CapaDatos.Helpers
{
    public static class TokenManager
    {
        private static string _token;
        private static DateTime _expiration;

        public static bool IsAuthenticated => !string.IsNullOrEmpty(_token);
        public static string Token => _token;

        public static void SetToken(string token, DateTime expiration)
        {
            _token = token;
            _expiration = expiration;
        }

        public static bool IsTokenValid()
        {
            if (string.IsNullOrEmpty(_token))
                return false;
            if (DateTime.UtcNow > _expiration)
                return false;
            return true;
        }

        public static void ClearToken()
        {
            _token = null;
            _expiration = DateTime.MinValue;
        }
    }
}