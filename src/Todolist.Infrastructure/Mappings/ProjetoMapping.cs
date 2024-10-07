using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Aggregates;


namespace Todolist.Infrastructure.Mappings
{
    public class ProjetoMapping : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projetos");

            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150); 

            // Relacionamento com Autor (Usuario)
            builder.HasOne(p => p.Autor)
                .WithMany()
                .HasForeignKey("AutorId")
                .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com Tarefas (um para muitos)
            builder.HasMany(p => p.Tarefas)
                .WithOne(t => t.Projeto)
                .HasForeignKey("ProjetoId")
                .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            // Objeto de Valor (StatusProjeto)
            builder.OwnsOne(p => p.Status, status =>
            {
                status.Property(s => s.Favorito)
                      .HasColumnName("Favorito")
                      .IsRequired();

                status.Property(s => s.Ativo)
                      .HasColumnName("Ativo")
                      .IsRequired();
            });
        }
    }


}
