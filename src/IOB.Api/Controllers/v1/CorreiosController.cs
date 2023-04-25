using AutoMapper;
using IOB.Api.Controllers.Shared;
using IOB.Application.DTO.Response;
using IOB.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IOB.Api.Controllers.v1;

[ApiVersion("1.0")]
public class CorreiosController : ApiControllerBase
{
    private ICorreiosService _correiosService;
    public readonly IMapper _mapper;

    public CorreiosController(ICorreiosService correiosService, IMapper mapper)
    {
        _correiosService = correiosService;
        _mapper = mapper;
    }

    [ProducesResponseType(typeof(IEnumerable<CompromissoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{cep}")]
    public async Task<ActionResult<EnderecoResponse>> ObterEnderecoPorCep(string cep)
    {
        var endereco = await _correiosService.ObterEnderecoPorCepAsync(cep);
        if (endereco is null)
            return NotFound();
        
        return Ok(endereco);
    }
}