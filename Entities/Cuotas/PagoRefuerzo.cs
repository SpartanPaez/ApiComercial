namespace ApiComercial.Entities.Cuotas;

public class PagoRefuerzo
{
    public int PagoRefuerzoId { get; set; }
    public int RefuerzoId { get; set; }
    public DateTime FechaPago { get; set; }
    public decimal Monto { get; set; }
    public int? MedioPagoId { get; set; }
    public int? IdBanco { get; set; }
    public string? Referencia { get; set; }
}
