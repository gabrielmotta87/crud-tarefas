using Domain.Models.Enums;

namespace Domain.DTO;

public class TarefaResponseDto
{
    public string? Nome { get; set; }
    public Status Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}