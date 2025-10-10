namespace ApiComercial.Models.Request.Refuerzos;
public class PagarRefuerzoRequest
{
    public int RefuerzoId { get; set; }
    public int MedioPagoId { get; set; }
    public string? Referencia { get; set; }
    public decimal Monto { get; set; }
    public int IdBanco { get; set; }
}