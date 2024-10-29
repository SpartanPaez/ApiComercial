using ApiComercial.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComercial.Infraestructure.Interfaces // Asegúrate de que está en este espacio de nombres
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetVehiculos();
        Task<Vehiculo> GetVehiculoPorId(string idChasis);
        Task<Vehiculo> InsertVehiculo(Vehiculo parametros);
        Task<Vehiculo> UpdateVehiculo(Vehiculo parametros);
        Task<bool> ExisteVehiculo(string idChasis);
        Task<bool> DeleteVehiculo(string idChasis);
        Task<IEnumerable<Vehiculo>> GetVehiculosVencimiento(string fecha);
    }
}
