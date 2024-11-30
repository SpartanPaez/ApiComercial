namespace ApiComercial.Entities;
/// <summary>
/// Entidad para la tabla barrios
/// </summary>
public class Barrio
{
    /// <summary>
    /// codigo del barrio
    /// </summary>
    public int IdBarrio { get; set; }
    /// <summary>
    /// Id del departamento
    /// </summary>
    public int IdDepartamento { get; set; }
    /// <summary>
    /// Descripcion del barrio
    /// </summary>
    public string? Descripcion { get; set; }
}