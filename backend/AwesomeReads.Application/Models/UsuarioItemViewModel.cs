
using AwesomeReads.Core.Entities;

namespace AwesomeReads.Application.Models
{
    public class UsuarioItemViewModel
    {
        public UsuarioItemViewModel(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static UsuarioItemViewModel FromEntity(Usuario usuario)
        {
            return new UsuarioItemViewModel(usuario.Id, usuario.Nome, usuario.Email);
        }
    }
}
