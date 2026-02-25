using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Enums;


namespace AwesomeReads.Application.Models
{
    public class AvaliacaoViewModel
    {
        public AvaliacaoViewModel(int id, string descricao, int nota, string nome, string email,
            string titulo, string descricaoLivro, string iSBN, string autor, string editora,
            GeneroLivroEnum genero, int anoDePublicacao, int quantidadeDePaginas, decimal notaMedia, byte[] capaLivro)
        {
            Id = id;
            Descricao = descricao;
            Nota = nota;
            Nome = nome;
            Email = email;
            Titulo = titulo;
            DescricaoLivro = descricaoLivro;
            ISBN = iSBN;
            Autor = autor;
            Editora = editora;
            Genero = genero;
            AnoDePublicacao = anoDePublicacao;
            QuantidadeDePaginas = quantidadeDePaginas;
            NotaMedia = notaMedia;
            CapaLivro = capaLivro;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }


        public string Titulo { get;  set; }
        public string DescricaoLivro { get;  set; }
        public string ISBN { get;  set; }
        public string Autor { get;  set; }
        public string Editora { get;  set; }
        public GeneroLivroEnum Genero { get;  set; }
        public int AnoDePublicacao { get;  set; }
        public int QuantidadeDePaginas { get;  set; }
        public decimal NotaMedia { get;  set; }
        public byte[] CapaLivro { get;  set; }


        public static AvaliacaoViewModel FromEntity(Avaliacao avaliacao)
            {
                return new AvaliacaoViewModel
                (
                    avaliacao.Id,
                    avaliacao.Descricao,
                    avaliacao.Nota,
                    avaliacao.Usuario.Nome,
                    avaliacao.Usuario.Email,
                    avaliacao.Livro.Titulo,
                    avaliacao.Livro.Descricao,
                    avaliacao.Livro.ISBN,
                    avaliacao.Livro.Autor,
                    avaliacao.Livro.Editora,
                    avaliacao.Livro.Genero,
                    avaliacao.Livro.AnoDePublicacao,
                    avaliacao.Livro.QuantidadeDePaginas,
                    avaliacao.Livro.NotaMedia,
                    avaliacao.Livro.CapaLivro
                );
        }

    }
}
