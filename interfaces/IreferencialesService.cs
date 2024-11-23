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

        Task<IEnumerable<Pais>> GetPais();

        Task<Pais> InsertPais(Pais parametros);

        Task<bool> LoginUsuario(String UsarName, String Password);

        Task<Usuario> GetUsuarios();

        Task<Usuario> InsertUsuario(Usuario parametros);

        Task<Deposito> InsertDeposito(Deposito parametros);

        Task<Deposito> UpdateDeposito(Deposito parametros);

        //Obtener listado de depositos
        Task<IEnumerable<Deposito>> GetDepositos();

        Task<Proveedor> InsertarProveedor(Proveedor parametros);

        Task<Proveedor> UpdateProveedor(Proveedor parametros);
        /// <summary>
        /// Obtiene listado de proveedoress
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Proveedor>> GetProveedor();

        /// <summary>
        /// Obtiene listado de categorias
        /// </summary>
        /// <returns></returns>
        Task <IEnumerable<Categoria>> GetCategoria();
        /// <summary>
        /// Interfaz para la insercion de categorias
        /// </summary>
        /// <returns></returns>
        Task <Categoria> InsertarCategoria(Categoria parametros);

    }
}