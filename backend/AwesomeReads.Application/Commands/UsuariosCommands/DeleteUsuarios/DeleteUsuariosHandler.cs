using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Commands.UsuariosCommands.DeleteUsuarios
{
    public class DeleteUsuariosHandler : IRequestHandler<DeleteUsuariosCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public DeleteUsuariosHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteUsuariosCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
            if (usuario == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }

            usuario.SetAsDeleted();

            await _usuarioRepository.UpdateAsync(usuario);
            return ResultViewModel.Success();
        }
    }
}
