using ApiComercial.Entities;
using ApiComercial.Interfaces;
using ApiComercial.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComercial.Services
{
    public class VehiculosService : IVehiculosService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculosService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculos()
        {
            return await _vehiculoRepository.GetVehiculos();
        }

        public async Task<Vehiculo> GetVehiculoPorId(string idChasis)
        {
            return await _vehiculoRepository.GetVehiculoPorId(idChasis);
        }
        public async Task<Vehiculo> InsertVehiculo(Vehiculo vehiculo)
        {
            return await _vehiculoRepository.InsertVehiculo(vehiculo);
        }


        /// <summary>
        /// Tarea para actualizar vehiculos 
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public async Task<Vehiculo> UpdateVehiculo(Vehiculo vehiculo)
        {
            return await _vehiculoRepository.UpdateVehiculo(vehiculo);
        }

        public async Task<bool> DeleteVehiculo(string idChasis)
        {
            return await _vehiculoRepository.DeleteVehiculo(idChasis);
        }

        // Implementación del método que falta
        public async Task<bool> ExisteVehiculo(string idChasis)
        {
            return await _vehiculoRepository.ExisteVehiculo(idChasis);
        }

        public async Task<IEnumerable<Estados>> GetEstados()
        => await _vehiculoRepository.GetEstados();

        /// <summary>
        /// Insertar datos para estados de vehiculos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Estados> InsertarEstados(Estados parametros)
        => await _vehiculoRepository.InsertarEstados(parametros);

        /// <summary>
        /// Devuele la cantidad de vehiculos en base a un estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> GetCountByEstado(string estado)
        => await _vehiculoRepository.GetCountByEstado(estado);
    }
}
