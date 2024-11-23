using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IproductosService
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoPorId(string codigoBarra);
        Task<Producto> InsertProducto(Producto parametros);
        Task<Producto> UpdateProducto(Producto parametros);
        Task<bool> ExisteProducto(int ProductoId, string ProductoLote);
        Task<bool> DeleteProducto(int ProductoId);
        //Necesito la interfaz para GetProductosVencimiento que espera un parametro de fecha
        Task<IEnumerable<Producto>> GetProductosVencimiento(DateTime fecha);

    }
}