using ApiComercial.Entities;

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
        /// <param name="parametros">Los parámetros del vehículo a insertar.</param>
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

        // Si necesitas métodos adicionales, puedes agregarlos aquí.
        // Por ejemplo, obtener vehículos por marca, modelo, año, etc.
    }
}