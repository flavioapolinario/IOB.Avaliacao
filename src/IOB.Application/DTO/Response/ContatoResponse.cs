namespace IOB.Application.DTO.Response;

public class ContatoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Telefone { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public EnderecoResponse Endereco { get; set; }
}

public class EnderecoResponse
{
    public int Id { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}