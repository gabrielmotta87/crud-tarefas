using Domain.Models;
using Domain.Models.Enums;
using System.ComponentModel;
using Tests.Domain.Models.DataTest;

namespace Tests.Domain.Models;

public class ListaTarefaTest
{
    [Theory]
    [MemberData(nameof(ListaTarefaDados.DadosParaListaDeTarefasRemovidasVazia), MemberType = typeof(ListaTarefaDados))]
    [DisplayName("Cenário onde todas as tarefas já existentes estão presentes nas tarefas atualizadas não ocorrendo, portanto, nenhuma remoção de tarefa.")]
    public void Colecao_De_Tarefas_Removidas_Deve_Retornar_Vazia_Quando_A_Lista_Com_As_Tarefas_Existentes_Existirem_Nas_Tarefas_Atualizadas(ICollection<Tarefa>? tarefasAtualizadas)
    {
        //Arrange
        ICollection<Tarefa> tarefasExistentes = new List<Tarefa>()
        {
            new Tarefa(1, "Tarefa_1", Status.INICIADO, DateTime.Now),
            new Tarefa(2, "Tarefa_2", Status.EM_ANDAMENTO, DateTime.Now)
        };
        var listaTarefasExistentes = new ListaTarefa(1, "Gabriel", tarefasExistentes);

        //Act
        var tarefasRemovidas = listaTarefasExistentes.RemoverTarefas(tarefasAtualizadas);

        //Assert
        Assert.Empty(tarefasRemovidas);
    }

    [Theory]
    [MemberData(nameof(ListaTarefaDados.DadosParaListaDeTarefasRemovidasVaziaQuandoTarefasExistentesEstiverVazia), MemberType = typeof(ListaTarefaDados))]
    [DisplayName("Cenário onde a lista de tarefas removidas deve retornar vazia pelo fato de não haver tarefas existentes.")]
    public void Colecao_De_Tarefas_Removidas_Deve_Retornar_Vazia_Quando_A_Lista_Com_As_Tarefas_Existentes_Estiver_Vazia(ICollection<Tarefa>? tarefasAtualizadas)
    {
        //Arrange
        ICollection<Tarefa> tarefasExistentes = new List<Tarefa>()
        { };
        var listaTarefasExistentes = new ListaTarefa(1, "Gabriel", tarefasExistentes);

        //Act
        var tarefasRemovidas = listaTarefasExistentes.RemoverTarefas(tarefasAtualizadas);

        //Assert
        Assert.Empty(tarefasRemovidas);
    }

    [Fact]
    [DisplayName("Cenário onde se atualizam os campos Status e DataAtualizacao das tarefas existentes.")]
    public void Tarefas_Existentes_Devem_Ser_Iguais_As_Tarefas_Atualizadas()
    {
        //Arrange
        ICollection<Tarefa> tarefasExistentes = new List<Tarefa>()
        {
            new Tarefa(1, "Tarefa_1", Status.INICIADO, DateTime.Now),
            new Tarefa(2, "Tarefa_2", Status.EM_ANDAMENTO, DateTime.Now)
        };
        var listaTarefasExistentes = new ListaTarefa(1, "Gabriel", tarefasExistentes);

        ICollection<Tarefa> tarefasAtualizadas = new List<Tarefa>()
            {
                new Tarefa(1, "Tarefa_1", Status.CANCELADO, DateTime.Now),
                new Tarefa(2, "Tarefa_2", Status.FINALIZADO, DateTime.Now)
            };

        //Act
        listaTarefasExistentes.AtualizarListaDeTarefas(tarefasAtualizadas);

        //Assert
        Assert.Collection(listaTarefasExistentes.Tarefas!,
            item => Assert.Equal(Status.CANCELADO, item.Status),
            item => Assert.Equal(Status.FINALIZADO, item.Status)
            );
        Assert.Collection(listaTarefasExistentes.Tarefas!,
            item => Assert.NotNull(item.DataAtualizacao),
            item => Assert.NotNull(item.DataAtualizacao)
            );
    }

    [Fact]
    [DisplayName("Cenário onde atualizam-se os campos Status e DataAtualização das tarefas existentes e, também, uma nova tarefa é inserida.")]
    public void Deve_Inserir_Uma_Nova_Tarefa_E_Tarefas_Existentes_Devem_Ser_Iguais_As_Tarefas_Atualizadas()
    {
        //Arrange
        ICollection<Tarefa> tarefasExistentes = new List<Tarefa>()
        {
            new Tarefa(1, "Tarefa_1", Status.INICIADO, DateTime.Now),
            new Tarefa(2, "Tarefa_2", Status.EM_ANDAMENTO, DateTime.Now)
        };
        var listaTarefasExistentes = new ListaTarefa(1, "Gabriel", tarefasExistentes);

        ICollection<Tarefa> tarefasAtualizadas = new List<Tarefa>()
            {
                new Tarefa(1, "Tarefa_1", Status.IMPEDIDO, DateTime.Now),
                new Tarefa(2, "Tarefa_2", Status.CANCELADO, DateTime.Now),
                new Tarefa(3, "Tarefa_3", Status.INICIADO, DateTime.Now)
            };

        //Act
        listaTarefasExistentes.AtualizarListaDeTarefas(tarefasAtualizadas);

        //Assert
        Assert.Collection(listaTarefasExistentes.Tarefas!,
            item => Assert.Equal(Status.IMPEDIDO, item.Status),
            item => Assert.Equal(Status.CANCELADO, item.Status),
            item => Assert.Equal(Status.INICIADO, item.Status)
            );
        Assert.Collection(listaTarefasExistentes.Tarefas!,
            item => Assert.NotNull(item.DataAtualizacao),
            item => Assert.NotNull(item.DataAtualizacao),
            item => Assert.Null(item.DataAtualizacao)
            );
    }
}