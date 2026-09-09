using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. TIPO DOCUMENTO DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/tipodocumentos, GET /api/tipodocumentos/{id}
    // ============================================================
    public class TipoDocumentoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR TIPO DOCUMENTO DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/tipodocumentos
    // ============================================================
    public class CrearTipoDocumentoDto
    {
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR TIPO DOCUMENTO DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/tipodocumentos/{id}
    // ============================================================
    public class ActualizarTipoDocumentoDto
    {
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}