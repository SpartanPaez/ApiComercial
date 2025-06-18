namespace ApiComercial.Models.Responses;
public class EscribaniaResponse
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Titular { get; set; }
    public string? Ruc { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? Correo { get; set; }
    public bool Estado { get; set; }
    public DateTime FechaRegistro { get; set; }
}
