using AwesomeReads.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Core.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<List<Avaliacao>> GetAllPorLivroAsync(int livroId);
        Task<int> AddAsync(Avaliacao avaliacao);
        Task UpdateAsync(Avaliacao avaliacao);
    }
}
 