using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Infrastructure.Persistence.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly AwesomeReadsDbContext _context;
        public AvaliacaoRepository(AwesomeReadsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Avaliacao avaliacao)
        {
            await _context.AddAsync(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao.Id;
        }

        public async Task<List<Avaliacao>> GetAllPorLivroAsync(int livroId)
        {
            var avaliacoes = await _context
                .Avaliacoes
                .Where(a => a.IdLivro == livroId)
                .Where(a => !a.IsDeleted)
                .ToListAsync();

            return avaliacoes;
        }

        public async Task UpdateAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Update(avaliacao);
            await _context.SaveChangesAsync();
        }
    }
}
