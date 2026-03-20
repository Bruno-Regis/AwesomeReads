

namespace AwesomeReads.Core.Entities
{
    public class Usuario : BaseEntity
    {
        private Usuario() { }
        public Usuario(string email, string nome, string senha, string role)
        {
            Email = email;
            Nome = nome;
            Senha = senha;
            Role = role;
            Avaliacoes = new List<Avaliacao>();
        }

        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }
        public List<Avaliacao> Avaliacoes { get; private set; }
    }
}
