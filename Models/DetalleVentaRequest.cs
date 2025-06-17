namespace ApiComercial.Models
{
    /// <summary>
    /// Entidad del detalle de la venta
    /// </summary>
    public class DetalleVentaRequest
    {
        /// <summary>
        /// Id de la venta
        /// </summary>
        public int VentaId { get; set; }
        /// <summary>
        /// Numero de chasis del vehiculo
        /// </summary>
        public string? IdChasis { get; set; } // Relación con autos
        /// <summary>
        /// Cantidad
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Precio por unidad
        /// </summary>
        public decimal? PrecioUnitario { get; set; }
        /// <summary>
        /// Precio total con interes
        /// </summary>
        public decimal? Total { get; set; }

    }

}
