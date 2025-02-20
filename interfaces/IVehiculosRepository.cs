using ApiComercial.Entities;


namespace ApiComercial.Infraestructure.Interfaces
{
    /// <summary>
    /// Esta interfaz define un contrato para el repositorio de vehículos en la capa de infraestructura 
    /// </summary>
    public interface IVehiculoRepository
    {
        /// <summary>
        /// Tarea para obtener autos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Vehiculo>> GetVehiculos();
        /// <summary>
        /// Obtiene un vehículo específico a partir de su ID de chasis.
        /// </summary>
        /// <param name="idChasis"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Devuelte el total de autos
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalVehiculos();

        /// <summary>
        /// Obtiene una lista de todas las ventas con sus detalles.
        /// </summary>
        /// <returns>Una lista de ventas con detalles.</returns>
        Task<IEnumerable<Venta>> GetVentas();

        /// <summary>
        /// Inserta una operacion de venta
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<Venta> InsertVenta(Venta parametros);
        /// <summary>
        /// Tarea de la interfaz para la insercion de cuotas
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<Cuota> InsertarCUota(Cuota parametros);
        /// <summary>
        /// Inserta el detalle de la venta
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task<DetalleVenta> InsertarDetalleVenta(DetalleVenta parametros);
    }
}
