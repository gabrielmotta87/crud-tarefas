namespace Domain.Models;

public class ListaTarefa
{
    public ListaTarefa()
    { }

    public ListaTarefa(int id, string? responsavel, ICollection<Tarefa>? tarefas)
    {
        Id = id;
        Responsavel = responsavel;
        Tarefas = tarefas;
    }

    public int Id { get; private set; }
    public string? Responsavel { get; private set; }
    public ICollection<Tarefa>? Tarefas { get; private set; }

    public ICollection<Tarefa> RemoverTarefas(ICollection<Tarefa>? tarefasAtualizadas)
    {
        ICollection<Tarefa> tarefasRemovidas = new List<Tarefa>();
        foreach (var tarefa in Tarefas!)
        {
            var tarefaRemovida = tarefasAtualizadas!.FirstOrDefault(t => t.Nome == tarefa.Nome);
            if (tarefaRemovida is null)
            {
                tarefasRemovidas.Add(tarefa!);
                Tarefas!.Remove(tarefa);
            }
        }

        return tarefasRemovidas;
    }

    public void AtualizarListaDeTarefas(ICollection<Tarefa> tarefasAtualizadas)
    {
        foreach (var tarefaAtualizada in tarefasAtualizadas!)
        {
            var tarefaExistente = Tarefas!.FirstOrDefault(t => t.Nome == tarefaAtualizada.Nome);
            if (tarefaExistente is not null)
            {
                tarefaExistente.SetStatus(tarefaAtualizada.Status);
                tarefaExistente.SetDataAtualizacao(DateTime.Now);
            }
            else
                Tarefas!.Add(tarefaAtualizada);
        }
    }
}