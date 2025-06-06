using Google.Protobuf;

namespace ApiComercial.Models.Responses;

public class DetalleCuotaResponse
{
    public int NumeroCuota { get; set; }
    public int MontoCuota { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int Estado { get; set; }
}