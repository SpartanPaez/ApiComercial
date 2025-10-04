namespace ApiComercial.Entities.Cuotas
{
    /// <summary>
    /// Clase que representa una cuota de una venta
    /// </summary>
    public class Pago
    {
        public int PagoId { get; set; }
        /// <summary>
        /// Id de la cuota
        /// </summary>
        public int CuotaId { get; set; }
        /// <summary>
        /// Id del medio de pago utilizado
        /// </summary>
        /// <value></value>
        public int MedioPagoId { get; set; }
        /// <summary>
        /// Fecha de vencimiento de la cuota
        /// </summary>
        public DateTime FechaPago { get; set; }
        /// <summary>
        /// Monto de la cuota
        /// </summary>
        public decimal Monto { get; set; }
        /// <summary>
        /// NUmnero de cheque, id boleta, etc.
        /// </summary>
        /// <value></value>
        public string? Referencia { get; set; }
        public int IdBanco { get; set; }

    }
}