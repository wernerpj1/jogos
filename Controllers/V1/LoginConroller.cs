using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.ViewModels;
using Jogos.Views.UsersViews;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jogos.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class LoginConroller : ControllerBase
    {
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter o usuário", Type = typeof(UserViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        public async Task<IActionResult>Login(LoginViewInput loginViewInput)
        {
            return Created("", loginViewInput);
        }


        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar usuário", Type = typeof(UserViewOutput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        public async Task<IActionResult>CadastrarUsuario(UserViewInput userViewInput)
        {
            return Created("", userViewInput);
        } 


        [SwaggerResponse(statusCode: 202, description: "Sucesso ao trocar a senha", Type = typeof(UserViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 501, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPut]
        public async Task<IActionResult>ChangePassword()
        {
            return Ok();
        }                            


        [SwaggerResponse(statusCode: 202, description: "Sucesso ao alterar usuário", Type = typeof(UserViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 501, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPatch]
        public async Task<IActionResult>ChangeUser()
        {
            return Ok();
        }


        [SwaggerResponse(statusCode: 203, description: "Sucesso remover o usuário", Type = typeof(UserViewOutput))]
        [SwaggerResponse(statusCode: 403, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 503, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpDelete]
        public async Task<IActionResult>RemoveGame()
        {
            return Ok();
        }

    }
}