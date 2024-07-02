namespace BookStore.Api.Exceptions;

public class FileDeleteException : IOException
{
    public FileDeleteException()
    {
    }

    public FileDeleteException(string message)
        : base(message)
    {
    }

    public FileDeleteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}