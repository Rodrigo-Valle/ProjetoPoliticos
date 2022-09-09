using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using AdminAPI.Exceptions;
using AdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValidaCpf;

namespace AdminAPI.Controllers.V1
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PoliticoController : ControllerBase
    {
        private readonly IPoliticoService _politicoService;

        public PoliticoController(IPoliticoService politicoService)
        {
            _politicoService = politicoService;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var result = await _politicoService.Listar();
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
                var result = await _politicoService.Obter(id);
                return Ok(result);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] PoliticoInputModel dto)
        {
            try
            {
                if (ValidaCpfExtension.Validate(dto.CPF))
                {
                    await _politicoService.Criar(dto);
                    return Ok();
                }
                else
                {
                    return BadRequest("CPF invalido");
                }

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
        public async Task<ActionResult> Editar([FromRoute] int id, [FromBody] PoliticoInputModel dto)
        {
            try
            {
                await _politicoService.Editar(id, dto);
                return Ok("Politico atualizado");
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
                await _politicoService.Remover(id);
                return Ok("Politico Removido");
            }
            catch (PoliticoComProjetosOuProcessoExcpetion e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id}/lider")]
        public async Task<ActionResult> AlterarLideranca([FromRoute] int id)
        {
            try
            {
                await _politicoService.AlterarLideranca(id);
                return Ok("Comando efetuado com sucesso");
            }
            catch (LiderancaException e)
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