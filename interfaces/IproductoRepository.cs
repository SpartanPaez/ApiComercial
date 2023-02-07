using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IproductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoPorId(string codigoBarra);
        Task<Producto> InsertProducto(Producto parametros);
    }
}