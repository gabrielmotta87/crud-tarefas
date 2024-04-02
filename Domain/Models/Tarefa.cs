using Domain.Models.Enums;

namespace Domain.Models;

public class Tarefa
{
    public Tarefa()
    { }

    public Tarefa(int id, string? nome, Status status, DateTime dataCriacao)
    {
        Id = id;
        Nome = nome;
        Status = status;
        DataCriacao = dataCriacao;
    }

    public int Id { get; private set; }
    public string? Nome { get; private set; }
    public Status Status { get; private set; }
    public DateTime DataCriacao { get; } = DateTime.Now;
    public DateTime? DataAtualizacao { get; private set; }
    public ListaTarefa? ListaTarefa { get; private set; }

    public void SetDataAtualizacao(DateTime dataAtualizacao) =>
        DataAtualizacao = dataAtualizacao;

    public void SetStatus(Status status) =>
        Status = status;
}