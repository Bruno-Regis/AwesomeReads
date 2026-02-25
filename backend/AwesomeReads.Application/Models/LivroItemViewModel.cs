using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Models
{
    public class LivroItemViewModel
    {
        public LivroItemViewModel(int id, string titulo, string descricao, string iSBN,
            string autor, string editora, GeneroLivroEnum genero, int anoDePublicacao,
            int quantidadeDePaginas, decimal notaMedia, int quantidadeDeAvaliacoes)
        {
            Id = id;
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
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public GeneroLivroEnum Genero { get; set; }
        public int AnoDePublicacao { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public decimal NotaMedia { get;  set; }
        public int QuantidadeDeAvaliacoes { get; set; }

        public static LivroItemViewModel FromEntity(Livro livro)
        {
            return new LivroItemViewModel
            (
                livro.Id,
                livro.Titulo,
                livro.Descricao,
                livro.ISBN,
                livro.Autor,
                livro.Editora,
                livro.Genero,
                livro.AnoDePublicacao,
                livro.QuantidadeDePaginas,
                livro.NotaMedia,
                livro.Avaliacoes?.Count ?? 0
            );
        }
    }
}
