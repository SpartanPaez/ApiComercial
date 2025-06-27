namespace ApiComercial.Models.Request;
public class PagarCuotaRequest
{
    /// <summary>
    /// Id del medio de pago
    /// </summary>
    public int CuotaId { get; set; }
    /// <summary>
    /// Monto a pagar
    /// </summary>
    public int MedioPagoId { get; set; }
    /// <summary>
    /// Fecha de pago
    /// </summary>
    public int MontoPagado { get; set; }
    /// <summary>
    /// Observaciones del pago
    /// </summary>
    public string? Referencia { get; set; }
}