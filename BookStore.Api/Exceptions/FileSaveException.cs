namespace BookStore.Api.Exceptions;

public class FileSaveException : IOException
{
    public FileSaveException()
    {
    }

    public FileSaveException(string message)
        : base(message)
    {
    }

    public FileSaveException(string message, Exception inner)
        : base(message, inner)
    {
    }
}