using Models.Responses.Catalogo;

namespace ApiComercial.Models.Responses.Catalogo;

public class AutoDetalleViewModel
{
    public string IdChasis { get; set; }
    public int IdMarca { get; set; }
    public string Marca { get; set; }
    public int IdModelo { get; set; }
    public string Modelo { get; set; }
    public string TipoCar { get; set; }
    public int AnoFabricacion { get; set; }
    public string Usado { get; set; }
    public string Chapa { get; set; }
    public string Estado { get; set; }
    public string Precio { get; set; }
    public List<FotoAutoResponse> Fotos { get; set; } = new();
    public List<AutoCaracteristicaResponse> Caracteristicas { get; set; } = new();
    public List<AutoEspecificacionResponse> Especificaciones { get; set; } = new();
    // ...otros campos generales si quieres
}
