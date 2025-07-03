namespace Entities.Catalogo;
public class AutoFoto
{
    public int Id { get; set; }
    public string? IdChasis { get; set; } // Relaciona el chasis, pero sin navigation property
    public string? UrlFoto { get; set; }
    public bool EsPrincipal { get; set; }
}
