using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Entities;
using System.Reflection.Emit;

namespace Todolist.Infrastructure.Mappings
{

    public class FuncaoUsuarioMapping : IEntityTypeConfiguration<FuncaoUsuario>
        {
            public void Configure(EntityTypeBuilder<FuncaoUsuario> builder)
            {
                builder.ToTable("FuncaoUsuario");

                builder.HasKey(u => u.Id);

                builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

            builder
             .HasMany(f => f.Usuarios)
             .WithOne(u => u.FuncaoUsuario)
             .HasForeignKey(u => u.FuncaoUsuarioId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new { Id = 0, Descricao = "Usuario" },
                    new { Id = 1, Descricao = "Gerente" });
            }
        
    }
}
