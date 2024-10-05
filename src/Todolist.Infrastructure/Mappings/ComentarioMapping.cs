using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Entities;


namespace Todolist.Infrastructure.Mappings
{
    public class ComentarioMapping : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentarios");
            builder.HasKey(c => c.ComentarioId);

            builder.Property(c => c.Descricao)
                .HasMaxLength(1000)
                .IsRequired();

            builder.HasOne(c => c.Tarefa)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TarefaId);

            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
