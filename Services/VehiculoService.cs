using ApiComercial.Entities;
using ApiComercial.Interfaces;
using ApiComercial.Infraestructure.Interfaces;
using ApiComercial.Entities.Cuotas;

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

        public async Task<int> GetTotalVehiculos()
        => await _vehiculoRepository.GetTotalVehiculos();

        public async Task<IEnumerable<Venta>> GetVentas()
        => await _vehiculoRepository.GetVentas();

        /// <summary>
        /// Inserta la venta como tal
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Venta> InsertVenta(Venta parametros)
        => await _vehiculoRepository.InsertVenta(parametros);
        /// <summary>
        /// Insertar detalle de la venta
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<DetalleVenta> InsertarDetalleVenta(DetalleVenta parametros)
        {
            // Insertar detalle de venta
            var detalleInsertado = await _vehiculoRepository.InsertarDetalleVenta(parametros);

            // Si la inserción fue exitosa, actualizar el vehículo
            if (detalleInsertado.VentaId > 0)
            {
                var vehiculo = new Vehiculo
                {
                    IdChasis = detalleInsertado.IdChasis,
                    Estado = "VENDIDO"
                };

                await UpdateVehiculo(vehiculo);
            }

            return detalleInsertado;
        }

        public async Task<Cuota> InsertarCuota(Cuota parametros)
         => await _vehiculoRepository.InsertarCUota(parametros);

        public async Task<string> UpdateVehiculoEstado(string idChasis, string estado)
        {
            // Verificar si el vehículo existe
            if (await _vehiculoRepository.ExisteVehiculo(idChasis))
            {
                // Actualizar el estado del vehículo
                var vehiculo = new Vehiculo
                {
                    IdChasis = idChasis,
                    Estado = estado
                };
                await _vehiculoRepository.UpdateVehiculo(vehiculo);
                return $"Vehículo con ID {idChasis} actualizado a estado {estado}.";
            }
            else
            {
                return $"Vehículo con ID {idChasis} no encontrado.";
            }
        }
    }
}
