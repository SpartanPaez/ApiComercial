namespace ApiComercial.Models.Responses;

public class ReportePagoItem
{
    public string Tipo { get; set; } = string.Empty; // Cuota | Refuerzo
    public int VentaId { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public int? CuotaId { get; set; }
    public int? NumeroCuota { get; set; }
    public int? RefuerzoId { get; set; }
    public decimal MontoOriginal { get; set; }
    public decimal MontoPagadoTotal { get; set; }
    public decimal MontoPagadoEnRango { get; set; }
    public decimal SaldoPendiente { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public DateTime? FechaPrimerPago { get; set; }
    public DateTime? FechaUltimoPago { get; set; }
    public string Estado { get; set; } = string.Empty; // PENDIENTE | PARCIAL | PAGADO
    public int? DiasAtrasoAlCancelar { get; set; }
    public int? DiasAnticipoAlCancelar { get; set; }
    public int? DiasVencidosActual { get; set; }
}
