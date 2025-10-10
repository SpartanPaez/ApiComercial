namespace ApiComercial.Models.Request;

public class ReportePagosRequest
{
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public int? ClienteId { get; set; }
    public bool IncluirCuotas { get; set; } = true;
    public bool IncluirRefuerzos { get; set; } = true;
    // null: devolver ambos criterios; "Vencimiento" | "Pago"
    public string? TipoRango { get; set; }
}
