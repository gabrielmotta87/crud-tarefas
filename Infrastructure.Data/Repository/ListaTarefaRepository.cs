using Domain.DTO;
using Domain.Interfaces.Datas;
using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repository;

public class ListaTarefaRepository : IListaTarefaRepository
{
    private readonly ListaTarefaDbContext _listaTarefaDbContext;

    public ListaTarefaRepository(ListaTarefaDbContext listaTarefaDbContext)
    {
        _listaTarefaDbContext = listaTarefaDbContext;
    }

    public async Task<IEnumerable<ListaTarefaResponseDto>> BuscarTodasListasDeTarefaAsync()
    {
        Expression<Func<ListaTarefa, ListaTarefaResponseDto>> query = lt => new ListaTarefaResponseDto()
        {
            Responsavel = lt.Responsavel,
            Tarefas = lt.Tarefas!.Select(t => new TarefaResponseDto()
            {
                Nome = t.Nome,
                Status = t.Status,
                DataCriacao = t.DataCriacao,
                DataAtualizacao = t.DataAtualizacao
            })
        };

        var listaDeTarefasDto = await _listaTarefaDbContext.Set<ListaTarefa>()
            .AsNoTracking()
            .Select(query)
            .ToListAsync();

        return listaDeTarefasDto;
    }

    public async Task AdicionarListaDeTarefasAsync(ListaTarefa listaTarefa)
    {
        await _listaTarefaDbContext.AddAsync(listaTarefa);
        await _listaTarefaDbContext.SaveChangesAsync();
    }

    public void Dispose() => _listaTarefaDbContext.Dispose();
}