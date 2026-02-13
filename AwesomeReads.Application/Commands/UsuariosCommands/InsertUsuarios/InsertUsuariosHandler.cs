
using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Commands.UsersCommands.InsertUser
{
    public class InsertUsuariosHandler : IRequestHandler<InsertUsuariosCommand, ResultViewModel<int>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public InsertUsuariosHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUsuariosCommand request, CancellationToken cancellationToken)
        {
            var usuarioJaExiste = await _usuarioRepository.ExistsEmailAsync(request.Email);

            if (usuarioJaExiste)
                return ResultViewModel<int>.Error("Já existe um usuário com este e-mail.");

            var usuario = request.ToEntity();
            await _usuarioRepository.AddAsync(usuario);

            return ResultViewModel<int>.Success(usuario.Id);
        }
    }
}
