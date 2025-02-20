namespace ApiComercial.Entities
{
    /// <summary>
    /// Clase de ventas
    /// </summary>
    public class Venta
    {
        /// <summary>
        /// Id de la venta
        /// </summary>
        public int VentaId { get; set; }
        /// <summary>
        /// Codigo del cliente que hace la compra
        /// </summary>
        public int ClienteId { get; set; } // Foreign Key
        /// <summary>
        /// Fecha de la venta
        /// </summary>
        public DateTime FechaVenta { get; set; }
        /// <summary>
        /// Precio total de las ventas
        /// </summary>
        public decimal PrecioTotal { get; set; }
        /// <summary>
        /// INteres anual con la que se calculan las cuotas
        /// </summary>
        public decimal InteresAnual { get; set; }
        /// <summary>
        /// Cantidad de cuotas de la venta
        /// </summary>
        public int CantidadCuotas { get; set; }

    }

}
