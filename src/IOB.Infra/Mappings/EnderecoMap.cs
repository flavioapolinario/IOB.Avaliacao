using IOB.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IOB.Infra.Mappings;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Endereco");

        builder.Property(p => p.Id)
           .ValueGeneratedNever();

        builder.Property(p => p.Logradouro)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Numero)
            .HasMaxLength(10)
            .IsRequired(false);

        builder.Property(p => p.Complemento)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(p => p.Bairro)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(p => p.Cidade)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Estado)
            .HasMaxLength(2)
            .IsRequired();       
    }
}