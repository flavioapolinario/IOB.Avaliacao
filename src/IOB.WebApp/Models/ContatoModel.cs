using System.ComponentModel.DataAnnotations;

namespace IOB.WebApp.Models;

public class ContatoModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatorio")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Display(Name = "Telefone")]    
    public string Telefone { get; set; }

    [Required]
    [Display(Name = "Celular")]
    public string Celular { get; set; }

    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Data Nascimento")]
    public DateTime DataNascimento { get; set; }

    [Required]
    public EnderecoModel Endereco { get; set; }
}