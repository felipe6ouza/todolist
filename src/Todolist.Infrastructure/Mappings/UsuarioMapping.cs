using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Aggregates;

namespace Todolist.Infrastructure.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Nome da tabela
            builder.ToTable("Usuarios");

            // Chave primária
            builder.HasKey(u => u.Id);

            // Propriedades
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd(); // ID gerado automaticamente

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100); // Limite de 100 caracteres para o nome

            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(150); // Limite de 150 caracteres para o sobrenome

            builder.Property(u => u.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime"); // Define o tipo da coluna como datetime
        }
    }
}
