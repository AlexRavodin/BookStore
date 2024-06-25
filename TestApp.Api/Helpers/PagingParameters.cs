namespace TestApp.Api.Helpers;

public class PagingParameters
{
    private const int MinPageSize = 1;
        
    private const int MaxPageSize = 30;
        
    private int _pageSize = 10;
        
    private int _pageIndex = 1;

    public int PageSize
    {
        get => _pageSize;
        set
        {
            _pageSize = value switch
            {
                < MinPageSize => MinPageSize,
                > MaxPageSize => MaxPageSize,
                _ => value
            };
        }
    }

    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value < 1 ? 1 : value;
    }
}