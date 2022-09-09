using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using AdminAPI.Exceptions;
using AdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.Controllers.V1
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PartidoController : ControllerBase
    {
        private readonly IPartidoService _partidoService;

        public PartidoController(IPartidoService partidoService)
        {
            _partidoService = partidoService;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var result = await _partidoService.Listar();
                return Ok(result);
            }
            catch (ObjetoNaoLocalizadoException)
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Obter([FromRoute] int id)
        {
            try
            {
                var partido = await _partidoService.Obter(id);
                return Ok(partido);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] PartidoInputModel dto)
        {
            try
            {
                await _partidoService.Criar(dto);
                return Ok();
            }
            catch (ObjetoJaCadastradoException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar([FromRoute] int id, [FromBody] PartidoInputModel dto)
        {
            try
            {
                await _partidoService.Editar(id, dto);
                return Ok("Partido atualizado");
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover([FromRoute] int id)
        {
            try
            {
                await _partidoService.Remover(id);
                return Ok("Partido Removido");
            }
            catch (PoliticoComProjetosOuProcessoExcpetion e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}