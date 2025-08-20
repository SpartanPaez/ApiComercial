namespace ApiComercial.Models.Responses;

public class RefuerzoResponse
{
    public int RefuerzoId { get; set; }
    /// <summary>
    /// Id de la cuota a la que se le aplica el refuerzo
    /// </summary>
    public int VentaId { get; set; }
    /// <summary>
    /// Monto del refuerzo
    /// </summary>
    public decimal MontoRefuerzo { get; set; }
    /// <summary>
    /// Fecha de vencimiento del refuerzo
    /// </summary>
    public DateTime FechaVencimiento { get; set; }
}