﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Aggregates;


namespace Todolist.Infrastructure.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(t => t.Id);

            // Propriedades
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(280);

            builder.Property(t => t.Descricao)
                .HasMaxLength(1000);

            // Relacionamento com TipoPrioridade (muitos para um)
            builder.HasOne(t => t.Prioridade)
                .WithMany()
                .HasForeignKey("PrioridadeId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); 

            // Relacionamento com Autor (muitos para um)
            builder.HasOne(t => t.Autor)
                .WithMany()
                .HasForeignKey("AutorId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); 

            // Relacionamento com Responsavel (muitos para um, opcional)
            builder.HasOne(t => t.Responsavel)
                .WithMany()
                .HasForeignKey("ResponsavelId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict); 

            // Objeto de Valor (TemposDaTarefa)
            builder.OwnsOne(t => t.TemposdaTarefa, tt =>
            {
                tt.Property(t => t.DataInicial)
                    .HasColumnName("DataInicial")
                    .IsRequired();

                tt.Property(t => t.Prazo)
                    .HasColumnName("Prazo")
                    .IsRequired(false);
            });
        }
    }

}
