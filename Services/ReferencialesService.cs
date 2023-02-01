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

        public async Task<Ciudad> InsertCiudad(Ciudad parametros)
        {
            return await _referenciaRepository.InsertCiudad(parametros);
        }

        public async Task<Departamento> InsertDepartamento(Departamento parametros)
        {
            return await _referenciaRepository.InsertDepartamento(parametros);
        }
    }
}