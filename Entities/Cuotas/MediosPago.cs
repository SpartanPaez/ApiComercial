namespace ApiComercial.Entities.Cuotas;

public class MediosPago
{
    /// <summary>
    /// Id del medio de pago
    /// </summary>
    public string MedioPagoId { get; set; } = string.Empty;
    /// <summary>
    /// TC, TD, CHEQUE, EFECTIVO, TRANSFER
    /// </summary>
    public string Codigo { get; set; } = string.Empty;
    /// <summary>
    /// Descripción del medio de pago
    /// </summary>
    public string? Nombre { get; set; }
}
