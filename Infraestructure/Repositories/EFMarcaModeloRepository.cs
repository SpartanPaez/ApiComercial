using ApiComercial.Infraestructure.Data;
using ApiComercial.Interfaces;
using ApiComercial.Entities;
using Microsoft.EntityFrameworkCore;


namespace ApiComercial.Infraestructure.Repositories
{
    public class MarcaModeloRepository : IMarcaModeloRepository
    {
        private readonly MysqlContext _context;

        public MarcaModeloRepository(MysqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MarcaAuto>> GetMarcas() => await _context.Marcas.ToListAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ModeloAuto>> GetModelos()
        {
            var resultado = await _context.Modelos
         .Join(
             _context.Marcas,
             modelo => modelo.IdMarca,
             marca => marca.IdMarca,
             (modelo, marca) => new ModeloAuto
             {
                 // Asigna las propiedades correctas según tu clase ModeloAuto
                 NombreMarca = marca.DescripcionMarca,
                 DescripcionModelo = modelo.DescripcionModelo
             })
         .ToListAsync();

         return resultado;

        }
        public async Task<MarcaAuto> GetMarcaPorId(int id) => await _context.Marcas.FindAsync(id);
        public async Task<IEnumerable<ModeloAuto>> GetModelosPorMarca(int idMarca)
        {
            return await _context.Modelos
                .Where(m => m.IdMarca == idMarca)
                .ToListAsync();
        }
        public async Task<MarcaAuto> InsertMarca(MarcaAuto marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return marca;
        }
        public async Task<ModeloAuto> InsertModelo(ModeloAuto modelo)
        {
            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
        public async Task<MarcaAuto> UpdateMarca(MarcaAuto marca)
        {
            _context.Marcas.Update(marca);
            await _context.SaveChangesAsync();
            return marca;
        }
        public async Task<ModeloAuto> UpdateModelo(ModeloAuto modelo)
        {
            _context.Modelos.Update(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
        public async Task<bool> DeleteMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return false;
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteModelo(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null) return false;
            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ModeloAuto> GetModeloPorIdMarca(int idMarca)
        {
            return await _context.Modelos
                .FirstOrDefaultAsync(m => m.IdMarca == idMarca);
        }
    }
}
