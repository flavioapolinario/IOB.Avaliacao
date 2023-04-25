using AutoMapper;
using IOB.Api.Controllers.Shared;
using IOB.Application.DTO.Request.Contato;
using IOB.Application.DTO.Response;
using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IOB.Api.Controllers.v1;

[ApiVersion("1.0")]
public class ContatoController : ApiControllerBase
{
    private IContatoService _contatoService;
    public readonly IMapper _mapper;

    public ContatoController(IContatoService contatoService, IMapper mapper)
    {
        _contatoService = contatoService;
        _mapper = mapper;
    }

    [ProducesResponseType(typeof(IEnumerable<ContatoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContatoResponse>>> ObterTodas()
    {
        var contatos = await _contatoService.ObterTodosAsync();
        var contatosResponse = _mapper.Map<IEnumerable<ContatoResponse>>(contatos);
        return Ok(contatosResponse);
    }

    [ProducesResponseType(typeof(IEnumerable<ContatoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ContatoResponse>> ObterPorId(int id)
    {
        var contato = await _contatoService.ObterPorIdAsync(id);
        if (contato is null)
            return NotFound();

        var contatoResponse = _mapper.Map<ContatoResponse>(contato);
        return Ok(contatoResponse);
    }

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Inserir(InsereContatoRequest contatoRequest)
    {
        var contato = _mapper.Map<Contato>(contatoRequest);
        var id = (int)await _contatoService.AdicionarAsync(contato);
        return CreatedAtAction(nameof(ObterPorId), new { id = id }, id);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizaContatoRequest contatoRequest)
    {
        var contato = _mapper.Map<Contato>(contatoRequest);
        await _contatoService.AtualizarAsync(contato);
        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _contatoService.RemoverPorIdAsync(id);
        return Ok();
    }
}