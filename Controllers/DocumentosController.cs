using ApiComercial.Models;
using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiComercial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentosController : BaseApiController
{
    private readonly ILogger<DocumentosController> _Logger;
    private readonly IDocumentoService _service;
    private readonly IMapper _mapper;

    public DocumentosController(ILogger<DocumentosController> logger,
                                IDocumentoService service,
                                IMapper mapper)
    {
        _Logger = logger;
        _service = service;
        _mapper = mapper;
    }
    /// <summary>
    /// Obtiene el listado de los tipos de documentos disponibles en el sistema.
    /// </summary>
    /// <returns></returns>
    [HttpGet("estado-documentos")]
    [ProducesResponseType(typeof(EstadoDocumentoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ObtenerDocumentos()
    {
        try
        {
            var resultado = await _service.ObtenerDocumentos();
            var respuesta = _mapper.Map<IEnumerable<EstadoDocumentoResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar los documentos");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de documentos"
            });
        }
    }
    /// <summary>
    /// Inserta un nuevo tipo documento en el sistema.
    /// </summary>
    /// <param name="documento"></param>
    /// <returns></returns>
    [HttpPost("insertar-estado-documento")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertarDocumento([FromBody] EstadoDocumentoRequest documento)
    {
        try
        {
            if (documento == null)
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "El documento no puede ser nulo"
                });
            }

            var resultado = await _service.InsertarDocumento(documento);
            return CreatedAtAction(nameof(ObtenerDocumentos), new { idEstado = documento.Codigo }, resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al insertar el documento");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de inserción del documento"
            });
        }
    }
    /// <summary>
    /// Obtiene la lista de la documentación vehicular de origen.
    /// </summary>
    /// <returns></returns>
    [HttpGet("documentacion-origen")]
    [ProducesResponseType(typeof(DocumentacionOrigenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> ObtenerListadoDocumentacionOrigen()
    {
        try
        {
            var resultado = await _service.ObtenerListadoDocumentacionOrigen();
            var respuesta = _mapper.Map<IEnumerable<DocumentacionOrigenResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar la documentación de origen");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de documentación de origen"
            });
        }
    }
    /// <summary>
    /// Inserta la documentación de origen del vehículo.
    /// </summary>
    /// <param name="documentacionOrigen"></param>
    /// <returns></returns>
    [HttpPost("insertar-documentacion-origen")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertarDocumentacionOrigen([FromBody] DocumentacionOrigenRequest documentacionOrigen)
    {
        try
        {
            if (documentacionOrigen == null)
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "La documentación de origen no puede ser nula"
                });
            }

            var resultado = await _service.InsertarDocumentacionOrigen(documentacionOrigen);
            return CreatedAtAction(nameof(ObtenerListadoDocumentacionOrigen), new { id = resultado }, resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al insertar la documentación de origen");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de inserción de la documentación de origen"
            });
        }
    }

    [HttpPost("subir-archivo-documentacion-origen-base64")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SubirArchivoBase64([FromBody] ArchivoDocumentoOrigenBase64Request request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.ArchivoBase64))
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.validacion_negocio,
                    ErrorDescripcion = "El archivo está vacío o no fue enviado en base64."
                });
            }

            var rutaRelativa = Path.Combine("uploads", "origen", request.DocumentacionOrigenId.ToString());
            var rutaFisica = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", rutaRelativa);

            Directory.CreateDirectory(rutaFisica);

            var rutaCompleta = Path.Combine(rutaFisica, request.NombreArchivo);

            byte[] archivoBytes = Convert.FromBase64String(request.ArchivoBase64);
            await System.IO.File.WriteAllBytesAsync(rutaCompleta, archivoBytes);

            var rutaPublica = Path.Combine("/", rutaRelativa, request.NombreArchivo).Replace("\\", "/");

            var registro = new ArchivoDocumentoOrigenRequest
            {
                DocumentacionOrigenId = request.DocumentacionOrigenId,
                NombreArchivo = request.NombreArchivo,
                RutaArchivo = rutaPublica
            };

            var id = await _service.InsertarArchivoDocumentoOrigen(registro);

            return Ok(id);
        }
        catch (Exception ex)
        {
            _Logger.LogError(ex, "Error al guardar archivo en base64");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error al guardar el archivo"
            });
        }
    }

    [HttpGet("documentos/{documentacionOrigenId}/archivos")]
    [ProducesResponseType(typeof(List<ArchivoDocumentoOrigenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObtenerArchivosPorDocumentacion(int documentacionOrigenId)
    {
        var archivos = await _service.ObtenerArchivosPorDocumentacionId(documentacionOrigenId);

        if (archivos == null || !archivos.Any())
            return NotFound();

        return Ok(archivos);
    }
    /// <summary>
    /// Inserta una nueva escribanía en el sistema.
    /// </summary>
    /// <param name="escribaniaRequest"></param>
    /// <returns></returns>
    [HttpPost("insertar-escribania")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertarEscribania([FromBody] EscribaniaRequest escribaniaRequest)
    {
        try
        {
            if (escribaniaRequest == null)
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "La escribanía no puede ser nula"
                });
            }

            var resultado = await _service.InsertarEscribania(escribaniaRequest);
            return CreatedAtAction(nameof(ObtenerEscribanias), new { id = resultado }, resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al insertar la escribanía");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de inserción de la escribanía"
            });
        }
    }
    /// <summary>
    /// Obtiene el listado de escribanías registradas en el sistema.
    /// </summary>
    /// <returns></returns>
    [HttpGet("escribanias")]
    [ProducesResponseType(typeof(IEnumerable<EscribaniaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ObtenerEscribanias()
    {
        try
        {
            var resultado = await _service.ObtenerEscribanias();
            var respuesta = _mapper.Map<IEnumerable<EscribaniaResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar las escribanías");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de escribanías"
            });
        }
    }

    /// <summary>
    /// Obtiene los archivos asociados a una documentación de post venta.
    /// </summary>
    [HttpGet("documentacion-post-venta/{documentacionPostVentaId}/archivos")]
    [ProducesResponseType(typeof(List<ArchivoPostVentaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObtenerArchivosPorDocumentacionPostVenta(int documentacionPostVentaId)
    {
        var archivos = await _service.ObtenerArchivosPorDocumentacionPostVentaId(documentacionPostVentaId);

        if (archivos == null || !archivos.Any())
            return NotFound();

        return Ok(archivos);
    }
    /// <summary>
    /// Obtiene la lista de la documentación de post venta.
    /// </summary>
    [HttpGet("documentacion-post-venta")]
    [ProducesResponseType(typeof(IEnumerable<DocumentacionPostVentaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObtenerDocumentacionPostVenta()
    {
        try
        {
            var resultado = await _service.ObtenerDocumentacionPostVenta();
            var respuesta = _mapper.Map<IEnumerable<DocumentacionPostVentaResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar la documentación de post venta");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de documentación de post venta"
            });
        }
    }
    /// <summary>
    /// Inserta una nueva documentación de post venta.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("insertar-documentacion-post-venta")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertarDocumentacionPostVenta([FromBody] DocumentacionPostVentaRequest request)
    {
        try
        {
            if (request == null)
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "La documentación de post venta no puede ser nula"
                });
            }

            var resultado = await _service.InsertarDocumentacionPostVenta(request);
            return CreatedAtAction(nameof(ObtenerDocumentacionPostVenta), new { id = resultado }, resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al insertar la documentación de post venta");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de inserción de la documentación de post venta"
            });
        }
    }

    /// <summary>
    /// Inserta un archivo asociado a la documentación de post venta.
    /// </summary>
    [HttpPost("insertar-archivo-documentacion-post-venta")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertarArchivoDocumentoPostVenta([FromBody] ArchivoPostVentaRequest request)
    {
        try
        {
            if (request == null)
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "El archivo de post venta no puede ser nulo"
                });
            }

            // Crear carpeta en disco si no existe
            var rutaRelativa = Path.Combine("uploads", "postventa", request.DocumentacionPostVentaId.ToString());
            var rutaFisica = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", rutaRelativa);
            Directory.CreateDirectory(rutaFisica);

            // Guardar archivo físico
            var rutaCompleta = Path.Combine(rutaFisica, request.NombreArchivo!);
            byte[] archivoBytes = Convert.FromBase64String(request.ArchivoBase64!);
            await System.IO.File.WriteAllBytesAsync(rutaCompleta, archivoBytes);

            // Ruta pública que se guarda en la base de datos
            var rutaPublica = Path.Combine("/", rutaRelativa, request.NombreArchivo!).Replace("\\", "/");
            request.RutaArchivo = rutaPublica;

            var resultado = await _service.InsertarArchivoDocumentoPostVenta(request);
            return CreatedAtAction(nameof(ObtenerDocumentacionPostVenta), new { id = resultado }, resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al insertar el archivo de post venta");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de inserción del archivo de post venta"
            });
        }
    }

}