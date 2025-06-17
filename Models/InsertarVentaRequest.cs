/// <summary>
/// Para insertar ventas
/// </summary>
public class InsertarVentaRequest
{
    /// <summary>
    /// Indica el id de la venta
    /// </summary>
    public int VentaId { get; set; }
    /// <summary>
    /// Indica el codigo del cliente que esta haciendo la compra
    /// </summary>
    public int ClienteId { get; set; }
    /// <summary>
    /// Fecha en la que se realiza la compra
    /// </summary>
    public DateTime FechaVenta { get; set; }
    /// <summary>
    /// Precio total de la venta
    /// </summary>
    public decimal? PrecioTotal { get; set; }
    /// <summary>
    /// Interes anual de la venta
    /// </summary>
    public decimal? InteresAnual { get; set; }
    /// <summary>
    /// Cantidad de cuotas generadas para la venta
    /// </summary>
    public int CantidadCuotas { get; set; }
    public decimal? PrecioTotalCuotas { get; set; }
}
