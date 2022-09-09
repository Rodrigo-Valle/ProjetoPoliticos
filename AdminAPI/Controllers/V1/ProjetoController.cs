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
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var result = await _projetoService.Listar();
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
                var projeto = await _projetoService.Obter(id);
                return Ok(projeto);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] ProjetoInputModel dto)
        {
            try
            {
                await _projetoService.Criar(dto);
                return Ok();
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
        public async Task<ActionResult> Editar([FromRoute] int id, [FromBody] ProjetoInputModel dto)
        {
            try
            {
                await _projetoService.Editar(id, dto);
                return Ok("Projeto atualizado");
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
                await _projetoService.Remover(id);
                return Ok("Projeto Removido");
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}