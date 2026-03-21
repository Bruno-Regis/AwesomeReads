using AwesomeReads.Application.Commands.UsersCommands.InsertUser;
using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using AwesomeReads.Infrastructure.Auth;
using MediatR;

namespace AwesomeReads.Application.Commands.UsuariosCommands.LoginCommands
{
    public class LoginHandler : IRequestHandler<LoginCommand, ResultViewModel<LoginResponseViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginHandler(IAuthService authService, IUsuarioRepository usuarioRepository)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel<LoginResponseViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var hash = _authService.ComputeHash(request.Senha);

            var usuario = await _usuarioRepository.GetByCredentials(request.Email, hash);

            if(usuario is null)
                return ResultViewModel<LoginResponseViewModel>.Error("Erro de login");

            var token = _authService.GenerateToken(usuario.Id, usuario.Email, usuario.Role);

            var viewModel = new LoginResponseViewModel(token);
            
            var result = ResultViewModel<LoginResponseViewModel>.Success(viewModel);

            return result;
        }
    }
}
