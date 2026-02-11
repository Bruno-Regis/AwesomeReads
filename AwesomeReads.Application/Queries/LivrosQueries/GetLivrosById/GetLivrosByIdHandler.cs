using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;



namespace AwesomeReads.Application.Queries.LivrosQueries.GetLivrosById
{
    public class GetLivrosByIdHandler : IRequestHandler<GetLivrosByIdQuery, ResultViewModel<LivroViewModel>>
    {
        private readonly ILivroRepository _livroRepository;
        public GetLivrosByIdHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<ResultViewModel<LivroViewModel>> Handle(GetLivrosByIdQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Id);
            if (livro is null)
            {
                return ResultViewModel<LivroViewModel>.Error("Livro não encontrado");
            }

            var model = LivroViewModel.FromEntity(livro);
            return ResultViewModel<LivroViewModel>.Success(model);
        }
    }
}
