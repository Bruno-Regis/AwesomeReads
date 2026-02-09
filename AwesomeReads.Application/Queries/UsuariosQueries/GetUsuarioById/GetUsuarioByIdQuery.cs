using AwesomeReads.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Queries.UsuariosQueries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IRequest<ResultViewModel<UsuarioViewModel>>
    {
        public int Id { get; set; }

        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }
    }
}
