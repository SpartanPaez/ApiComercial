public class VehiculoInsert
{
    /// <summary>
    /// Numero de chasis
    /// </summary>
    public string IdChasis { get; set; }= string.Empty;
    /// <summary> 
    /// Codigo de la marca
    /// </summary>
    public int IdMarca { get; set; } 
    /// <summary>
    /// Codigo de modelo
    /// </summary>
    public int IdModelo { get; set; }
    /// <summary>
    /// Tipo de vehiculo
    /// </summary>
    public string TipoCar { get; set; } = string.Empty;
    /// <summary>
    /// Año de fabricacion
    /// </summary>
    public string AnoFabricacion { get; set; } = string.Empty;
    /// <summary>
    /// Color del vehiculo
    /// </summary>
    public string Color { get; set; } = string.Empty;
}
