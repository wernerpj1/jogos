
using System;
using System.Threading.Tasks;
using back.ViewModels;
using Jogos.Views;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jogos.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class JogoController : ControllerBase
    {

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpGet]
        public async Task<IActionResult>Obter()
        {
            return Ok();
        }


        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 501, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        public async Task<IActionResult>Inserir()
        {
            return Ok();
        } 


        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 501, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPut]
        public async Task<IActionResult>ChangePrice()
        {
            return Ok();
        }                            


        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 501, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPatch]
        public async Task<IActionResult>ChangeGame()
        {
            return Ok();
        }


        [SwaggerResponse(statusCode: 203, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 403, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 503, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpDelete]
        public async Task<IActionResult>RemoveGame()
        {
            return Ok();
        }

    }
}