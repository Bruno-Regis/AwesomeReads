using AwesomeReads.Application.Models;
using AwesomeReads.Core.Models;
using AwesomeReads.Core.Repositories;
using AwesomeReads.Infrastructure.ExternalServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Queries.CatalogoQueries.GetLivroByIsbn
{
    public class GetLivroByIsbnQuery : IRequest<ResultViewModel<BookServiceViewModel>>
    {
        public GetLivroByIsbnQuery(string isbn)
        {
            Isbn = isbn;
        }
        public string Isbn { get; set; }
    }
}
