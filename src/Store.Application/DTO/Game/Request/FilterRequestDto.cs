namespace Store.Application.DTO.Game.Request;

public record FilterRequestDto
{
    public string? Order;
    public string? Title;
    public DateOnly? RealeaseDateBefore;
    public DateOnly? RealeaseDateAfter;
    public decimal? PriceMin;
    public decimal? PriceMax;
    public string? DeveloperName;
    public string? PlatformName;
}
