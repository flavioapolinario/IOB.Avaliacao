using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Repositories;
using IOB.Infra.Context;
using IOB.Infra.Repositories.Shared;

namespace IOB.Infra.Repositories;

public class CompromissoRepository : RepositoryBase<Compromisso>, ICompromissoRepository
{
    public CompromissoRepository(IobContext dataContext) : base(dataContext) { }
}