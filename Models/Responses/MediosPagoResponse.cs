namespace ApiComercial.Models.Responses;

public class MediosPagoResponse
{
    /// <summary>
    /// Id del medio de pago
    /// </summary>
    public int MedioPagoId { get; set; }
    /// <summary>
    /// TC, TD, CHEQUE, EFECTIVO, TRANSFER
    /// </summary>
    public string Codigo { get; set; } = string.Empty;
    /// <summary>
    /// Descripción del medio de pago
    /// </summary>
    public string? Nombre { get; set; }
}
