using System;
using System.Collections.Generic;

namespace ApiComercial.Models.Responses
{
    public class ReporteVentasResponse
    {
        public List<ReporteVentaResponse> Ventas { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalGanancias { get; set; }
        public int CantidadVentas { get; set; }

        public ReporteVentasResponse()
        {
            Ventas = new List<ReporteVentaResponse>();
        }
    }
}
