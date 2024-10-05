using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Entities;

namespace Todolist.Infrastructure.Mappings
{
    public class PrioridadeMapping : IEntityTypeConfiguration<TipoPrioridade>
    {
        public void Configure(EntityTypeBuilder<TipoPrioridade> builder)
        {
            builder.ToTable("TiposPrioridade");

            builder.HasKey(tp => tp.PrioridadeId);

            // Propriedades
            builder.Property(tp => tp.PrioridadeId)
                .ValueGeneratedOnAdd(); 

            builder.Property(tp => tp.Descricao)
                .IsRequired()
                .HasMaxLength(30); 
        }
    }

}
