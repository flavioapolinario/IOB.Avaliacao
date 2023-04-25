using AtendeClienteService;
using IOB.Application.DTO.Response;
using IOB.Application.Interfaces.Services;

namespace IOB.Correios.Services;

public class CorreiosService : ICorreiosService
{
    public readonly AtendeCliente _atendeCliente;

    public CorreiosService(AtendeCliente atendeCliente)
    {
        _atendeCliente = atendeCliente;
    }

    public async Task<EnderecoCorreioResponse?> ObterEnderecoPorCepAsync(string cep)
    {
        var enderecoCorreios = await _atendeCliente.consultaCEPAsync(new consultaCEP() { cep = cep });

        return enderecoCorreios is null
            ? null
            : new EnderecoCorreioResponse()
            {
                Logradouro = enderecoCorreios.@return.end,
                Bairro = enderecoCorreios.@return.bairro,
                Cidade = enderecoCorreios.@return.cidade,
                Estado = enderecoCorreios.@return.uf,
                Complemento = enderecoCorreios.@return.complemento2,
                Cep = enderecoCorreios.@return.cep,
            };
    }
}