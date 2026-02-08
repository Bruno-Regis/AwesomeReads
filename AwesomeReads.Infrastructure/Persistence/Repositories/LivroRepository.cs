using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AwesomeReadsDbContext _context;
        public LivroRepository(AwesomeReadsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
            return livro.Id;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Livros.AnyAsync(l => l.Id == id);
        }

        public async Task<List<Livro>> GetAllAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros.SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Livro?> GetDetailsByIdAsync(int id)
        {
            return await _context.Livros
                .Include(l => l.Avaliacoes)
                    .ThenInclude(av => av.Usuario)
                .SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }
    }
}
