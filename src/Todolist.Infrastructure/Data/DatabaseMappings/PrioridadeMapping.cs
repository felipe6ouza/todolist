using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todolist.Domain.Entities;
using Todolist.Domain.Enum;

namespace Todolist.Infrastructure.Data.DatabaseMappings
{
    public class PrioridadeMapping : IEntityTypeConfiguration<TipoPrioridade>
    {
        public void Configure(EntityTypeBuilder<TipoPrioridade> builder)
        {
            builder.ToTable("TiposPrioridade");

            builder.HasKey(tp => tp.PrioridadeId);

            builder.Property(tp => tp.PrioridadeId)
                .ValueGeneratedOnAdd();

            builder.Property(tp => tp.Descricao)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasData(
                 new { PrioridadeId = (int)TipoPrioridadeEnum.Alta, Descricao = TipoPrioridadeEnum.Alta.ToString() },
                 new { PrioridadeId = (int)TipoPrioridadeEnum.Media, Descricao = TipoPrioridadeEnum.Media.ToString() },
                 new { PrioridadeId = (int)TipoPrioridadeEnum.Baixa, Descricao = TipoPrioridadeEnum.Baixa.ToString() }
             );
        }
    }

}
