using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Entities;
using Todolist.Domain.Enum;

namespace Todolist.Infrastructure.Data.DatabaseMappings
{
    public class StatusTarefaMapping : IEntityTypeConfiguration<StatusTarefa>
    {
        public void Configure(EntityTypeBuilder<StatusTarefa> builder)
        {
            builder.ToTable("StatusTarefa");

            builder.HasKey(c => c.Id);

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new { Id = (int)StatusTarefaEnum.Pendente, Descricao = StatusTarefaEnum.Pendente.ToString() },
                new { Id = (int)StatusTarefaEnum.Concluida, Descricao = StatusTarefaEnum.Concluida.ToString() },
                new { Id = (int)StatusTarefaEnum.Arquivada, Descricao = StatusTarefaEnum.Cancelada.ToString() },
                new { Id = (int)StatusTarefaEnum.Cancelada, Descricao = StatusTarefaEnum.Arquivada.ToString() }

        );
        }
    }
}
