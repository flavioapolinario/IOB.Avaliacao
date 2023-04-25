using IOB.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IOB.Infra.Mappings;

public class ContatoMap : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("Contato");

        builder.Property(p => p.Id)
           .ValueGeneratedNever();

        builder.Property(p => p.Nome)
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(p => p.Telefone)
            .HasMaxLength(10)
            .IsRequired(false);

        builder.Property(p => p.Celular)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.DataNascimento)
            .IsRequired();

        builder.HasOne(p => p.Endereco)
            .WithOne(p => p.Contato)
            .HasForeignKey<Endereco>(p => p.ContatoId);

        builder.HasMany(p => p.Compromissos)
            .WithMany(p => p.Contatos)
            .UsingEntity("ContatoCompromisso",
                l => l.HasOne(typeof(Compromisso)).WithMany().HasForeignKey("CompromissoId").HasPrincipalKey(nameof(Compromisso.Id)),
                r => r.HasOne(typeof(Contato)).WithMany().HasForeignKey("ContatoId").HasPrincipalKey(nameof(Contato.Id)),
                j => j.HasKey("ContatoId", "CompromissoId"));
    }
}