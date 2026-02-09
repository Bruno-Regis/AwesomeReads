using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Queries.UsuariosQueries.GetUsuarioById
{
    public class GetUsuarioByIdHandler : IRequestHandler<GetUsuarioByIdQuery, ResultViewModel<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuarioByIdHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel<UsuarioViewModel>> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
            if (usuario == null)
            {
                return ResultViewModel<UsuarioViewModel>.Error("Usuário não encontrado");
            }

            var model = UsuarioViewModel.FromEntity(usuario);
            return ResultViewModel<UsuarioViewModel>.Success(model);
        }
    }
}
