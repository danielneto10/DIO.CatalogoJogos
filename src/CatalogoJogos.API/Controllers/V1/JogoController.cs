using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CatalogoJogos.Application.Dtos;
using CatalogoJogos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoJogos.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoService jogoService;

        public JogoController(IJogoService jogoService)
        {
            this.jogoService = jogoService;

        }

        [HttpGet]
        public async Task<IActionResult> ObterPorPagina([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            try
            {
                var jogos = await jogoService.ObterAsync(pagina, quantidade);
                if (jogos is null) return NoContent();

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            try
            {
                var jogo = await jogoService.ObterAsync(id);
                if (jogo is null) return NoContent();

                return Ok(jogo);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");;
            }
        }

        [HttpGet("{produtora}/{nome}")]
        public async Task<IActionResult> ObterPorNomeProdutora([FromRoute] string nome, [FromRoute] string produtora)
        {
            try
            {
                var jogo = await jogoService.ObterAsync(nome, produtora);
                if (jogo is null) return NoContent();

                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddJogo([FromBody] CreateJogoDto model)
        {
            try
            {
                await jogoService.AddJogo(model);
                return Ok(new { message = "Jogo adicionado" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");;
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateJogo([FromRoute] Guid id, [FromBody] UpdateJogoDto model)
        {
            try
            {
                await jogoService.UpdateJogo(id, model);
                return Ok(new { message = "Jogo atualizado" });
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");;
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> RemoveJogo([FromRoute] Guid id)
        {
            try
            {
                await jogoService.RemoveJogo(id);
                return Ok(new { message = "Jogo deletado" });
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");;
            }
        }
    }
}