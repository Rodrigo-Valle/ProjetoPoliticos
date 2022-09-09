using System;
using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using AdminAPI.DTO.ViewModel;
using AdminAPI.Exceptions;
using AdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] UsuarioInputModel usuario)
        {
            await _usuarioService.CadastrarUsuario(usuario);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginInputModel usuario)
        {
            try
            {
                var result = await _usuarioService.Login(usuario);
                return Ok(result);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }

        }

        [HttpPost("LoginExterno")]
        public async Task<ActionResult> LoginExterno([FromBody] LoginInputModel usuario)
        {
            try
            {
                var result = await _usuarioService.Login(usuario);
                Token token = new Token();
                token.JWTToken = result;
                return Ok(token);
            }
            catch (ObjetoNaoLocalizadoException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}