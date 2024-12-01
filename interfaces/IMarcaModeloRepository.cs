using ApiComercial.Entities;

namespace ApiComercial.Interfaces
{
    public interface IMarcaModeloRepository
    {
        Task<IEnumerable<MarcaAuto>> GetMarcas();
        Task<IEnumerable<ModeloAuto>> GetModelos();
        Task<MarcaAuto> GetMarcaPorId(int id);
        Task <                                                              IEnumerable<ModeloAuto>> GetModeloPorIdMarca(int idMarca);
        Task<MarcaAuto> InsertMarca(MarcaAuto marca);
        Task<ModeloAuto> InsertModelo(ModeloAuto modelo);
        Task<MarcaAuto> UpdateMarca(MarcaAuto marca);
        Task<ModeloAuto> UpdateModelo(ModeloAuto modelo);
        Task<bool> DeleteMarca(int id);
        Task<bool> DeleteModelo(int id);
    }
}
