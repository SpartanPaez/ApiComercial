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
    }
}
