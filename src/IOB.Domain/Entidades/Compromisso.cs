using IOB.Domain.Entidades.Shared;

namespace IOB.Domain.Entidades;

public class Compromisso : Entidade
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCompromisso { get; set; }
    public ICollection<Contato>? Contatos { get; set; }
}