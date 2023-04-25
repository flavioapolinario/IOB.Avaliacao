namespace IOB.Application.DTO.Response;

public class CompromissoResponse
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCompromisso { get; set; }
    public string Dia => DataCompromisso.ToString("dd-MM-yyyy");
    public string Horario => DataCompromisso.ToString("HH:mm");

    public ICollection<ContatoResponse> Contatos { get; set; }
}