using ApiComercial.Entities;
using ApiComercial.interfaces;
using ApiComercial.Infraestructure.interfaces;
using ApiComercial.Entities.Referenciales;
using ApiComercial.Models.Responses.Referenciales;

namespace ApiComercial.Services
{
    public class ReferencialesService : IreferencialesService
    {
        private readonly IreferencialesRepository _referenciaRepository;
        public ReferencialesService(IreferencialesRepository ireferencialesRepository)
        {
            this._referenciaRepository = ireferencialesRepository;
        }
        public async Task <IEnumerable<Ciudad>> GetCiudadPorId(int ciudadId)
        {
            return await _referenciaRepository.GetCiudadPorId(ciudadId);
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentoPorId()
        {
            return await _referenciaRepository.GetDepartamentoPorId();
        }

        public Task<IEnumerable<Deposito>> GetDepositos()
        {
            return _referenciaRepository.GetDepositos();
        }

        public async Task <IEnumerable<Pais>> GetPais()
        {
            return await _referenciaRepository.GetPais();
        }

        public async Task<Usuario> GetUsuarios()
        {
            return await _referenciaRepository.GetUsuarios();
        }

        public async Task<Proveedor> InsertarProveedor(Proveedor parametros)
        {
            return await _referenciaRepository.InsertarProveedor(parametros);
        }

        public async Task<Ciudad> InsertCiudad(Ciudad parametros)
        {
            return await _referenciaRepository.InsertCiudad(parametros);
        }

        public async Task<Departamento> InsertDepartamento(Departamento parametros)
        {
            return await _referenciaRepository.InsertDepartamento(parametros);
        }

        public Task<Deposito> InsertDeposito(Deposito parametros)
        {
            return _referenciaRepository.InsertDeposito(parametros);
        }

        public async Task<Pais> InsertPais(Pais parametros)
        {
            return await _referenciaRepository.InsertPais(parametros);
        }

        public async Task<Usuario> InsertUsuario(Usuario parametros)
        {
            return await _referenciaRepository.InsertUsuario(parametros);
        }

        public async Task<bool> LoginUsuario(string UsarName, string Password)
        {
            return await _referenciaRepository.LoginUsuario(UsarName, Password);
        }

        public async Task<Ciudad> UpdateCiudad(Ciudad parametros)
        {
            return await _referenciaRepository.UpdateCiudad(parametros);
        }

        public Task<Deposito> UpdateDeposito(Deposito parametros)
        {
            return _referenciaRepository.UpdateDeposito(parametros);
        }

        public Task<Proveedor> UpdateProveedor(Proveedor parametros)
        {
            throw new NotImplementedException();
        }
          public Task <IEnumerable<Proveedor>> GetProveedor()
        {
            return _referenciaRepository.GetProveedor();
        }

        public Task<IEnumerable<Categoria>> GetCategoria()
        {
           return _referenciaRepository.GetCategoria();
        }
        /// <summary>
        /// Service para la inserción de categorias
        /// </summary>
        /// <returns></returns>
        public Task<Categoria> InsertarCategoria(Categoria parametros)
        {
           return _referenciaRepository.InsertarCategoria(parametros);
        }
        /// <summary>
        /// Muestra los barrios de los clientes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IEnumerable<Barrio>> GetBarrio(int id)
        {
           return _referenciaRepository.GetBarrio(id);
        }
        /// <summary>
        /// MUetsra lista de barrios
        /// </summary>
        /// <returns></returns>

        public Task<IEnumerable<Barrio>> GetBarrios()
        {
            return _referenciaRepository.GetBarrios();
        }

        /// <summary>
        /// Inserta barrios
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public Task<Barrio> InsertatBarrio(Barrio parametros)
        {
            return _referenciaRepository.InsertatBarrio(parametros);
        }

        public Task<IEnumerable<Ciudad>> GetCiudades()
        {
            return _referenciaRepository.GetCiudades();
        }

        public async Task<Banco> InsertarBanco(Banco parametros)
        {
            return await _referenciaRepository.InsertarBanco(parametros);
        }

        public async Task<IEnumerable<BancoResponse>> GetBancos()
        {
            return await _referenciaRepository.GetBancos();
        }

        public async Task<bool> VerificarBarrio(string nombre, int idCiudad)
        {
            var existe = await _referenciaRepository.VerificarBarrio(nombre, idCiudad);
            if (existe)
                throw new ApiComercial.Exceptions.DuplicateResourceException("Ya existe un barrio con ese nombre en la ciudad indicada.");
            return existe;
        }
    }
}