namespace Domain.Exceptions;

public class ListaDeTarefaNotFoundException : Exception
{
    public ListaDeTarefaNotFoundException() :
        base()
    { }

    public ListaDeTarefaNotFoundException(string message) :
        base(message)
    { }

    public ListaDeTarefaNotFoundException(string message, Exception innerException) :
        base(message, innerException)
    { }
}