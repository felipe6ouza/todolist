using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Entities;

namespace Todolist.Infrastructure.Mappings
{
    public class HistoricoTarefaMapping : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> builder)
        {

            builder.ToTable("HistoricoTarefas");

            builder.HasKey(ht => ht.Id);

            builder.HasOne(ht => ht.Tarefa)
             .WithMany()
             .HasForeignKey(ht => ht.TarefaId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ht => ht.Modificacoes)
                      .HasColumnType("nvarchar(max)")  
                      .IsRequired();

            builder.HasOne(ht => ht.Usuario)
              .WithMany() 
              .HasForeignKey(ht => ht.UsuarioId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ht => ht.DataModificacao)
                      .IsRequired()
                      .HasColumnType("datetime");
        }
    }



}
