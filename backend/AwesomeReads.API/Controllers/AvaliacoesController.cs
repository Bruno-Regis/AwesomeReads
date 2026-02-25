using AwesomeReads.Application.Commands.AvaliacoesCommands.DeleteAvaliacoes;
using AwesomeReads.Application.Commands.AvaliacoesCommands.InsertAvaliacoes;
using AwesomeReads.Application.Queries.AvaliacoesQueries.GetAllPorLivro;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeReads.API.Controllers
{
    [Route("api/avaliacoes")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AvaliacoesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/avaliacoes/livro/1234
        [HttpGet("livro/{idLivro}")]
        public async Task<IActionResult> GetAllPorLivro(int idLivro)
        {
            var query = new GetAllPorLivroQuery(idLivro);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        // POST api/avaliacoes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertAvaliacoesCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { id = result.Data, message = "Avaliação criada com sucesso" });

        }

        // DELETE api/avaliacoes/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAvaliacoesCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
