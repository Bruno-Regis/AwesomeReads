using AwesomeReads.Application.Models;
using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Queries.LivrosQueries.GetAllLivros
{
    public class GetAllLivrosHandler : IRequestHandler<GetAllLivrosQuery, ResultViewModel<List<LivroItemViewModel>>>
    {
        private readonly ILivroRepository _livroRepository;
        public GetAllLivrosHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<ResultViewModel<List<LivroItemViewModel>>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.GetAllAsync();

            var model = livros.Select(l => LivroItemViewModel.FromEntity(l)).ToList();
            return new ResultViewModel<List<LivroItemViewModel>>(model);
        }
    }
}
