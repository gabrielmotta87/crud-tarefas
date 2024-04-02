namespace Domain.DTO;

public class ListaTarefaResponseDto
{
    public string? Responsavel { get; set; }
    public IEnumerable<TarefaResponseDto>? Tarefas { get; set; }
}