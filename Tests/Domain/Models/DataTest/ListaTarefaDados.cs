using Domain.Models;
using Domain.Models.Enums;

namespace Tests.Domain.Models.DataTest;

public class ListaTarefaDados
{
    public static IEnumerable<object[]> DadosParaListaDeTarefasRemovidasVazia()
    {
        yield return new object[]
        {
            new List<Tarefa>()
            {
                new Tarefa(1, "Tarefa_1", Status.EM_ANDAMENTO, DateTime.Now),
                new Tarefa(2, "Tarefa_2", Status.FINALIZADO, DateTime.Now)
            }
        };

        yield return new object[]
        {
            new List<Tarefa>()
            {
                new Tarefa(1, "Tarefa_1", Status.INICIADO, DateTime.Now),
                new Tarefa(2, "Tarefa_2", Status.EM_ANDAMENTO, DateTime.Now),
                new Tarefa(3, "Tarefa_3", Status.INICIADO, DateTime.Now)
            }
        };
    }

    public static IEnumerable<object[]> DadosParaListaDeTarefasRemovidasVaziaQuandoTarefasExistentesEstiverVazia()
    {
        yield return new object[]
        {
            new List<Tarefa>()
            { }
        };

        yield return new object[]
        {
            new List<Tarefa>()
            {
                new Tarefa(1, "Tarefa_1", Status.INICIADO, DateTime.Now),
                new Tarefa(2, "Tarefa_2", Status.EM_ANDAMENTO, DateTime.Now)
            }
        };
    }
}