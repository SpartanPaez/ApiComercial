// MarcaModeloService.cs
using ApiComercial.Entities;
using ApiComercial.Interfaces;

namespace ApiComercial.Services
{
    public class MarcaModeloService : IMarcaModeloService
    {
        private readonly IMarcaModeloRepository _repository;

        public MarcaModeloService(IMarcaModeloRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<MarcaAuto>> GetMarcas() => _repository.GetMarcas();
        public Task<IEnumerable<ModeloAuto>> GetModelos() => _repository.GetModelos();
        public Task<MarcaAuto> GetMarcaPorId(int id) => _repository.GetMarcaPorId(id);
        public Task <IEnumerable<ModeloAuto>> GetModeloPorId(int id) => _repository.GetModeloPorIdMarca(id);
        public Task<MarcaAuto> InsertMarca(MarcaAuto marca) => _repository.InsertMarca(marca);
        public Task<ModeloAuto> InsertModelo(ModeloAuto modelo) => _repository.InsertModelo(modelo);
        public Task<MarcaAuto> UpdateMarca(MarcaAuto marca) => _repository.UpdateMarca(marca);
        public Task<ModeloAuto> UpdateModelo(ModeloAuto modelo) => _repository.UpdateModelo(modelo);
        public Task<bool> DeleteMarca(int id) => _repository.DeleteMarca(id);
        public Task<bool> DeleteModelo(int id) => _repository.DeleteModelo(id);
    }
}
