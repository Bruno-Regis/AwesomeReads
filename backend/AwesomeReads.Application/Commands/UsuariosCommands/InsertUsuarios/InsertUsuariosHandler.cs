
using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using AwesomeReads.Infrastructure.Auth;
using MediatR;

namespace AwesomeReads.Application.Commands.UsersCommands.InsertUser
{
    public class InsertUsuariosHandler : IRequestHandler<InsertUsuariosCommand, ResultViewModel<int>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;
        public InsertUsuariosHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUsuariosCommand request, CancellationToken cancellationToken)
        {
            var usuarioJaExiste = await _usuarioRepository.ExistsEmailAsync(request.Email);

            if (usuarioJaExiste)
                return ResultViewModel<int>.Error("Já existe um usuário com este e-mail.");

            var hash = _authService.ComputeHash(request.Senha);
            
            request.Senha = hash;

            request.Role = "leitor";

            var usuario = request.ToEntity();
            await _usuarioRepository.AddAsync(usuario);

            return ResultViewModel<int>.Success(usuario.Id);
        }
    }
}
