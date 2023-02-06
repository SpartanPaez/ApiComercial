using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IproductoRepository
    {
        Task<Producto> GetProductos();
        Task<Producto> GetProductoPorId(string codigoBarra);

    }
}