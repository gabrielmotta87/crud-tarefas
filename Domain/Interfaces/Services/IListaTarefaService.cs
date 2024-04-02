using Domain.DTO;

namespace Domain.Interfaces.Services;

public interface IListaTarefaService
{
    Task<IEnumerable<ListaTarefaResponseDto>> BuscarTodasListasDeTarefaAsync();
    Task<ListaTarefaResponseDto> BuscarListaDeTarefaPorResponsavelAsync(string responsavel);
    Task AdicionarListaDeTarefasAsync(ListaTarefaRequestDto tarefasRequestDto);
    Task AtualizarListaDeTarefasAsync(string responsavel, ICollection<TarefaRequestDto> tarefasRequestDto);
    Task RemoverListaDeTarefasAsync(string responsavel);
}