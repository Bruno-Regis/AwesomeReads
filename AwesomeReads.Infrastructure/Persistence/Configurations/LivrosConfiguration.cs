using AwesomeReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AwesomeReads.Infrastructure.Persistence.Configurations
{
    public class LivrosConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Titulo)
                .HasMaxLength(200)
                .IsRequired();
            builder
                .Property(l => l.Descricao)
                .HasMaxLength(1000)
                .IsRequired();
            builder 
                .Property(l => l.ISBN)
                .HasMaxLength(13)
                .IsRequired();
            // garantindo que o ISBN seja único no banco de dados
            builder
                .HasIndex(l => l.ISBN)
                .IsUnique();

            builder
                .Property(l => l.Autor)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(l => l.Editora)
                .HasMaxLength(100)
                .IsRequired();

            // configurando enum para ser armazenado como string no banco de dados
            builder
                .Property(l => l.Genero)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(l => l.AnoDePublicacao)             
                .IsRequired();
            builder
                .Property(l => l.QuantidadeDePaginas)             
                .IsRequired();

            builder
                .Property(l => l.NotaMedia)
                .HasColumnType("decimal(3,2)")
                .IsRequired();
            builder
                .Property(a => a.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder
                .HasMany(l => l.Avaliacoes)
                .WithOne(a => a.Livro)
                .HasForeignKey(a => a.IdLivro)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(l => l.CapaLivro)
                .HasMaxLength(5242880);
        }
    }
}
