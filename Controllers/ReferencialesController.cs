using Microsoft.AspNetCore.Mvc;
using ApiComercial.Models;
using AutoMapper;
using ApiComercial.interfaces;
using ApiComercial.Entities;
using ApiComercial.Helpers;
using Microsoft.AspNetCore.Cors;

namespace ApiComercial.Controllers
{
    //[ApiVersion("1.0")]
    [Route("api")]
    public class ReferencialesController : BaseApiController
    {
        private readonly ILogger<ReferencialesController> _Logger;
        private readonly IMapper _mapper;
        private readonly IreferencialesService _service;

        public ReferencialesController(ILogger<ReferencialesController> logger,
                                    IMapper mapper,
                                    IreferencialesService service)
        {
            _Logger = logger;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("ciudades/{Id}")]
        [ProducesResponseType(typeof(CiudadResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCiudadesPorId(int Id)
        {
            try
            {
                var resultado = await _service.GetCiudadPorId(Id);
                var respuesta = Mapper.Map<CiudadResponse>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al obtener los datos de la ciudad por ID");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al obtener los datos de la ciudad por ID"
                });
            }
        }
        /// <summary>
        /// Inserta nuevas ciudades
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>                            
        [HttpPost("ciudades")]
        [ProducesResponseType(typeof(CiudadResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertCiudad(RequestCiudad parametros)
        {
            try
            {
                var request = Mapper.Map<Ciudad>(parametros);
                var resultado = await _service.InsertCiudad(request);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al insertar los registros de la ciudad");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al insertar los registros de la ciudad"
                });
            }

        }
        [HttpPut("ciudades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCiudades(CiudadResponse parametros)
        {
            try
            {
                var resquest = Mapper.Map<Ciudad>(parametros);
                var resultado = await _service.UpdateCiudad(resquest);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al actualizar los registros de la ciudad");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al actualizar los registros de la ciudad"
                });
            }

        }


        [HttpGet("departamentos/{Id}")]
        [ProducesResponseType(typeof(DepartamentoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GeDepartamentoPorId(int Id)
        {
            try
            {
                var resultado = await _service.GetDepartamentoPorId(Id);
                var respuesta = Mapper.Map<DepartamentoResponse>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al consultar el departamento por Id");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al consultar el departamento por Id"
                });
            }
        }

        [HttpPost("departamentos")]
        [ProducesResponseType(typeof(DepartamentoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertDepartamento(RequestDepartamento parametros)
        {
            try
            {
                var resquet = Mapper.Map<Departamento>(parametros);
                var resultado = await _service.InsertDepartamento(resquet);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al momento de intentar insertar los datos del departamento");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al momento de intentar insertar los datos del departamento"
                });
            }

        }

        [HttpGet("paises")]
        [ProducesResponseType(typeof(PaisResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPais()
        {
            try
            {
                var resultado = await _service.GetPais();
                var respuesta = Mapper.Map<IEnumerable<PaisResponse>>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al momento de consultar los datos");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.validacion_negocio,
                    ErrorDescripcion = "Ocurrió un error al momento de consultar los datos"
                });
            }
        }

        [HttpPost("paises")]
        [ProducesResponseType(typeof(PaisResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertPais(RequestPais parametros)
        {
            try
            {
                var resquet = Mapper.Map<Pais>(parametros);
                var resultado = await _service.InsertPais(resquet);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al intentar insertar los datos de paises");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar insertar los datos de paises"
                });
            }
        }

        [HttpGet("usuarios")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetUsuarios()
        {
            try
            {
                var resultado = await _service.GetUsuarios();
                var respuesta = Mapper.Map<UsuarioResponse>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al momento de consultar los datos");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.validacion_negocio,
                    ErrorDescripcion = "Ocurrió un error al momento de consultar los datos"
                });
            }
        }

        [HttpPost("usuarios")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertUsuarios(RequestUsuario parametros)
        {
            try
            {
                var Encrypt = Encryption.Encrypt4(parametros.UsuarioPass, "b14ca5898a4e4133bbce2ea2315a1916");
                parametros.UsuarioPass = Encrypt;
                var resquet = Mapper.Map<Usuario>(parametros);
                var resultado = await _service.InsertUsuario(resquet);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al intentar insertar los datos de paises");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar insertar los datos de paises"
                });
            }
        }

        //controler LoginUsuarios con los parametros UserName y Password
        // [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost("login")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> LoginUsuarios(UserLoginModel request)
        {
            try
            {
                var Descryp = Encryption.Encrypt4(request.Password, "b14ca5898a4e4133bbce2ea2315a1916");
                request.Password = Descryp;
                var resultado = await _service.LoginUsuario(request.UserName, request.Password);
                return Ok(resultado);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al intentar ingresar con los datos de paises");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar ingresar los datos de paises"
                });
            }
        }


        //Crear endpoint para obtener listado de depositos
        [HttpGet("depositos")]
        [ProducesResponseType(typeof(DepositoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetDepositos()
        {
            try
            {
                var resultado = await _service.GetDepositos();
                var respuesta = Mapper.Map<IEnumerable<DepositoResponse>>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al momento de consultar los datos");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.validacion_negocio,
                    ErrorDescripcion = "Ocurrió un error al momento de consultar los datos"
                });
            }
        }
        //insertar depositos
        [HttpPost("depositos")]
        [ProducesResponseType(typeof(DepositoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertDeposito(RequestDeposito parametros)
        {
            try
            {
                var resquet = Mapper.Map<Deposito>(parametros);
                var resultado = await _service.InsertDeposito(resquet);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al intentar insertar los datos de depositos");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar insertar los datos de depositos"
                });
            }
        }
        //update deposito
        [HttpPut("depositos")]
        [ProducesResponseType(typeof(DepositoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDeposito(RequestDeposito parametros)
        {
            try
            {
                var resquet = Mapper.Map<Deposito>(parametros);
                var resultado = await _service.UpdateDeposito(resquet);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al intentar actualizar los datos de depositos");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar actualizar los datos de depositos"
                });
            }
        }

        [HttpPost("proveedor")]
        [ProducesResponseType(typeof(ProveedorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertProveedor(RequestProveedor parametros)
        {
            try
            {
                var resquet = Mapper.Map<Proveedor>(parametros);
                var resultado = await _service.InsertarProveedor(resquet);
                return Ok();
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al intentar insertar los datos de depositos");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar insertar los datos de depositos"
                });
            }
        }

    }
}

public class UserLoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}