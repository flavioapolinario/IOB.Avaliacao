namespace IOB.Application.DTO.Request.Contato;

public class InsereContatoRequest
{
    public string Nome { get; set; }
    public string? Telefone { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public InsereEnderecoRequest Endereco { get; set; }
}

public class InsereEnderecoRequest
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public int? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}