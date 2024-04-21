namespace IOB.Domain.ValueObjects;

public class Email
{
    public string? Descricao { get; private set; }

    public bool IsValid => string.IsNullOrEmpty(Descricao);
}
