using AwesomeReads.Application.Models;
using AwesomeReads.Core.Entities;
using MediatR;

namespace AwesomeReads.Application.Commands.AvaliacoesCommands.InsertAvaliacoes
{
    public class InsertAvaliacoesCommand : IRequest<ResultViewModel<int>>
    {
        public int Nota { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }

        public Avaliacao ToEntity()
            => new(Nota, Descricao, IdUsuario, IdLivro);
    }
}
