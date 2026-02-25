using AwesomeReads.Core.Entities;
using AwesomeReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AwesomeReadsDbContext _context;
        public UsuarioRepository(AwesomeReadsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Usuarios.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> GetDetailsByIdAsync(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Avaliacoes)
                    .ThenInclude(av => av.Livro)
                .SingleOrDefaultAsync(u => u.Id == id);

            return usuario;
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
