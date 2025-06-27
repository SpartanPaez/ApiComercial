using System.Runtime.InteropServices;
using ApiComercial.Entities;
using ApiComercial.Entities.Cuotas;

namespace ApiComercial.Interfaces
{
    public interface IVehiculosService
    {
        /// <summary>
        /// Obtiene una lista de todos los vehículos.
        /// </summary>
        /// <returns>Una lista enumerable de vehículos.</returns>
        Task<IEnumerable<Vehiculo>> GetVehiculos();

        /// <summary>
        /// Obtiene un vehículo por su identificador de chasis.
        /// </summary>
        /// <param name="idChasis">El identificador del chasis del vehículo.</param>
        /// <returns>El vehículo correspondiente al idChasis proporcionado.</returns>
        Task<Vehiculo> GetVehiculoPorId(string idChasis);

        /// <summary>
        /// Inserta un nuevo vehículo en la base de datos.
        /// </summary>
        /// <param name="vehiculo">Los parámetros del vehículo a insertar.</param>
        /// <returns>El vehículo insertado con sus datos actualizados.</returns>
        Task<Vehiculo> InsertVehiculo(Vehiculo vehiculo);

        /// <summary>
        /// Actualiza la información de un vehículo existente.
        /// </summary>
        /// <param name="parametros">Los nuevos parámetros del vehículo.</param>
        /// <returns>El vehículo actualizado.</returns>
        Task<Vehiculo> UpdateVehiculo(Vehiculo parametros);

        /// <summary>
        /// Verifica si un vehículo existe en la base de datos.
        /// </summary>
        /// <param name="idChasis">El identificador del chasis del vehículo.</param>
        /// <returns>True si el vehículo existe, false en caso contrario.</returns>
        Task<bool> ExisteVehiculo(string idChasis);

        /// <summary>
        /// Elimina un vehículo de la base de datos.
        /// </summary>
        /// <param name="idChasis">El identificador del chasis del vehículo a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, false en caso contrario.</returns>
        Task<bool> DeleteVehiculo(string idChasis);
        /// <summary>
        /// Obtiene los estados para los vehiculos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Estados>> GetEstados();
        /// <summary>
        /// Insertar estados
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<Estados> InsertarEstados(Estados parametros);

        /// <summary>
        /// Obtiene el conteo de vehículos con un estado específico.
        /// </summary>
        /// <param name="estado">El estado del vehículo.</param>
        /// <returns>El número de vehículos con el estado especificado.</returns>
        Task<int> GetCountByEstado(string estado);
        /// <summary>
        /// Devuelte el total de vehiculos
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalVehiculos();
        /// <summary>
        /// Obtiene una lista de todas las ventas con sus detalles.
        /// </summary>
        /// <returns>Una lista de ventas con detalles.</returns>
        Task<IEnumerable<Venta>> GetVentas();

        /// <summary>
        /// Inserta venta
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<Venta> InsertVenta(Venta parametros);
        /// <summary>
        /// Tarea de la interfaz para la insercion de cuotas
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<Cuota> InsertarCuota(Cuota parametros);
        /// <summary>
        /// Insertar el detalle de la venta
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<DetalleVenta> InsertarDetalleVenta(DetalleVenta parametros);

    }
}
