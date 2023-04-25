using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Repositories;
using IOB.Infra.Context;
using IOB.Infra.Repositories.Shared;

namespace IOB.Infra.Repositories;

public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
{
    public ContatoRepository(IobContext dataContext) : base(dataContext) { }
}