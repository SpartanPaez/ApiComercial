public class InsertarVehiculoRequest
{
    public string IdChasis { get; set; } = string.Empty;
    public int IdMarca { get; set; }
    public int IdModelo { get; set; }
    public string TipoCar { get; set; } = string.Empty;
    public string AnoFabricacion { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
}
