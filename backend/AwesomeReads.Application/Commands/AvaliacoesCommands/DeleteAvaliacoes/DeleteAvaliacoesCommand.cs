using AwesomeReads.Application.Models;
using MediatR;

namespace AwesomeReads.Application.Commands.AvaliacoesCommands.DeleteAvaliacoes
{
    public class DeleteAvaliacoesCommand : IRequest<ResultViewModel>
    {
        public DeleteAvaliacoesCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
