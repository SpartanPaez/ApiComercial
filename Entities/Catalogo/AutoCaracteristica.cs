namespace Entities.Catalogo;
public class AutoCaracteristica
{
    public int Id { get; set; }
    public string? IdChasis { get; set; } // Relaciona el chasis, pero sin navigation property
    public string? Caracteristica { get; set; }
}