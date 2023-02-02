using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IreferencialesRepository
    {
        Task<Ciudad> GetCiudadPorId(int departamentoId);

        Task<Ciudad> InsertCiudad(Ciudad parametros);

        Task<Departamento> GetDepartamentoPorId(int departamento);

        Task<Departamento> InsertDepartamento(Departamento parametros);

        Task<Pais> GetPais ();

        Task<Pais> InsertPais(Pais parametros);
        
        Task<Usuario>GetUsuarios();
        
        Task<Usuario>InsertUsuario(Usuario parametros);
    }
}