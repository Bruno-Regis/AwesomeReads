using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string email, string nome, List<Avaliacao> avaliacoes)
        {
            Email = email;
            Nome = nome;
            Avaliacoes = avaliacoes;
        }

        public string Email { get; private set; }
        public string Nome { get; private set; }
        public List<Avaliacao> Avaliacoes { get; private set; }
    }
}
