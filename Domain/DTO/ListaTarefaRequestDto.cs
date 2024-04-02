using System.ComponentModel.DataAnnotations;

namespace Domain.DTO;

public class ListaTarefaRequestDto
{
    [Required(ErrorMessage = "{0} é obrigatório!")]
    [MaxLength(20, ErrorMessage = "{0} pode ter no máximo {1} caracteres")]
    public string? Responsavel { get; set; }
    public ICollection<TarefaRequestDto>? Tarefas { get; set; }
}