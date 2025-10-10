using Org.BouncyCastle.Utilities.IO.Pem;

namespace ApiComercial.Entities.Cuotas;

public class Refuerzo
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
    /// Monto original del refuerzo (no varía). MontoRefuerzo representa el saldo actual.
    /// </summary>
    public decimal? MontoOriginal { get; set; }
    /// <summary>
    /// Fecha de vencimiento del refuerzo
    /// </summary>
    public DateTime? FechaVencimiento { get; set; }
    public string? Estado { get; set; }
    public int? MedioPagoId { get; set; }
    public string? Referencia { get; set; }
    public int? IdBanco { get; set; }
    public DateTime? FechaPago { get; set; }
}