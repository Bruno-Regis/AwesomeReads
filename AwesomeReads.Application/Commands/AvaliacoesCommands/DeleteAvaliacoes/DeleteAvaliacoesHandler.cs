using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Commands.AvaliacoesCommands.DeleteAvaliacoes
{
    public class DeleteAvaliacoesHandler : IRequestHandler<DeleteAvaliacoesCommand, ResultViewModel>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly ILivroRepository _livroRepository;

        public DeleteAvaliacoesHandler(IAvaliacaoRepository avaliacaoRepository, ILivroRepository livroRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _livroRepository = livroRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteAvaliacoesCommand request, CancellationToken cancellationToken)
        {
            var avaliacao = await _avaliacaoRepository.GetDetailsByIdAsync(request.Id);
            if (avaliacao is null)
                return ResultViewModel.Error("Avaliação não encontrada.");
            
            avaliacao.SetAsDeleted();
            await _avaliacaoRepository.UpdateAsync(avaliacao);

            var livro = await _livroRepository.GetDetailsByIdAsync(avaliacao.IdLivro);
            if (livro is null)
                return ResultViewModel.Error("Livro associado à avaliação não encontrado.");

            livro.AtualizarNotaMedia();
            await _livroRepository.UpdateAsync(livro);

            return ResultViewModel.Success();
        }
    }
}
 