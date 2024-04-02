using AutoMapper;
using Domain.DTO;
using Domain.Exceptions;
using Domain.Interfaces.Datas;
using Domain.Models;
using Moq;
using Service.Services;
using System.ComponentModel;

namespace Tests.Services;

public class ListaTarefaServiceTest
{
    [Fact]
    [DisplayName("Cenário que retorna uma exceção caso não encontre a lista de tarefas do usuário responsável.")]
    public async void Deve_Retornar_Uma_Excecao_Se_Nao_Encontrar_Lista_De_Tarefas_Do_Responsavel()
    {
        //Arrange
        var responsavel = "Gabriel";
        ICollection<TarefaRequestDto> tarefasAtualizadasDto = new List<TarefaRequestDto>();

        var listaTarefaAggregateRepositoryMock = new Mock<IListaTarefaAggregateRepository>();
        listaTarefaAggregateRepositoryMock.Setup(repo => repo.BuscarListaDeTarefasPorResponsavelAsync(It.IsAny<string>()))
            .ReturnsAsync((ListaTarefa)null!);

        var listaTarefaRepositoryMock = new Mock<IListaTarefaRepository>();
        var mapperMock = new Mock<IMapper>();

        var listaTarefaServiceMock = new ListaTarefaService(listaTarefaRepositoryMock.Object,
                                                            listaTarefaAggregateRepositoryMock.Object,
                                                            mapperMock.Object);

        //Act
        Func<Task> atualizarListaDeTarefasAsync = async () =>
        {
            await listaTarefaServiceMock.AtualizarListaDeTarefasAsync(responsavel, tarefasAtualizadasDto);
        };

        //Assert
        await Assert.ThrowsAsync<ListaDeTarefaNotFoundException>(() => atualizarListaDeTarefasAsync());
    }

    [Fact]
    [DisplayName("Cenário que verifica se o método AtualizarListaDeTarefasAsync foi alcançado.")]
    public async void Deve_Verificar_Se_O_Metodo_Que_Atualiza_Lista_De_Tarefas_Foi_Alcancado()
    {
        //Arrange
        var responsavel = "Gabriel";

        ICollection<Tarefa> tarefasExistentes = new List<Tarefa>();
        var listaTarefasExistentes = new ListaTarefa(1, "Gabriel", tarefasExistentes);

        ICollection<TarefaRequestDto> tarefasAtualizadasDto = new List<TarefaRequestDto>();

        var listaTarefaAggregateRepositoryMock = new Mock<IListaTarefaAggregateRepository>();
        listaTarefaAggregateRepositoryMock.Setup(repo => repo.BuscarListaDeTarefasPorResponsavelAsync(It.IsAny<string>()))
            .ReturnsAsync(listaTarefasExistentes);

        var listaTarefaRepositoryMock = new Mock<IListaTarefaRepository>();
        var mapperMock = new Mock<IMapper>();

        var listaTarefaServiceMock = new ListaTarefaService(listaTarefaRepositoryMock.Object,
                                                            listaTarefaAggregateRepositoryMock.Object,
                                                            mapperMock.Object);

        //Act
        await listaTarefaServiceMock.AtualizarListaDeTarefasAsync(responsavel, tarefasAtualizadasDto);

        //Assert
        listaTarefaAggregateRepositoryMock.Verify(m => m.AtualizarListaDeTarefasAsync());
    }
}