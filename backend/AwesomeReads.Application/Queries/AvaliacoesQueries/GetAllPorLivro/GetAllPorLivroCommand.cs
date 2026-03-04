using AwesomeReads.Application.Models;
using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Queries.AvaliacoesQueries.GetAllPorLivro
{
    public class GetAllPorLivroCommand : IRequestHandler<GetAllPorLivroQuery, ResultViewModel<List<AvaliacaoItemViewModel>>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public GetAllPorLivroCommand(ILivroRepository livroRepository, IAvaliacaoRepository avaliacaoRepository )
        {
            _livroRepository = livroRepository;
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<ResultViewModel<List<AvaliacaoItemViewModel>>> Handle(GetAllPorLivroQuery request, CancellationToken cancellationToken)
        { 
            var livro = await _livroRepository.GetByIdAsync(request.IdLivro);

            if (livro is null)
                return ResultViewModel<List<AvaliacaoItemViewModel>>.Error("Livro não encontrado.");

            var avaliacoes = await _avaliacaoRepository.GetAllPorLivroAsync(request.IdLivro);
            var model = avaliacoes.Select(a => AvaliacaoItemViewModel.FromEntity(a)).ToList();

            return ResultViewModel<List<AvaliacaoItemViewModel>>.Success(model);
        }
    }
}
