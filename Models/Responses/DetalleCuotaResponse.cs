namespace ApiComercial.Models.Responses;

public class DetalleCuotaResponse
{
    public int VentaId { get; set; }
    public int IdCuota { get; set; }
    public int NumeroCuota { get; set; }
    public int MontoCuota { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public string? EstadoCodigo { get; set; }
    public bool EsRefuerzo { get; set; }
    public int? IdRefuerzo { get; set; }  
    public decimal? MontoRefuerzo { get; set; }   
    public DateTime? FechaVencimientoRefuerzo { get; set; }
    // Nuevos campos calculados a partir de la tabla Pagos
    public decimal MontoOriginal { get; set; }  
    public decimal MontoPagado { get; set; } 
    public decimal SaldoPendiente { get; set; }  
    public int? DiasAtraso { get; set; } 
    public int? MontoAtraso { get; set; } 
}