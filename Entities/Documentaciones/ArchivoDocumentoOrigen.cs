namespace ApiComercial.Entitie.Documentaciones;
public class ArchivoDocumentoOrigen
{
    public int Id { get; set; }
    public int DocumentacionOrigenId { get; set; }
    public string? NombreArchivo { get; set; }
    public string? RutaArchivo { get; set; }
    public DateTime FechaSubida { get; set; }
}
