using AwesomeReads.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Application.Models
{
    public class AvaliacaoItemViewModel
    {
        public int Id { get; set; }
        public int Nota { get; private set; }
        public string Descricao { get; private set; }
        public int IdUsuario { get; private set; } 
        public int IdLivro { get; private set; }
        public string NomeUsuario { get; set; }
        public DateTime DataDaAvaliacao { get; set; }

        public static AvaliacaoItemViewModel FromEntity(Avaliacao avaliacao)
        {
            return new AvaliacaoItemViewModel
            {
                Id = avaliacao.Id,
                Nota = avaliacao.Nota,
                Descricao = avaliacao.Descricao,
                IdUsuario = avaliacao.IdUsuario,
                IdLivro = avaliacao.IdLivro,
                NomeUsuario = avaliacao.Usuario.Nome,
                DataDaAvaliacao = avaliacao.CreatedAt
            };
        }
    }
}
