using System;

namespace ApiComercial.Entities
{
    public class Cuota
    {
        /// <summary>
        /// Indica el codigo de la cuota generada
        /// </summary>
        public int CuotaId { get; set; } 
        /// <summary>
        /// GUarda el id de la venta a la que pertenecen las cuotas
        /// </summary>
        public int VentaId { get; set; } 
        /// <summary>
        /// Indica el numero de la cuota
        /// </summary>
        public int NumeroCuota { get; set; } 
        /// <summary>
        /// Indica el monto de la cuota a pagar
        /// </summary>
        public int MontoCuota { get; set; }
        /// <summary>
        /// Indica la fecha de vencimiento de la cuota
        /// </summary>
        public DateTime FechaVencimiento { get; set; } 
        public DateTime? FechaPago { get; set; }
        /// <summary>
        /// Establece si la cuota esta pagada o no, 0 es pendiente y 1 es pagado
        /// </summary>
        public int Estado { get; set; }


    }
}
