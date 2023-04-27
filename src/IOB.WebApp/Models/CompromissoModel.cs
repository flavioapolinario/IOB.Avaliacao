using System.ComponentModel.DataAnnotations;

namespace IOB.WebApp.Models;

public class CompromissoModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Titulo é obrigatorio")]
    [Display(Name = "Compromisso")]
    [MaxLength(100)]
    public string Titulo { get; set; }


    [Display(Name = "Descrição")]
    [MaxLength(300)]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Data é obrigatorio")]
    [Display(Name = "Data")]
    public DateTime DataCompromisso { get; set; }    
}
