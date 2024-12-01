namespace ApiComercial.Models;
/// <summary>
/// Entidad para la tabla barrios
/// </summary>
public class ResponseBarrio
{
    /// <summary>
    /// codigo del barrio
    /// </summary>
    public int IdBarrio { get; set; }
    /// <summary>
    /// Id del departamento
    /// </summary>
    public int IdCiudad { get; set; }
    /// <summary>
    /// Descripcion de ciiudad
    /// </summary>
    public string? ciudadDescripcion { get; set; }
    /// <summary>
    /// Descripcion del barrio
    /// </summary>
    public string? Descripcion { get; set; }
}