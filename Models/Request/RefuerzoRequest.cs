namespace ApiComercial.Models.Request;

public class RefuerzoRequest
{
    public int VentaId { get; set; }
    public decimal MontoRefuerzo { get; set; }
    public DateTime FechaVencimiento { get; set; }
}
