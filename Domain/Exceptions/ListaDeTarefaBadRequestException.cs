namespace Domain.Exceptions;

public class ListaDeTarefaBadRequestException : Exception
{
    public ListaDeTarefaBadRequestException() :
        base()
    { }

    public ListaDeTarefaBadRequestException(string message) :
        base(message)
    { }

    public ListaDeTarefaBadRequestException(string message, Exception innerException) :
        base(message, innerException)
    { }
}