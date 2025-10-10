namespace ApiComercial.Models.Responses;

public class ReportePagosResponse
{
    public List<ReportePagoItem> Items { get; set; } = new();
    public decimal TotalPagadoEnRango { get; set; }
    public decimal TotalPendiente { get; set; }
    public decimal TotalVenceEnRango { get; set; }
    public decimal TotalVencidoAlDia { get; set; }
}
