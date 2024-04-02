using Domain.DTO;
using Domain.Models;

namespace Domain.Interfaces.Datas;

public interface IListaTarefaRepository : IDisposable
{
    Task<IEnumerable<ListaTarefaResponseDto>> BuscarTodasListasDeTarefaAsync();
    Task AdicionarListaDeTarefasAsync(ListaTarefa listaTarefa);
}