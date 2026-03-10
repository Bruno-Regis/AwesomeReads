using AwesomeReads.Application.Queries.CatalogoQueries.GetLivroByIsbn;
using AwesomeReads.Infrastructure.ExternalServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeReads.API.Controllers
{
    [Route("api/Catalogo")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("isbn/{isbn}")]
        public async Task<IActionResult> GetBookByIsbn(string isbn)
        {
            var query = new GetLivroByIsbnQuery(isbn);
            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
