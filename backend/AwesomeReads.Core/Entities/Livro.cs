using AwesomeReads.Core.Enums;

namespace AwesomeReads.Core.Entities
{
    public class Livro : BaseEntity
    {
        private Livro() { }
        public Livro(string titulo, string descricao, string iSBN, string autor,
            string editora, GeneroLivroEnum genero,
            int anoDePublicacao, int quantidadeDePaginas)
        {
            Titulo = titulo;
            Descricao = descricao;
            ISBN = iSBN;
            Autor = autor;
            Editora = editora;
            Genero = genero;
            AnoDePublicacao = anoDePublicacao;
            QuantidadeDePaginas = quantidadeDePaginas;
            NotaMedia = 0.0m;
            Avaliacoes = new List<Avaliacao>();
        }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string ISBN { get; private set; }
        public string Autor { get; private set; }
        public string Editora { get; private set; }
        public GeneroLivroEnum Genero { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public int QuantidadeDePaginas { get; private set; }
        public decimal NotaMedia { get; private set; }
        public string? CapaLivro { get; private set; }
        public List<Avaliacao> Avaliacoes { get; private set; }

        
        public void AtualizarCapaLivro(string capa)
        {
            CapaLivro = capa;
        }

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            Avaliacoes.Add(avaliacao);
            AtualizarNotaMedia();
        }

        public void AtualizarNotaMedia()
        {
            var avaliacoesAtivas = Avaliacoes?.Where(a => !a.IsDeleted).ToList();

            NotaMedia = avaliacoesAtivas?.Any() == true
                ? (decimal)avaliacoesAtivas.Average(a => a.Nota)
                : 0.0m;
        }
    }
}
