using AwesomeReads.Core.Entities;

namespace AwesomeReads.Core.Repositories
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAllAsync();
        Task<Livro?> GetByIdAsync(int id);
        Task<Livro?> GetDetailsByIdAsync(int id);
        Task<int> AddAsync(Livro livro); // ok
        Task<bool> ExistsAsync(int id);
        Task UpdateAsync(Livro livro); // ok
        Task<bool> ExistsISBNAsync(string isbn);
    }
}
