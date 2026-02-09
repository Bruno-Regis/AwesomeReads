
using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Queries.UsersQueries.GetAllUsers
{
    public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosQuery, ResultViewModel<List<UsuarioItemViewModel>>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetAllUsuariosHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel<List<UsuarioItemViewModel>>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            var model = usuarios.Select(u => UsuarioItemViewModel.FromEntity(u)).ToList();

            return ResultViewModel<List<UsuarioItemViewModel>>.Success(model);
        }
    }
}
