namespace IOB.Application.DTO.Request.Compromisso;

public class AtualizaCompromissoRequest
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCompromisso { get; set; }
}
