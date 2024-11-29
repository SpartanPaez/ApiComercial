using ApiComercial.Entities;
namespace ApiComercial.Entities;
/// <summary>
/// Clase para los departamentos del paraguay
/// </summary>

public class Departamento
{
    /// <summary>
    /// Codigo del departamento
    /// </summary>
    /// <value></value>
    public int DepartamentoId { get; set; }
    /// <summary>
    /// Nombre del departamento
    /// </summary>
    /// <value></value>
    public string? DepartamentoDesc  { get; set; }
}