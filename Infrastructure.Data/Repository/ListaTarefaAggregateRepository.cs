using Domain.Interfaces.Datas;
using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository;

public class ListaTarefaAggregateRepository : IListaTarefaAggregateRepository
{
    private readonly ListaTarefaDbContext _listaTarefaDbContext;

    public ListaTarefaAggregateRepository(ListaTarefaDbContext listaTarefaDbContext)
    {
        _listaTarefaDbContext = listaTarefaDbContext;
    }

    public async Task<ListaTarefa> BuscarListaDeTarefasPorResponsavelAsync(string responsavel)
    {
        var listaDeTarefas = await _listaTarefaDbContext.Set<ListaTarefa>()
                                                        .Include(lt => lt.Tarefas)
                                                        .SingleOrDefaultAsync(lt => lt.Responsavel == responsavel);

        return listaDeTarefas!;
    }

    public async Task AtualizarListaDeTarefasAsync()
    {
        await _listaTarefaDbContext.SaveChangesAsync();
    }

    public async Task RemoverListaDeTarefasAsync(ListaTarefa listaTarefa)
    {
        _listaTarefaDbContext.Remove(listaTarefa);
        await _listaTarefaDbContext.SaveChangesAsync();
    }

    public void RemoverTarefaDaListaAsync(List<Tarefa> tarefas)
    {
        _listaTarefaDbContext.RemoveRange(tarefas);
    }

    public void Dispose() => _listaTarefaDbContext.Dispose();
}