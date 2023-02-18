using ApiComercial.Entities;
using ApiComercial.interfaces;
using ApiComercial.Infraestructure.interfaces;

namespace ApiComercial.Services
{
    public class ProductoService : IproductosService
    {
        private readonly IproductoRepository _productoRepository;
        public ProductoService(IproductoRepository iproductoRepository)
        {
            this._productoRepository = iproductoRepository;
        }

        public async Task<bool> DeleteProducto(int ProductoId)
        {
            return await this._productoRepository.DeleteProducto(ProductoId);
        }

        public async Task<bool> ExisteProducto(int ProductoId, string ProductoLote)
        {
            return await this._productoRepository.ExisteProducto(ProductoId, ProductoLote);
        }

        public Task<Producto> GetProductoPorId(string codigoBarra)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await this._productoRepository.GetProductos();
        }

        public async Task<Producto> InsertProducto(Producto parametros)
        {
            return await this._productoRepository.InsertProducto(parametros);
        }

        public async Task<Producto> UpdateProducto(Producto parametros)
        {
            return await _productoRepository.UpdateProducto(parametros);
        }

    }
}