using ApiComercial.Entities;
namespace ApiComercial.Entities;

public class Ciudad
{
    /// <summary>
    /// Codigo de la ciudad
    /// </summary>
    /// <value></value>
    public int CiudadId { get; set; }
    /// <summary>
    /// Codigo del de departamento asociado
    /// </summary>
    /// <value></value>
    public int DepartamentoId { get ; set; }
    /// <summary>
    /// Nombde de la ciudad
    /// </summary>
    /// <value></value>
    public string? CiudadDesc { get; set; }

}