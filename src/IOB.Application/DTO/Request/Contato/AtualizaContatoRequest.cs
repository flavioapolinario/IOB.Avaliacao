﻿namespace IOB.Application.DTO.Request.Contato;

public class AtualizaContatoRequest
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Telefone { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public AtualizaEnderecoRequest Endereco { get; set; }
}

public class AtualizaEnderecoRequest
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