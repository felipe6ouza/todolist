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

            builder.HasKey(p => p.ProjetoId);

            builder.Property(p => p.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(p => p.Cor);

            builder.OwnsOne(p => p.Status);

            builder.HasOne(p => p.Autor)
                .WithMany()
                .HasForeignKey(p => p.Autor.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
