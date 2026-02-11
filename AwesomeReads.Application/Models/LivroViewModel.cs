using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Models
{
    public class LivroViewModel
    {
        public LivroViewModel(string titulo, string descricao, string iSBN, string autor,
            string editora, GeneroLivroEnum genero, int anoDePublicacao, int quantidadeDePaginas,
            decimal notaMedia, int quantidadeDeAvaliacoes, List<AvaliacaoViewModel> avaliacoes)
        {
            Titulo = titulo;
            Descricao = descricao;
            ISBN = iSBN;
            Autor = autor;
            Editora = editora;
            Genero = genero;
            AnoDePublicacao = anoDePublicacao;
            QuantidadeDePaginas = quantidadeDePaginas;
            NotaMedia = notaMedia;
            QuantidadeDeAvaliacoes = quantidadeDeAvaliacoes;
            Avaliacoes = avaliacoes;
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public GeneroLivroEnum Genero { get; set; }
        public int AnoDePublicacao { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public decimal NotaMedia { get; set; }
        public int QuantidadeDeAvaliacoes { get; set; }
        public List<AvaliacaoViewModel> Avaliacoes { get; set; }

        public static LivroViewModel FromEntity(Livro livro)
        {
            return new LivroViewModel
            (
                livro.Titulo,
                livro.Descricao,
                livro.ISBN,
                livro.Autor,
                livro.Editora,
                livro.Genero,
                livro.AnoDePublicacao,
                livro.QuantidadeDePaginas,
                livro.NotaMedia,
                livro.Avaliacoes.Count,
                livro.Avaliacoes?
                    .Select(a => AvaliacaoViewModel.FromEntity(a))
                    .ToList() ?? new List<AvaliacaoViewModel>()
            );
        }
    }
}
