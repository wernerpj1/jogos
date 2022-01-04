
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using back.ViewModels;
using Jogos.Business.Entities;
using Jogos.Business.Repositories;
using Jogos.Infraestruture.Data;
using Jogos.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jogos.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;
        
        public JogoController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }
        /// <summary>
        /// This service allow to get an list of Games.
        /// </summary>
        /// <returns>Return status ok, with An list of the games </returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpGet]
        [Route("Buscar-Jogos")]
        public async Task<IActionResult>Obter()
        {

            var jogos = _jogoRepository.GetAll()
                .Select(s => new JogoViewOutput()
                {
                    Nome = s.Nome,
                    Descricao = s.Descricao,
                    Imagem = s.Image,
                    Price = s.Price,
                    Produtora = s.Produtora,
                    IdUser = s.IdUser

                });
            return Ok(jogos);
        }


        /// <summary>
        /// This service allow to get an list of Games.
        /// </summary>
        /// <returns>Return status ok, with An list of the games </returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpGet]
        [Route("Buscar-Jogos-Excluidos")]
        public async Task<IActionResult> GetExcludes()
        {

            var jogos = _jogoRepository.GetExclude()
                .Select(s => new JogoViewOutput()
                {
                    Nome = s.Nome,
                    Descricao = s.Descricao,
                    Imagem = s.Image,
                    Price = s.Price,
                    Produtora = s.Produtora,
                    IdUser = s.IdUser

                });
            return Ok(jogos);
        }

        /// <summary>
        /// This service allow to get an list of Games by User.
        /// </summary>
        /// <returns>Return status ok, with An list of the games </returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "É necessário estar logado para buscar seus jogos", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpGet]
        [Route("Buscar-Jogos-por-usuario")]
        [Authorize]
        public async Task<IActionResult> ObterPorUsuario()
        {
            var id = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var jogos = _jogoRepository.GetByUser(id)
                .Select(s => new JogoViewOutput()
                { 
                    Nome = s.Nome,
                    Descricao = s.Descricao,
                    Imagem = s.Image,
                    Price = s.Price,
                    Produtora = s.Produtora

                });
            return Ok(jogos);
        }


        /// <summary>
        /// This service allow to register an new game.
        /// </summary>
        /// <param name="jogoViewInput">View model do jogo</param>
        /// <returns>Return status ok, with An list of the games </returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 501, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPost]
        [Route("Cadastrar-Jogo")]
        [Authorize]
        public async Task<IActionResult>Inserir(JogoViewInput jogoViewInput)
        {
            
            var id = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            Jogo jogo = new Jogo();
            jogo.Nome = jogoViewInput.Nome;
            jogo.Produtora = jogoViewInput.Produtora;
            jogo.Descricao = jogoViewInput.Descricao;
            jogo.Image = jogoViewInput.Imagem;
            jogo.IdUser = id;
            jogo.Price = jogoViewInput.Price;
            _jogoRepository.AddGame(jogo);
            _jogoRepository.Commit();
            return Created("", jogoViewInput);
        }

        /// <summary>
        /// This service allow to change all atributes of an game.
        /// </summary>
        /// <param name="jogoViewInput">View model do jogo</param>
        /// <returns>Return status ok, with An list of the games </returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 401, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 501, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpPatch]
        [Route("Mudar-Jogo")]
        [Authorize]
        public async Task<IActionResult>ChangeGame(int id, JogoViewInput jogoViewInput)
        {
            var jogo = _jogoRepository.GetById(id);
            jogo.Nome = jogoViewInput.Nome;
            jogo.Produtora = jogoViewInput.Produtora;
            jogo.Descricao = jogoViewInput.Descricao;
            jogo.Image = jogoViewInput.Imagem;
            jogo.IdUser = jogo.IdUser;
            jogo.Price = jogoViewInput.Price;
            _jogoRepository.UpdateGame(jogo);
            _jogoRepository.Commit();
            return Ok();
        }

        /// <summary>
        /// This service allow to remove an game.
        /// </summary>
        /// <param name="id">View model do jogo</param>
        /// <returns>Return status ok, with An list of the games </returns>
        [SwaggerResponse(statusCode: 203, description: "Sucesso ao obter jogo", Type = typeof(JogoViewOutput))]
        [SwaggerResponse(statusCode: 403, description: "Campos obrigatórios preenchidos incorretamente", Type = typeof(ErrosCamposView))]
        [SwaggerResponse(statusCode: 503, description: "Erro interno", Type = typeof(ErroGenericoView))]
        [HttpDelete]
        [Route("Remover-Jogo")]
        [Authorize]
        public async Task<IActionResult>RemoveGame(int id)
        {
            var jogo = _jogoRepository.GetById(id);
            jogo.IsExclude = true;
            _jogoRepository.UpdateGame(jogo);
            _jogoRepository.Commit();
            return Ok();
        }

    }
}