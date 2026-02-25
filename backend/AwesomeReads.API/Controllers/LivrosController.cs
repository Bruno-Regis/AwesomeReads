using AwesomeReads.Application.Commands.LivrosCommands.DeleteLivros;
using AwesomeReads.Application.Commands.LivrosCommands.InsertLivros;
using AwesomeReads.Application.Queries.LivrosQueries.GetAllLivros;
using AwesomeReads.Application.Queries.LivrosQueries.GetLivrosById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeReads.API.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase  
    {
        private readonly IMediator _mediator;
        public LivrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/livros
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllLivrosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/usuarios/1234
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetLivrosByIdQuery(id); 
            var result = await _mediator.Send(query);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertLivrosCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
        // DELETE api/usuarios/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLivrosCommand(id));
            
            if(!result.IsSuccess) 
                return BadRequest(result.Message);
            
            return NoContent();
        }
    }
}
