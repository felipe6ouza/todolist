using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Enum;

namespace Todolist.Infrastructure.Data.DatabaseMappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(150); 

            builder.Property(u => u.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

                builder.HasData(
                 new Usuario ("Felipe", "Souza", DateTime.Now.AddYears(-26), (int)FuncaoUsuarioEnum.Colaborador, 1),
                 new Usuario("Linus", "Towards", DateTime.Now.AddYears(-54), (int)FuncaoUsuarioEnum.Gerente, 2)
             );

        }
    }
}
