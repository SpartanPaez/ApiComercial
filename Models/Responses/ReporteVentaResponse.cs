using System;

namespace ApiComercial.Models.Responses
{
    public class ReporteVentaResponse
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string? ClienteNombre { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia { get; set; }
        public bool EsContado { get; set; }
        public string? Estado { get; set; }
    }
}
