using ApiComercial.Entities;
namespace ApiComercial.Entities;

public class Pais
{
 /// <summary>
 /// Codigo del pais
 /// </summary>
 /// <value></value>
public int PaisId { get; set; }
/// <summary>
/// Descripción del país
/// </summary>
/// <value></value>
public string? PaisDescripcion { get; set; }
/// <summary>
/// Nacionalidad del páis
/// </summary>
/// <value></value>
public string? PaisNacionalidad { get; set; }

}