using AwesomeReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeReads.Infrastructure.Persistence.Configurations
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Nome)
                    .HasMaxLength(100)    
                    .IsRequired();

            builder
                .Property(u => u.Email)
                    .HasMaxLength(100)
                    .IsRequired();
            // Garantir que o email seja único
            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Senha)
                    .HasMaxLength(255)
                    .IsRequired();

            builder
            .Property(a => a.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

            builder
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            // relacionamento 1:N com avaliação
            builder
                .HasMany(u => u.Avaliacoes)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
