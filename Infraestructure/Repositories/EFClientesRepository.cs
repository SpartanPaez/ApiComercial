using ApiComercial.interfaces;
using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.Repositories;
using ApiComercial.Infraestructure.interfaces;

namespace ApiComercial.Infraestructure.Repositories
{
    public class EFClientesRepository : IclientesRepository
    {
        private readonly MysqlContext _my;

        public EFClientesRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
        }
        public Task<DatoCliente> GetDatoCliente()
        {
            throw new NotImplementedException();
        }
    }
}