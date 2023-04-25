﻿using IOB.Domain.Entidades.Shared;

namespace IOB.Domain.Entidades;

public class Contato : Entidade
{
    public string Nome { get; set; }
    public long? Telefone { get; set; }
    public long Celular { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public Endereco Endereco { get; set; }
    public ICollection<Compromisso>? Compromissos { get; set; }
}