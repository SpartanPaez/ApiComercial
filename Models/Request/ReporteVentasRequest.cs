using System;

namespace ApiComercial.Models.Request
{
    public class ReporteVentasRequest
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? ClienteId { get; set; }
        public int? MarcaId { get; set; }
        public int? ModeloId { get; set; }
        public bool? SoloContado { get; set; }
    }
}
