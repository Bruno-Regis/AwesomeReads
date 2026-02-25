using AwesomeReads.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Queries.AvaliacoesQueries.GetAllPorLivro
{
    public class GetAllPorLivroQuery : IRequest<ResultViewModel<List<AvaliacaoItemViewModel>>>
    {
        public GetAllPorLivroQuery(int idLivro)
        {
            IdLivro = idLivro;
        }

        public int IdLivro { get; set; }
    }
}
