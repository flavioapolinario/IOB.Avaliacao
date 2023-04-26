using IOB.Domain.Entidades.Shared;

namespace IOB.Domain.Entidades;

public class Endereco : Entidade
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public int? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public int ContatoId { get; set; }
    public Contato Contato { get; set; }
}