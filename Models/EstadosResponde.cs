namespace ApiComercial.Models;

/// <summary>
/// Muestra los datos de estados
/// </summary>
public class EstadosResponse
{
    /// <summary>
    /// Id del estado
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Descripcion del estado
    /// </summary>
    public string Descripcion { get; set; } = string.Empty;
}