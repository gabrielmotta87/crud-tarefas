using Domain.Models;

namespace Domain.Interfaces.Datas;

public interface IListaTarefaAggregateRepository : IDisposable
{
    Task<ListaTarefa> BuscarListaDeTarefasPorResponsavelAsync(string responsavel);
    Task AtualizarListaDeTarefasAsync();
    Task RemoverListaDeTarefasAsync(ListaTarefa listaTarefa);
    void RemoverTarefaDaListaAsync(List<Tarefa> tarefas);
}