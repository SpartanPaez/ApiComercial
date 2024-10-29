using ApiComercial.Entities;
using ApiComercial.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComercial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaModeloController : ControllerBase
    {
        private readonly IMarcaModeloService _service;

        public MarcaModeloController(IMarcaModeloService service)
        {
            _service = service;
        }

        // Endpoints para MarcaAuto
        [HttpGet("marcas")]
        public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetMarcas()
        {
            var marcas = await _service.GetMarcas();
            return Ok(marcas);
        }

        [HttpGet("marcas/{id}")]
        public async Task<ActionResult<MarcaAuto>> GetMarcaPorId(int id)
        {
            var marca = await _service.GetMarcaPorId(id);
            if (marca == null)
                return NotFound();
            return Ok(marca);
        }

        [HttpPost("marcas")]
        public async Task<ActionResult<MarcaAuto>> InsertMarca(MarcaAuto marca)
        {
            var nuevaMarca = await _service.InsertMarca(marca);
            return CreatedAtAction(nameof(GetMarcaPorId), new { id = nuevaMarca.IdMarca }, nuevaMarca);
        }

        [HttpPut("marcas/{id}")]
        public async Task<ActionResult> UpdateMarca(int id, MarcaAuto marca)
        {
            if (id != marca.IdMarca)
                return BadRequest();
            
            await _service.UpdateMarca(marca);
            return NoContent();
        }

        [HttpDelete("marcas/{id}")]
        public async Task<ActionResult> DeleteMarca(int id)
        {
            var result = await _service.DeleteMarca(id);
            if (!result)
                return NotFound();
            
            return NoContent();
        }

        // Endpoints para ModeloAuto
        [HttpGet("modelos")]
        public async Task<ActionResult<IEnumerable<ModeloAuto>>> GetModelos()
        {
            var modelos = await _service.GetModelos();
            return Ok(modelos);
        }

        [HttpGet("modelos/{id}")]
        public async Task<ActionResult<ModeloAuto>> GetModeloPorId(int id)
        {
            var modelo = await _service.GetModeloPorId(id);
            if (modelo == null)
                return NotFound();
            return Ok(modelo);
        }

        [HttpPost("modelos")]
        public async Task<ActionResult<ModeloAuto>> InsertModelo(ModeloAuto modelo)
        {
            var nuevoModelo = await _service.InsertModelo(modelo);
            return CreatedAtAction(nameof(GetModeloPorId), new { id = nuevoModelo.IdModelo }, nuevoModelo);
        }

        [HttpPut("modelos/{id}")]
        public async Task<ActionResult> UpdateModelo(int id, ModeloAuto modelo)
        {
            if (id != modelo.IdModelo)
                return BadRequest();
            
            await _service.UpdateModelo(modelo);
            return NoContent();
        }

        [HttpDelete("modelos/{id}")]
        public async Task<ActionResult> DeleteModelo(int id)
        {
            var result = await _service.DeleteModelo(id);
            if (!result)
                return NotFound();
            
            return NoContent();
        }
    }
}
