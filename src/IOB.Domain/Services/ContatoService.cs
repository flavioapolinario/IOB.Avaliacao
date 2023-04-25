using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Repositories;
using IOB.Domain.Interfaces.Services;
using IOB.Domain.Services.Shared;

namespace IOB.Domain.Services;

public class ContatoService : ServiceBase<Contato>, IContatoService
{
    public ContatoService(IContatoRepository contatoRepository) : base(contatoRepository) { }
}