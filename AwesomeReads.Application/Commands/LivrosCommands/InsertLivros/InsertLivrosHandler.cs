using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Commands.LivrosCommands.InsertLivros
{
    public class InsertLivrosHandler : IRequestHandler<InsertLivrosCommand, ResultViewModel<int>>
    {
        private readonly ILivroRepository _livroRepository;
        public InsertLivrosHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertLivrosCommand request, CancellationToken cancellationToken)
        {
            var livro = request.ToEntity();

            await _livroRepository.AddAsync(livro);            

            return ResultViewModel<int>.Success(livro.Id);
        }
    }
}
