using AtendeClienteService;
using Microsoft.Extensions.DependencyInjection;

namespace IOB.Correios.IoC;

public static class InjectorCorreiosConfig
{
    public static void AddCorreiosRegisterServices(this IServiceCollection services)
    {       
        services.AddScoped<AtendeCliente, AtendeClienteClient>();
    }
}