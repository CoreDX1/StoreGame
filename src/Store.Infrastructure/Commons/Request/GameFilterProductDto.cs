namespace Store.Infrastructure.Commons.Request;

public class GameFilterProductDto
{
    public string? Order { get; set; }
    public string Search { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public DateTime? RealeaseDateBefore { get; set; }
    public DateTime? RealeaseDateAfter { get; set; }
    public decimal? PriceMin { get; set; }
    public decimal? PriceMax { get; set; }
    public string Developer { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;

    public bool Records
    {
        set => Order = value ? "asc" : "desc";
        get => Order == "asc";
    }
}
