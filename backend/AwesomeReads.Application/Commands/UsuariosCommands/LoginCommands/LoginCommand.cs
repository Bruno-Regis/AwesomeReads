using AwesomeReads.Application.Models;
using MediatR;

namespace AwesomeReads.Application.Commands.UsuariosCommands.LoginCommands
{
    public class LoginCommand : IRequest<ResultViewModel<LoginResponseViewModel>>
    {
        public LoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
