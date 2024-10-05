using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Aggregates;

namespace Todolist.Infrastructure.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.UsuarioId);

            builder.Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Sobrenome)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
