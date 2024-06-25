namespace TestApp.Api.Helpers;

public class PagedList<T> : List<T>
{
    public int TotalPages { get; }

    public PagedList(IEnumerable<T> items, int count, int pageSize)
    {
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        
        AddRange(items);
    }
}