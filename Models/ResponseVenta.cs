namespace ApiComercial.Models;
public class ResponseVenta
{
    public int VentaId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public int ClienteId { get; set; } // Identificador del cliente
    public string ClienteNombre { get; set; } // Opcional: Nombre del cliente
    public List<ResponseDetalleVenta> Detalles { get; set; }
}

public class ResponseDetalleVenta
{
    public int DetalleVentaId { get; set; }
    public int VehiculoId { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
}
