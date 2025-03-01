public class InsertarVehiculoRequest
{
    /// <summary>
    /// Numero de chasis del auto
    /// </summary>
    public string? IdChasis { get; set; }
    /// <summary>
    /// Codigo de la marca
    /// </summary>
    public int IdMarca { get; set; }
    public int IdModelo { get; set; }
    public string TipoCar { get; set; }
    public int AnoFabricacion { get; set; }
    public string? Color { get; set; }
    public string? Usado { get; set; }
    public string? Chapa { get; set; }
    /// <summary>
    /// INidica el estado del vehiculo, si es usado o no en PY
    /// </summary>
    public string? Estado { get; set; }
    /// <summary>
    /// INidica el precio del vehiculo
    /// </summary>
    public string? Precio { get; set; }
}
