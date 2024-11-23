using ApiComercial.Entities;
using ApiComercial.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComercial.Infraestructure.Interfaces // Asegúrate de que está en este espacio de nombres
{
    public interface IVehiculoRepository
    {
        /// <summary>
        /// Tarea para obtener autos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Vehiculo>> GetVehiculos();
        Task<Vehiculo> GetVehiculoPorId(string idChasis);
        Task<Vehiculo> InsertVehiculo(Vehiculo parametros);
        Task<Vehiculo> UpdateVehiculo(Vehiculo parametros);
        Task<bool> ExisteVehiculo(string idChasis);
        Task<bool> DeleteVehiculo(string idChasis);
        Task<IEnumerable<Vehiculo>> GetVehiculosVencimiento(string fecha);
        /// <summary>
        /// Tarea para mostrar los datos de estados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Estados>> GetEstados();
        /// <summary>
        /// Para insertar datos de estados
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<Estados> InsertarEstados(Estados parametros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        Task<int> GetCountByEstado(string estado);
    }
}
