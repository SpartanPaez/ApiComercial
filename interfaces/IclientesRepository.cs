using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IclientesRepository
    {
        Task<Cliente> GetDatoCliente();
        Task<Cliente> GetClientePorId(int Id);
    }
}