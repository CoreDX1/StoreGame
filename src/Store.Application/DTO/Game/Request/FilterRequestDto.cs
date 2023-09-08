namespace Store.Application.DTO.Game.Request;

public record FilterRequestDto
{
    public string? Order { get; set; } = "asc";
    public string Title { get; set; } = string.Empty;
    public DateTime? RealeaseDateBefore { get; set; }
    public DateTime? RealeaseDateAfter { get; set; }
    public decimal? PriceMin { get; init; } = 0;
    public decimal? PriceMax { get; set; }
    public string DeveloperName { get; set; } = string.Empty;
    public string PlatformName { get; set; } = string.Empty;
}
