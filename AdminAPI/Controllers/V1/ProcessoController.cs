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
    public class ProcessoController : ControllerBase
    {
        private readonly IProcessoService _processoService;
        public ProcessoController(IProcessoService processoservice)
        {
            _processoService = processoservice;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var result = await _processoService.Listar();
                return Ok(result);
            }
            catch (ObjetoNaoLocalizadoException)
            {
                return NoContent();
            }
            catch (ObjetoJaCadastradoException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Obter([FromRoute] int id)
        {
            try
            {
                var partido = await _processoService.Obter(id);
                return Ok(partido);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] ProcessoInputModel dto)
        {
            try
            {
                await _processoService.Criar(dto);
                return Ok();
            }
            catch (ProcessoNaoPermitidoException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (ObjetoJaCadastradoException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar([FromRoute] int id, [FromBody] ProcessoInputModel dto)
        {
            try
            {
                await _processoService.Editar(id, dto);
                return Ok("Processo atualizado");
            }
            catch (ProcessoNaoPermitidoException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover([FromRoute] int id)
        {
            try
            {
                await _processoService.Remover(id);
                return Ok("Processo Removido");
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}