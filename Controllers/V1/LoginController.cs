using System.Linq;
using System.Threading.Tasks;
using back.ViewModels;
using Jogos.Business.Entities;
using Jogos.Business.Repositories;
using Jogos.Configurations;
using Jogos.Filters;
using Jogos.Infraestruture.Data;
using Jogos.Views.UsersViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;


namespace Jogos.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authentication;

        public LoginController(IAuthenticationService authentication, IUserRepository userRepository)
        {
            _authentication = authentication;
            _userRepository = userRepository;
        }


        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter o usuário", Type = typeof(UserViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        [Route("Login")]
        [ValidacaoFilterCustomizado]
        public async Task<IActionResult>Login(LoginViewInput loginViewInput)
        {
            User user = _userRepository.GetUser(loginViewInput.Nome);
            if (user == null)
            {
                return BadRequest("Erro ao tentar acessar");
            }
           // if (user.Senha != loginViewInput.Senha.GenerateHashCode())
           // {
           //     return BadRequest("Erro ao tentar acessar");
           // }
            var userViewOutput = new UserViewOutput()
            {
                Id = user.Id,
                Nome = loginViewInput.Nome,
                Senha = user.Senha
            };
            var token = _authentication.GerarToken(userViewOutput);
            return Ok(new
            {
                Token = token,
                User = UserViewOutput
            });
        }


        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar usuário", Type = typeof(UserViewOutput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        [Route("Cadastrar")]
        [ValidacaoFilterCustomizado]
        public async Task<IActionResult>CadastrarUsuario(UserViewInput userViewInput)
        {
            var options = new DbContextOptionsBuilder<JogoDbContext>();
            options.UseSqlServer("Server=DESKTOP-2DVH51E\\SQLEXPRESS; Database= Jogos; user = sa; password = Deusminhavida!32756");
            JogoDbContext context = new JogoDbContext(options.Options);


            var user = new User();
            user.Nome = userViewInput.Nome;
            user.Email = userViewInput.Email;
            user.Senha = userViewInput.Senha;
            user.IsAdmin = userViewInput.IsAdmin;
            _userRepository.AddUser(user);
            _userRepository.Commit();
            

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
        public async Task<IActionResult>RemoveUser()
        {
            return Ok();
        }

    }
}