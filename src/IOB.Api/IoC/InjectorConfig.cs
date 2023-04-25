using IOB.Domain.Interfaces.Repositories;
using IOB.Domain.Interfaces.Services;
using IOB.Domain.Services;
using IOB.Infra.Context;
using IOB.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IOB.Api.IoC;

public static class InjectorConfig
{
    public static void AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IobContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("IobConnection"))
          );               
        
        services.AddScoped<ICompromissoService, CompromissoService>();
        services.AddScoped<IContatoService, ContatoService>();
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<ICompromissoRepository, CompromissoRepository>();
    }
}
