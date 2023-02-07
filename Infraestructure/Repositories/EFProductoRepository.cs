using ApiComercial.interfaces;
using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.Repositories;
using ApiComercial.Infraestructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories
{
    public class EFProductoRepository : IproductoRepository
    {
        private readonly MysqlContext _my;
        private readonly string? _mysqlconnection;

        public EFProductoRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
            _mysqlconnection = configuration.GetConnectionString("Default");
        }
        public Task<Producto> GetProductoPorId(string codigoBarra)
        {
            throw new NotImplementedException();
        }

        public async Task <IEnumerable<Producto>> GetProductos()
         => await _my.Productos.ToListAsync();

        public async Task<Producto> InsertProducto(Producto parametros)
        {
           await _my.AddAsync(parametros);
           await _my.SaveChangesAsync();
           return parametros;
        }
    }
}