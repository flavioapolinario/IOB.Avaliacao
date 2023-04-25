using IOB.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IOB.Infra.Context;

public class IobContext : DbContext
{
    public IobContext(DbContextOptions<IobContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Compromisso> Compromissos { get; set; }
}
