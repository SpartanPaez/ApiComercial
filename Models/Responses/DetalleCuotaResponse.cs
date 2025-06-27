namespace ApiComercial.Models.Responses;

public class DetalleCuotaResponse
{
    public int VentaId { get; set; }
    public int IdCuota { get; set; }
    public int NumeroCuota { get; set; }
    public int MontoCuota { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public string? EstadoCodigo { get; set; }
}