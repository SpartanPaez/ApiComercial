using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.interfaces.Repositories
{
    public class EFReferencialesRepository : IreferencialesRepository
    {
        private readonly MysqlContext _my;
        private readonly string? _mysqlconnection;
        public EFReferencialesRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
            _mysqlconnection = configuration.GetConnectionString("Default");
        }
        public async Task<Ciudad> GetCiudadPorId(int departamentoId)
         => await _my.Ciudades
            .Where(c => c.DepartamentoId == departamentoId)
            .FirstOrDefaultAsync();

        public async Task<Ciudad> InsertCiudad(Ciudad parametros)
        {
            await _my.Ciudades.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
    }
}