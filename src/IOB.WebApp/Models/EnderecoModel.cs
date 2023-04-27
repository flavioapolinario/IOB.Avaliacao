using System.ComponentModel.DataAnnotations;

namespace IOB.WebApp.Models;

public class EnderecoModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Cep é obrigatorio")]
    [Display(Name = "Cep")]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Logradouro é obrigatorio")]
    [Display(Name = "Logradouro")]
    [MaxLength(200)]
    public string Logradouro { get; set; }

    [Display(Name = "Número")]
    public string? Numero { get; set; }

    [Display(Name = "Complemento")]
    public string? Complemento { get; set; }

    [Display(Name = "Bairro")]
    public string? Bairro { get; set; }

    [Required(ErrorMessage = "Cidade é obrigatoria")]
    [Display(Name = "Cidade")]
    [MaxLength(200)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "Estado é obrigatorio")]
    [Display(Name = "Estado")]
    [MaxLength(2)]
    public string Estado { get; set; }
}
