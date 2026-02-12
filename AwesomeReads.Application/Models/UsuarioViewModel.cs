using AwesomeReads.Core.Entities;

namespace AwesomeReads.Application.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string nome, string email, List<AvaliacaoViewModel> avaliacoes)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Avaliacoes = avaliacoes;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<AvaliacaoViewModel> Avaliacoes { get; set; }

        public static UsuarioViewModel FromEntity(Usuario usuario)
        {
            return new UsuarioViewModel
            (
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.Avaliacoes?
                    .Select(a => AvaliacaoViewModel.FromEntity(a))
                    .ToList() ?? new List<AvaliacaoViewModel>()
            );
        }

        }
}

