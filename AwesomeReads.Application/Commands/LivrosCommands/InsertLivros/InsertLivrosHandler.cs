using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using AwesomeReads.Infrastructure.Persistence.Repositories;
using Azure.Core;
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
            var livroJaExiste = await _livroRepository.ExistsISBNAsync(request.ISBN);
            if (livroJaExiste) 
                return ResultViewModel<int>.Error("Já existe um livro com este ISBN.");
            

            var livro = request.ToEntity();

            await _livroRepository.AddAsync(livro);            

            return ResultViewModel<int>.Success(livro.Id);
        }
    }
}


//var usuarioJaExiste = await _usuarioRepository.ExistsEmailAsync(request.Email);

//if (usuarioJaExiste)
//    return ResultViewModel<int>.Error("Já existe um usuário com este e-mail.");