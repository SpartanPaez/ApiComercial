using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IreferencialesService
    {
        Task<Ciudad> GetCiudadPorId(int ciudadId);

        Task<Ciudad> InsertCiudad(Ciudad parametros);

        Task<Ciudad> UpdateCiudad(Ciudad parametros);

        Task<Departamento> GetDepartamentoPorId(int departamento);

        Task<Departamento> InsertDepartamento(Departamento parametros);
        
        Task <IEnumerable<Pais>> GetPais();

        Task<Pais> InsertPais(Pais parametros);

        Task<Usuario>GetUsuarios();
        
        Task<Usuario>InsertUsuario(Usuario parametros);

        Task<Deposito>InsertDeposito(Deposito parametros);

        Task<Deposito>UpdateDeposito(Deposito parametros);

        //Obtener listado de depositos
        Task<IEnumerable<Deposito>> GetDepositos();

        //CREAR CLASE CCCCMA
        
    }
}