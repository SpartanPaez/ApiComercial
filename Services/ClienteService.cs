using ApiComercial.Enums;
using ApiComercial.Entities;
using ApiComercial.interfaces;
using System.Threading.Tasks;
using ApiComercial.Infraestructure.interfaces;

namespace ApiComercial.Services
{
    public class ClienteService : IclientesServices
    {
        private readonly IclientesRepository _clientesRepository;

        public ClienteService(IclientesRepository iclientesRepository)
        {
            this._clientesRepository = iclientesRepository;
        }

        public async Task<Cliente> GetClientePorId(int Id)
        {
            return await _clientesRepository.GetClientePorId(Id);
        }

        public async Task <IEnumerable<Cliente>> GetDatoCliente()
        {
           return await _clientesRepository.GetDatoCliente();
        }

        public async Task<Cliente> InsertCliente(Cliente parametros)
        {
           return await _clientesRepository.InsertCliente(parametros);
        }
    }
}