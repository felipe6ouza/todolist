using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Aggregates;


namespace Todolist.Infrastructure.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(t => t.TarefaId);

            builder.Property(t => t.Nome)
                .HasMaxLength(280)
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasMaxLength(1000);

            builder.OwnsOne(t => t.TemposdaTarefa);

            builder.HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.Projeto.ProjetoId);

            builder.HasOne(t => t.Prioridade)
                .WithMany()
                .HasForeignKey(t => t.Prioridade.PrioridadeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Autor)
                .WithMany()
                .HasForeignKey(t => t.Autor.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Responsavel)
                .WithMany()
                .HasForeignKey(t => t.Responsavel!.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
