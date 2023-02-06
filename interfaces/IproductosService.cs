using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IproductosService
    {
        Task<Producto> GetProductos();
        Task<Producto> GetProductoPorId(string codigoBarra);

    }
}