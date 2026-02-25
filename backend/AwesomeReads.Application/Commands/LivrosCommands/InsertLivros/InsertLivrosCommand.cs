using AwesomeReads.Application.Models;
using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Enums;
using MediatR;

namespace AwesomeReads.Application.Commands.LivrosCommands.InsertLivros
{
    public class InsertLivrosCommand : IRequest<ResultViewModel<int>>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public GeneroLivroEnum Genero { get; set; }
        public int AnoDePublicacao { get; set; }
        public int QuantidadeDePaginas { get; set; }

        public Livro ToEntity()
            => new(Titulo, Descricao, ISBN, Autor, Editora, Genero, AnoDePublicacao, QuantidadeDePaginas);
    }
}
