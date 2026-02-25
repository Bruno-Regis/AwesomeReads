using AwesomeReads.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Queries.UsersQueries.GetAllUsers
{
    public class GetAllUsuariosQuery :IRequest<ResultViewModel<List<UsuarioItemViewModel>>>
    {

    }
}
