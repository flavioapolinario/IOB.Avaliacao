using IOB.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IOB.Infra.Mappings;

public class CompromissoMap : IEntityTypeConfiguration<Compromisso>
{
    public void Configure(EntityTypeBuilder<Compromisso> builder)
    {
        builder.ToTable("Compromisso");

        builder.Property(p => p.Id)
           .ValueGeneratedNever();

        builder.Property(p => p.Titulo)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Descricao)
            .HasMaxLength(300)
            .IsRequired(false);

        builder.Property(p => p.DataCompromisso)            
            .IsRequired();
    }
}