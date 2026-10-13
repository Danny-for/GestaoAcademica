using System.ComponentModel.DataAnnotations;

namespace GestaoAcademica.Api.Models;

public class Aluno
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Curso { get; set; } = string.Empty;
}
