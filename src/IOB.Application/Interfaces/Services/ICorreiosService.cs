using IOB.Application.DTO.Response;

namespace IOB.Application.Interfaces.Services;

public interface ICorreiosService
{
    Task<EnderecoCorreioResponse?> ObterEnderecoPorCepAsync(string cep);
}