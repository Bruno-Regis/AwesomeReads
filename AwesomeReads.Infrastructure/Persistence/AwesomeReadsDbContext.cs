using Microsoft.EntityFrameworkCore;
using AwesomeReads.Core.Entities;
using AwesomeReads.Infrastructure.Persistence.Configurations;

namespace AwesomeReads.Infrastructure.Persistence
{
    public class AwesomeReadsDbContext : DbContext
    {
        public AwesomeReadsDbContext(DbContextOptions<AwesomeReadsDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuariosConfiguration());
            builder.ApplyConfiguration(new AvaliacoesConfiguration());
            builder.ApplyConfiguration(new LivrosConfiguration());
        }

    }
}
