using System;
using System.Threading.Tasks;
using AdminAPI.Exceptions;
using AdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RequisicaoController : ControllerBase
    {
        private readonly IRequisicaoService _requisicaoService;

        public RequisicaoController(IRequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var result = await _requisicaoService.Listar();
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
                var result = await _requisicaoService.Obter(id);
                return Ok(result);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{cargo}/asc")]
        public async Task<ActionResult> ListarPorCargoAsc([FromRoute] string cargo)
        {
            try
            {
                var result = await _requisicaoService.ListarPorCargoAsc(cargo);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Entre com um cargo valido");
            }
            catch (ObjetoNaoLocalizadoException)
            {
                return NoContent();
            }
        }

        [HttpGet("{cargo}/desc")]
        public async Task<ActionResult> ListarPorCargoDesc([FromRoute] string cargo)
        {
            try
            {
                var result = await _requisicaoService.ListarPorCargoDesc(cargo);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Entre com um cargo valido");
            }
            catch (ObjetoNaoLocalizadoException)
            {
                return NoContent();
            }
        }

        [HttpGet("leis")]
        public async Task<ActionResult> ListarPorQtdProjetos()
        {
            try
            {
                var result = await _requisicaoService.ListarPorQtdDeProjetos();
                return Ok(result);
            }
            catch (ObjetoNaoLocalizadoException)
            {
                return NoContent();
            }
        }

        [HttpGet("leis/{numero}")]
        public async Task<ActionResult> BuscarPorQtdProjetos([FromRoute] int numero)
        {
            try
            {
                var result = await _requisicaoService.FiltrarPorQtdDeProjetos(numero);
                return Ok(result);
            }
            catch (ObjetoNaoLocalizadoException)
            {
                return NoContent();
            }
        }
    }
}