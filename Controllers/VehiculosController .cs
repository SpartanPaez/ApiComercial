using Microsoft.AspNetCore.Mvc;
using ApiComercial.Models;
using AutoMapper;
using ApiComercial.Interfaces;
using ApiComercial.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using ApiComercial.Entities;

namespace ApiComercial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : BaseApiController
    {
        private readonly ILogger<VehiculosController> _logger;
        private readonly IMapper _mapper;
        private readonly IVehiculosService _service;

        public VehiculosController(ILogger<VehiculosController> logger,
                                   IMapper mapper,
                                   IVehiculosService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Obtener todos los vehículos.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ResponseVehiculo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetVehiculos()
        {
            try
            {
                var resultado = await _service.GetVehiculos();
                var respuesta = _mapper.Map<IEnumerable<ResponseVehiculo>>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar los datos de los vehículos.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos de vehículos."
                });
            }
        }

        /// <summary>
        /// Obtener un vehículo por ID de chasis.
        /// </summary>
        /// <param name="idChasis">Identificador del chasis del vehículo</param>
        /// <returns></returns>
        [HttpGet("{idChasis}")]
        [ProducesResponseType(typeof(ResponseVehiculo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetVehiculoPorId(string idChasis)
        {
            try
            {
                var resultado = await _service.GetVehiculoPorId(idChasis);
                var respuesta = _mapper.Map<ResponseVehiculo>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar el vehículo.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos del vehículo."
                });
            }
        }

        /// <summary>
        /// Insertar un nuevo vehículo.
        /// </summary>
        /// <param name="parametros">Datos del vehículo a insertar</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertVehiculo(InsertarVehiculoRequest parametros)
        {
            try
            {
                var vehiculo = _mapper.Map<Vehiculo>(parametros); // Mapeo del DTO a la entidad

                var resultado = await _service.InsertVehiculo(vehiculo); // Inserción en la base de datos

                return CreatedAtAction(nameof(GetVehiculoPorId), new { idChasis = resultado.IdChasis }, resultado); // Respuesta
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar el vehículo.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos del vehículo: " + e.Message
                });
            }


        }
        /// <summary>
        /// Actualizar los datos de un vehículo.
        /// </summary>
        /// <param name="idChasis">Identificador del chasis del vehículo</param>
        /// <param name="parametros">Datos del vehículo a actualizar</param>
        /// <returns></returns>
        [HttpPut("{idChasis}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateVehiculo(string idChasis, RequestVehiculo parametros)
        {
            var request = _mapper.Map<Vehiculo>(parametros);
            request.IdChasis = idChasis;
            var resultado = await _service.UpdateVehiculo(request);
            return Ok(resultado);
        }

        /// <summary>
        /// Eliminar un vehículo por ID de chasis.
        /// </summary>
        /// <param name="idChasis">Identificador del chasis del vehículo a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{idChasis}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteVehiculo(string idChasis)
        {
            var resultado = await _service.DeleteVehiculo(idChasis);
            return Ok(resultado);
        }

        /// <summary>
        /// Endpoint alternativo para eliminar vehículos.
        /// </summary>
        /// <param name="idChasis">Identificador del chasis del vehículo a eliminar</param>
        /// <returns></returns>
        [HttpDelete("eliminar/{idChasis}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteVehiculoAlternativo(string idChasis)
        {
            var resultado = await _service.DeleteVehiculo(idChasis);
            return Ok(resultado);
        }
        /// <summary>
        /// Endopoint para consultar estados de vehiculos
        /// </summary>
        /// <returns></returns>
        [HttpGet("estados")]
        [ProducesResponseType(typeof(List<EstadosResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetEstados()
        {
            try
            {
                var resultado = await _service.GetEstados();
                var respuesta = _mapper.Map<List<EstadosResponse>>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar los esstados.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta de estados."
                });
            }
        }
        /// <summary>
        /// Endpoint encargado de insertar los estados para los vehiculos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [HttpPost("estados")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertEstados([FromBody] EstadosRequest parametros)
        {
            try
            {
                var estado = _mapper.Map<Estados>(parametros);

                var resultado = await _service.InsertarEstados(estado);

                return CreatedAtAction(nameof(GetEstados), new { id = estado.Id }, resultado);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar el vehículo.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos del vehículo: " + e.Message
                });
            }


        }

        /// <summary>
        /// Endpoint para obtener el conteo de vehículos por estado.
        /// </summary>
        /// <param name="estado">El estado de los vehículos.</param>
        /// <returns>El número de vehículos que tienen el estado especificado.</returns>
        [HttpGet("/estado/{estado}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCountByEstado(string estado)
        {
            try
            {
                var count = await _service.GetCountByEstado(estado.Trim());
                return Ok(count);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar el conteo de vehículos por estado.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta del conteo de vehículos por estado."
                });
            }
        }
        /// <summary>
        /// Devuelte el total de vehiculos, excluyendo los vendidos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("total-vehiculos")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTotalVehiculos()
        {
            try
            {
                // Llamar al servicio para obtener el total de vehículos excluyendo los vendidos
                var totalVehiculosExcluyendoVendidos = await _service.GetTotalVehiculos();

                // Retornar el total de vehículos excluyendo los vendidos
                return Ok(new { TotalVehiculos = totalVehiculosExcluyendoVendidos });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar el total de vehículos.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta de vehículos."
                });
            }
        }


    }
}
