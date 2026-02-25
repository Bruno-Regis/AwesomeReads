using AwesomeReads.Application.Commands.UsersCommands.InsertUser;
using AwesomeReads.Application.Commands.UsuariosCommands.DeleteUsuarios;
using AwesomeReads.Application.Queries.UsersQueries.GetAllUsers;
using AwesomeReads.Application.Queries.UsuariosQueries.GetUsuarioById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeReads.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/usuarios
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsuariosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/usuarios/1234

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUsuarioByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }


        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertUsuariosCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        // DELETE api/usuarios/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUsuariosCommand(id));
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return NoContent();
        }
    }
}
