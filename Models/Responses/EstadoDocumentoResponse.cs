namespace  ApiComercial.Models.Responses;
public class EstadoDocumentoResponse
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public int Orden { get; set; }
    public bool EsFinal { get; set; }
}
