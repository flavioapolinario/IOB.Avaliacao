using AutoMapper;
using IOB.Api.Controllers.Shared;
using IOB.Application.DTO.Request.Compromisso;
using IOB.Application.DTO.Response;
using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IOB.Api.Controllers.v1;

[ApiVersion("1.0")]
public class CompromissoController : ApiControllerBase
{
    private ICompromissoService _compromissoService;
    public readonly IMapper _mapper;

    public CompromissoController(ICompromissoService compromissoService, IMapper mapper)
    {
        _compromissoService = compromissoService;
        _mapper = mapper;
    }

    [ProducesResponseType(typeof(IEnumerable<CompromissoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompromissoResponse>>> ObterTodas()
    {
        var compromissos = await _compromissoService.ObterTodosAsync();
        var compromissosResponse = _mapper.Map<IEnumerable<CompromissoResponse>>(compromissos);
        return Ok(compromissosResponse);
    }

    [ProducesResponseType(typeof(IEnumerable<CompromissoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<CompromissoResponse>> ObterPorId(int id)
    {
        var compromisso = await _compromissoService.ObterPorIdAsync(id);
        if (compromisso is null)
            return NotFound();

        var compromissoResponse = _mapper.Map<CompromissoResponse>(compromisso);
        return Ok(compromissoResponse);
    }

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<int>> Inserir(InsereCompromissoRequest compromissoRequest)
    {
        var compromisso = _mapper.Map<Compromisso>(compromissoRequest);
        var id = (int)await _compromissoService.AdicionarAsync(compromisso);
        return CreatedAtAction(nameof(ObterPorId), new { id = id }, id);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizaCompromissoRequest compromissoRequest)
    {
        var compromisso = _mapper.Map<Compromisso>(compromissoRequest);
        await _compromissoService.AtualizarAsync(compromisso);
        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _compromissoService.RemoverPorIdAsync(id);
        return Ok();
    }
}