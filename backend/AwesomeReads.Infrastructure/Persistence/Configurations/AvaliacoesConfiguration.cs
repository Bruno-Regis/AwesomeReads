using AwesomeReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeReads.Infrastructure.Persistence.Configurations
{
    public class AvaliacoesConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nota)
                .IsRequired();

            builder.Property(a => a.Descricao)
                .HasMaxLength(1000);

            builder
                .Property(a => a.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();
                
            builder
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            // relacionamento N:1 com Usuario e Livro
            builder
                .HasOne(a => a.Usuario)
                    .WithMany(u => u.Avaliacoes)
                    .HasForeignKey(a => a.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(a => a.Livro)
                    .WithMany(l => l.Avaliacoes)
                    .HasForeignKey(a => a.IdLivro)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
