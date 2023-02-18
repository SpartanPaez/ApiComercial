using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IproductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoPorId(string codigoBarra);
        Task<Producto> InsertProducto(Producto parametros);
        Task<Producto> UpdateProducto(Producto parametros);
        Task<bool> ExisteProducto(int ProductoId, string ProductoLote);

        Task<bool> DeleteProducto(int ProductoId);

    }
}