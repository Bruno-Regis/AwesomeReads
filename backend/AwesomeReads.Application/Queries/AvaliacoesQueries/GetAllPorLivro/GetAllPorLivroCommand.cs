using AwesomeReads.Application.Models;
using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Queries.AvaliacoesQueries.GetAllPorLivro
{
    public class GetAllPorLivroCommand : IRequestHandler<GetAllPorLivroQuery, ResultViewModel<List<AvaliacaoItemViewModel>>>
    {
        private readonly ILivroRepository _livroRepository;

        public GetAllPorLivroCommand(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<ResultViewModel<List<AvaliacaoItemViewModel>>> Handle(GetAllPorLivroQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetDetailsByIdAsync(request.IdLivro);
            if (livro is null)
                return ResultViewModel<List<AvaliacaoItemViewModel>>.Error("Livro não encontrado.");

            var model = livro.Avaliacoes.Select(l => AvaliacaoItemViewModel.FromEntity(l)).ToList();

            return ResultViewModel<List<AvaliacaoItemViewModel>>.Success(model);
        }
    }
}
