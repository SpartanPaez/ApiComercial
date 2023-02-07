using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IproductosService
    {
        Task <IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoPorId(string codigoBarra);
        Task<Producto> InsertProducto(Producto parametros);
    }
}