// IMarcaModeloService.cs
using ApiComercial.Entities;    

namespace ApiComercial.Interfaces
{
    public interface IMarcaModeloService
    {
        Task<IEnumerable<MarcaAuto>> GetMarcas();
        Task<IEnumerable<ModeloAuto>> GetModelos();
        Task<MarcaAuto> GetMarcaPorId(int id);
        Task<ModeloAuto> GetModeloPorId(int id);
        Task<MarcaAuto> InsertMarca(MarcaAuto marca);
        Task<ModeloAuto> InsertModelo(ModeloAuto modelo);
        Task<MarcaAuto> UpdateMarca(MarcaAuto marca);
        Task<ModeloAuto> UpdateModelo(ModeloAuto modelo);
        Task<bool> DeleteMarca(int id);
        Task<bool> DeleteModelo(int id);
    }
}
