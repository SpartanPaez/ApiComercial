namespace ApiComercial.Models;
/// <summary>
/// Guarda los estados para vehiculos
/// </summary>
public class EstadosRequest
{
  /// <summary>
  /// Descripcion del estado del vehiculo
  /// </summary>
    public string Descripcion { get; set; } = string.Empty;
}