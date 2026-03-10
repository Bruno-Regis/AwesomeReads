using AwesomeReads.Application.Models;
using AwesomeReads.Core.Models;
using AwesomeReads.Infrastructure.ExternalServices;
using MediatR;

namespace AwesomeReads.Application.Queries.CatalogoQueries.GetLivroByIsbn
{
    public class GetLivroByIsbnHandler : IRequestHandler<GetLivroByIsbnQuery, ResultViewModel<BookServiceViewModel>>
    {
        private readonly IBookService _bookService;
        public GetLivroByIsbnHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<ResultViewModel<BookServiceViewModel>> Handle(GetLivroByIsbnQuery request, CancellationToken cancellationToken)
        {
            var livro = await _bookService.ConsultBookByIsbnAsync(request.Isbn);
            if (livro is null)
            {
                return ResultViewModel<BookServiceViewModel>.Error("Livro não encontrado");
            }
            return ResultViewModel<BookServiceViewModel>.Success(livro);
        }
    }
}
