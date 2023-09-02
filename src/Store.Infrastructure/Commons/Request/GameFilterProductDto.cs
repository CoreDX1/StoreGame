namespace Store.Infrastructure.Commons.Request;

public class GameFilterProductDto
{
    public string? Order { get; set; } = "asc";
    public string Search { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public DateTime? RealeaseDateBefore { get; set; }
    public DateTime? RealeaseDateAfter { get; set; }
    public decimal? PriceMin { get; set; }
    public decimal? PriceMax { get; set; }
    public string DeveloperName { get; set; } = string.Empty;
    public string PlatformName { get; set; } = string.Empty;

    public bool Records
    {
        get => Order == "asc";
        set => Order = value ? "asc" : "desc";
    }
}
