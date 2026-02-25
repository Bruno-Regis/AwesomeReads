
using AwesomeReads.Application.Models;
using MediatR;

namespace AwesomeReads.Application.Commands.UsuariosCommands.DeleteUsuarios
{
    public class DeleteUsuariosCommand : IRequest<ResultViewModel>
    {
        public DeleteUsuariosCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
