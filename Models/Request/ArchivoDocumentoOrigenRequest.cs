namespace  ApiComercial.Models.Request;
public class ArchivoDocumentoOrigenRequest
{
    public int DocumentacionOrigenId { get; set; }
    public string? NombreArchivo { get; set; }
    public string? RutaArchivo { get; set; }
}
