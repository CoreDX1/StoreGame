namespace Store.Application.DTO.Game.Request;

public class FilterRequestDto
{
    public string? Order { get; set; }
    public string Search { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public DateOnly? RealeaseDateBefore { get; set; }
    public DateOnly? RealeaseDateAfter { get; set; }
    public decimal? PriceMin { get; set; }
    public decimal? PriceMax { get; set; }
    public string DeveloperName { get; set; } = string.Empty;
    public string PlatformName { get; set; } = string.Empty;
}
