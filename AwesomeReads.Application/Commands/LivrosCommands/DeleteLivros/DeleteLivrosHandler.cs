using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Commands.LivrosCommands.DeleteLivros
{
    public class DeleteLivrosHandler : IRequestHandler<DeleteLivrosCommand, ResultViewModel>
    {
        private readonly ILivroRepository _livroRepository;
        public DeleteLivrosHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteLivrosCommand request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Id);
            if (livro == null)
            {
                return ResultViewModel.Error("Livro não encontrado");
            }
            livro.SetAsDeleted();

            await _livroRepository.UpdateAsync(livro);
            return ResultViewModel.Success();
        }
    }
}
