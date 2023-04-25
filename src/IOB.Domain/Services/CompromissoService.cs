using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Repositories;
using IOB.Domain.Interfaces.Services;
using IOB.Domain.Services.Shared;

namespace IOB.Domain.Services;

public class CompromissoService : ServiceBase<Compromisso>, ICompromissoService
{
    public CompromissoService(ICompromissoRepository contatoRepository) : base(contatoRepository) { }
}