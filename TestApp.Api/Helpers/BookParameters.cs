using System.ComponentModel.DataAnnotations;

namespace TestApp.Api.Helpers;

public class BookParameters
{
    public PagingParameters PagingParameters { get; set; } = new();

    [Range(1, 10_000, ErrorMessage = "Price can not be less than 1.")]
    public decimal MinimalPrice { get; set; } = decimal.Zero;

    [Range(1, 10_000, ErrorMessage = "Price can not be bigger than 10.000.")]
    public decimal MaximumPrice { get; set; } = 10_000m;

    [StringLength(30, MinimumLength = 0, ErrorMessage = "Name cannot be longer than 30 characters.")]
    public string? Name { get; set; } = string.Empty;

    public bool OrderByPriceAscending { get; set; } = false;
    
    public bool OrderByPriceDescending { get; set; } = false;
    
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