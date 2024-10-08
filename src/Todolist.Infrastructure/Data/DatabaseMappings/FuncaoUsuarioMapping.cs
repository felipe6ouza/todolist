using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Entities;
using Todolist.Domain.Enum;

namespace Todolist.Infrastructure.Data.DatabaseMappings
{

    public class FuncaoUsuarioMapping : IEntityTypeConfiguration<FuncaoUsuario>
    {
        public void Configure(EntityTypeBuilder<FuncaoUsuario> builder)
        {
            builder.ToTable("FuncaoUsuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                    .ValueGeneratedOnAdd();

            builder
             .HasMany(f => f.Usuarios)
             .WithOne(u => u.FuncaoUsuario)
             .HasForeignKey(u => u.FuncaoUsuarioId)
             .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasData(
                    new { Id = (int)FuncaoUsuarioEnum.Colaborador, Descricao = FuncaoUsuarioEnum.Colaborador.ToString() },
                    new { Id = (int)FuncaoUsuarioEnum.Gerente, Descricao = FuncaoUsuarioEnum.Gerente.ToString() });
        }

    }
}
