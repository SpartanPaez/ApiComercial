namespace  ApiComercial.Models.Request;
public class EstadoDocumentoRequest
{
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public int Orden { get; set; }
    public bool EsFinal { get; set; }
}
