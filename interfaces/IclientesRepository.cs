using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IclientesRepository
    {
        Task <IEnumerable<Cliente>> GetDatoCliente();
        Task<Cliente> GetClientePorId(int Id);
        Task <Cliente> InsertCliente(Cliente parametros);

    }
}