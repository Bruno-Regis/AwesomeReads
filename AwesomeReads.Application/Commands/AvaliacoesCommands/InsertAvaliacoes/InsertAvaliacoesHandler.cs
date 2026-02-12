using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Commands.AvaliacoesCommands.InsertAvaliacoes
{
    public class InsertAvaliacoesHandler : IRequestHandler<InsertAvaliacoesCommand, ResultViewModel<int>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public InsertAvaliacoesHandler(IUsuarioRepository usuarioRepository, ILivroRepository livroRepository, IAvaliacaoRepository avaliacaoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _livroRepository = livroRepository;
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertAvaliacoesCommand request, CancellationToken cancellationToken)
        {
            var usuarioExists = await _usuarioRepository.ExistsAsync(request.IdUsuario);
            if (!usuarioExists)
                return ResultViewModel<int>.Error("Usuário não encontrado.");

            //var livroExists = await _livroRepository.ExistsAsync(request.IdLivro);
            //if (!livroExists)
            //    return ResultViewModel<int>.Error("Livro não encontrado.");
            var livro = await _livroRepository.GetDetailsByIdAsync(request.IdLivro);
            if (livro is null)
                return ResultViewModel<int>.Error("Livro não encontrado.");

            var avaliacao = request.ToEntity();

            livro.AdicionarAvaliacao(avaliacao);
            //await _avaliacaoRepository.AddAsync(avaliacao);
            await _livroRepository.UpdateAsync(livro);

            return ResultViewModel<int>.Success(avaliacao.Id);
        }
    }
}
