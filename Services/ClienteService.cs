using ApiComercial.Entities;
using ApiComercial.interfaces;
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

        public async Task<IEnumerable<Cliente>> GetDatoCliente()
        {
            return await _clientesRepository.GetDatoCliente();
        }

        public async Task<Cliente> InsertCliente(Cliente parametros)
        {
            return await _clientesRepository.InsertCliente(parametros);
        }

        public async Task<Cliente> UpdateCliente(Cliente parametros)
        {
            return await _clientesRepository.UpdateCliente(parametros);
        }

        public async Task<bool> DeleteCliente(int ClienteId)
        {
            return await _clientesRepository.DeleteCliente(ClienteId);
        }
    }
}