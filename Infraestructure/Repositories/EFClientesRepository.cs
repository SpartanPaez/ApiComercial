using ApiComercial.interfaces;
using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.Repositories;
using ApiComercial.Infraestructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories
{
    public class EFClientesRepository : IclientesRepository
    {
        private readonly MysqlContext _my;
        private readonly string? _mysqlconnection;
        public EFClientesRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
            _mysqlconnection = configuration.GetConnectionString("Default");
        }
        public async Task <IEnumerable<Cliente>> GetDatoCliente()
        =>  await _my.Clientes.ToListAsync();
        public async Task <Cliente> GetClientePorId(int Id)
        => await _my.Clientes
                 .Where(c => c.ClienteId== Id)
                 .FirstOrDefaultAsync();

        public async Task<Cliente> InsertCliente(Cliente parametros)
        {
            await _my.Clientes.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<Cliente> UpdateCliente(Cliente parametros)
        {
            _my.Clientes.Update(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        //delete clientes
        public async Task<bool> DeleteCliente(int ClienteId)
        {
            var cliente = await _my.Clientes.Where(x => x.ClienteId == ClienteId).FirstOrDefaultAsync();
            if (cliente == null)
                return false;
            _my.Clientes.Remove(cliente);
            await _my.SaveChangesAsync();
            return true;
        }
    }
}