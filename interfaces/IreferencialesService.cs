using ApiComercial.Entities;
using ApiComercial.Entities.Referenciales;
using ApiComercial.Models.Responses.Referenciales;

namespace ApiComercial.interfaces
{
    /// <summary>
    /// Interfaz
    /// </summary>
    public interface IreferencialesService
    {
        /// <summary>
        /// Task para obtener ciudad en base al departamento
        /// </summary>
        /// <param name="departamentoId"></param>
        /// <returns></returns>
        Task<IEnumerable<Ciudad>> GetCiudadPorId(int departamentoId);

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
        Task<IEnumerable<Categoria>> GetCategoria();
        /// <summary>
        /// Interfaz para la insercion de categorias
        /// </summary>
        /// <returns></returns>
        Task<Categoria> InsertarCategoria(Categoria parametros);

        /// <summary>
        /// Obtiene el barrio relacionado con un identificador 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Barrio>> GetBarrio(int id);


        /// <summary>
        /// Obtiene el barrio relacionado con un identificador 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Barrio>> GetBarrios();
        /// <summary>
        /// Inserta barrios
        /// </summary>
        /// <returns></returns>
        Task<Barrio> InsertatBarrio(Barrio parametros);
        /// <summary>
        /// Tarea para enlistar todaas las ciudades
        /// </summary>
        /// <returns></returns>/
        Task<IEnumerable<Ciudad>> GetCiudades();
        Task<Banco> InsertarBanco(Banco parametros);
        Task<IEnumerable<BancoResponse>> GetBancos();
    }
}