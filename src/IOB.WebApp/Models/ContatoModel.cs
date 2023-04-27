using System.ComponentModel.DataAnnotations;

namespace IOB.WebApp.Models;

public class ContatoModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatorio")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Display(Name = "Telefone")]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = "Celular é obrigatorio")]
    [Display(Name = "Celular")]
    public string Celular { get; set; }

    [Required(ErrorMessage = "Email é obrigatorio")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Data Nascimento é obrigatoria")]
    [Display(Name = "Data Nascimento")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Endereço é obrigatorio")]
    public EnderecoModel Endereco { get; set; }
}