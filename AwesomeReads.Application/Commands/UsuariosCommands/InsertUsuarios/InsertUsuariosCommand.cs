
using AwesomeReads.Application.Models;
using AwesomeReads.Core.Entities;
using MediatR;

namespace AwesomeReads.Application.Commands.UsersCommands.InsertUser
{
    public class InsertUsuariosCommand : IRequest<ResultViewModel<int>>
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Usuario ToEntity()
            => new(Email, Nome, Senha);
    }
}
