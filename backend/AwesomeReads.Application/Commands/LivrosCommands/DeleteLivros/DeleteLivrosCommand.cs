using AwesomeReads.Application.Models;
using MediatR;

namespace AwesomeReads.Application.Commands.LivrosCommands.DeleteLivros
{
    public class DeleteLivrosCommand : IRequest<ResultViewModel>
    {
        public DeleteLivrosCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
