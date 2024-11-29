using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IreferencialesRepository
    {
        Task<Ciudad> GetCiudadPorId(int departamentoId);

        Task<Ciudad> InsertCiudad(Ciudad parametros);

        Task<Ciudad> UpdateCiudad(Ciudad parametros);

        Task<IEnumerable<Departamento>> GetDepartamentoPorId();

        Task<Departamento> InsertDepartamento(Departamento parametros);

        Task<IEnumerable<Pais>> GetPais();

        Task<Pais> InsertPais(Pais parametros);
        Task<bool> LoginUsuario(String UsarName, String Password);

        Task<Usuario> GetUsuarios();

        Task<Usuario> InsertUsuario(Usuario parametros);

        Task<Deposito> InsertDeposito(Deposito parametros);

        Task<Deposito> UpdateDeposito(Deposito parametros);

        Task<IEnumerable<Deposito>> GetDepositos();
        Task<Proveedor> InsertarProveedor(Proveedor parametros);
        Task <IEnumerable<Proveedor>> GetProveedor();
        Task <IEnumerable<Categoria>> GetCategoria();
         /// <summary>
        /// Interfaz para la insercion de categorias
        /// </summary>
        /// <returns></returns>
        Task <Categoria> InsertarCategoria( Categoria parametros);

    }
}