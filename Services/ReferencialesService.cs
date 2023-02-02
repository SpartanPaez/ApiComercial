using ApiComercial.Entities;
using ApiComercial.interfaces;
using ApiComercial.Infraestructure.interfaces;

namespace ApiComercial.Services
{
    public class ReferencialesService : IreferencialesService
    {
        private readonly IreferencialesRepository _referenciaRepository;
        public ReferencialesService(IreferencialesRepository ireferencialesRepository)
        {
            this._referenciaRepository = ireferencialesRepository;
        }
        public async Task<Ciudad> GetCiudadPorId(int ciudadId)
        {
            return await _referenciaRepository.GetCiudadPorId(ciudadId);
        }

        public async Task<Departamento> GetDepartamentoPorId(int departamentoId)
        {
            return await _referenciaRepository.GetDepartamentoPorId(departamentoId);
        }

        public async Task<Pais> GetPais()
        {
            return await _referenciaRepository.GetPais();
        }

        public async Task<Usuario> GetUsuarios()
        {
            return await _referenciaRepository.GetUsuarios();
        }

        public async Task<Ciudad> InsertCiudad(Ciudad parametros)
        {
            return await _referenciaRepository.InsertCiudad(parametros);
        }

        public async Task<Departamento> InsertDepartamento(Departamento parametros)
        {
            return await _referenciaRepository.InsertDepartamento(parametros);
        }

        public async Task<Pais> InsertPais(Pais parametros)
        {
            return await _referenciaRepository.InsertPais(parametros);
        }

        public async Task<Usuario> InsertUsuario(Usuario parametros)
        {
            return await _referenciaRepository.InsertUsuario(parametros);
        }
    }
}