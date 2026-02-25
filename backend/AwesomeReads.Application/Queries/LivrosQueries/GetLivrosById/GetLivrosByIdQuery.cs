using AwesomeReads.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Queries.LivrosQueries.GetLivrosById
{
    public class GetLivrosByIdQuery : IRequest<ResultViewModel<LivroViewModel>>
    {
        public GetLivrosByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
