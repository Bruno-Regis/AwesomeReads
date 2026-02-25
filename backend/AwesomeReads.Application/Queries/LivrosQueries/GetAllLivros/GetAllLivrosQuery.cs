using AwesomeReads.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Queries.LivrosQueries.GetAllLivros
{
    public class GetAllLivrosQuery : IRequest<ResultViewModel<List<LivroItemViewModel>>>
    {
    }
}
