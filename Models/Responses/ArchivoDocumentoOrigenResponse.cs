namespace ApiComercial.Models.Responses;
public class ArchivoDocumentoOrigenResponse
{
    public int Id { get; set; }
    public int DocumentacionOrigenId { get; set; }
    public string? NombreArchivo { get; set; }
    public string? RutaArchivo { get; set; }
    public DateTime FechaSubida { get; set; }
}
