using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO;

public class TarefaRequestDto
{
    public string? Nome { get; set; }
    [Range(0, 4, ErrorMessage = "Para o campo {0} escolha um número inteiro entre {1} e {2}!")]
    public Status Status { get; set; }
}