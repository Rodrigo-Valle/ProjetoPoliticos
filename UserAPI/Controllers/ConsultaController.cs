using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserApi.DTO;
using UserAPI.DTO;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        static string JwtToken = "";

        HttpClient cliente = new HttpClient();

        public ConsultaController()
        {
            cliente.BaseAddress = new Uri("https://localhost:5002/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            cliente.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", JwtToken);
        }

        [HttpGet]
        public async Task<ActionResult> ListarPoliticos()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/v1/requisicao");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<PoliticoViewModel>>(dados);
                return Ok(lista);
            }
            return NotFound(response.StatusCode);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPolitico([FromRoute] int id)
        {
            var rota = "api/v1/requisicao/" + id.ToString();
            HttpResponseMessage response = await cliente.GetAsync(rota);
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var politico = JsonConvert.DeserializeObject<PoliticoViewModel>(dados);
                return Ok(politico);
            }
            else
            {
                var dados = response.Content.ReadAsStringAsync();
                return NotFound(dados.Result);
            }
        }

        [HttpGet("{cargo}/asc")]
        public async Task<ActionResult> ListarPoliticosPorCargoAsc([FromRoute] string cargo)
        {
            var rota = "api/v1/requisicao/" + cargo + "/asc";
            HttpResponseMessage response = await cliente.GetAsync(rota);
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var politico = JsonConvert.DeserializeObject<List<PoliticoViewModel>>(dados);
                return Ok(politico);
            }
            else
            {
                var dados = response.Content.ReadAsStringAsync();
                return NotFound(dados.Result);
            }
        }

        [HttpGet("{cargo}/desc")]
        public async Task<ActionResult> ListarPoliticosPorCargoDesc([FromRoute] string cargo)
        {
            var rota = "api/v1/requisicao/" + cargo + "/desc";
            HttpResponseMessage response = await cliente.GetAsync(rota);
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var politico = JsonConvert.DeserializeObject<List<PoliticoViewModel>>(dados);
                return Ok(politico);
            }
            else
            {
                var dados = response.Content.ReadAsStringAsync();
                return NotFound(dados.Result);
            }
        }

        [HttpGet("Projetos")]
        public async Task<ActionResult> ListarPoliticosPorProjetos()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/v1/requisicao/leis");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var politico = JsonConvert.DeserializeObject<List<PoliticoProjetosViewModel>>(dados);
                return Ok(politico);
            }
            else
            {
                var dados = response.Content.ReadAsStringAsync();
                return NotFound(dados.Result);
            }
        }

        [HttpGet("Projetos/{numero}")]
        public async Task<ActionResult> ListarPoliticosPorProjetos(int numero)
        {
            var rota = "api/v1/requisicao/leis/" + numero.ToString();
            HttpResponseMessage response = await cliente.GetAsync(rota);
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var politico = JsonConvert.DeserializeObject<List<PoliticoProjetosViewModel>>(dados);
                return Ok(politico);
            }
            else
            {
                var dados = response.Content.ReadAsStringAsync();
                return NotFound(dados.Result);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginInputModel login)
        {
            string json = JsonConvert.SerializeObject(login);

            var rota = "api/v1/usuarios/loginexterno";
            HttpResponseMessage response = await cliente.PostAsync(rota, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var JWT = JsonConvert.DeserializeObject<Token>(dados);
                JwtToken = JWT.JWTToken;
                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("bearer", JwtToken);
                return Ok(JwtToken);
            }

            else
            {
                var dados = response.Content.ReadAsStringAsync();
                return NotFound(dados.Result);
            }
        }
    }
}