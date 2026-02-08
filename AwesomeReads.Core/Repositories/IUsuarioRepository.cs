using AwesomeReads.Core.Entities;

namespace AwesomeReads.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetDetailsByIdAsync(int id);
        Task<int> AddAsync(Usuario usuario);
        Task<bool> ExistsAsync(int id);
        Task UpdateAsync(Usuario usuario);
    }
}
