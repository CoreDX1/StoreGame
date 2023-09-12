namespace Store.Application.DTO.Game.Request;

public record FilterRequestDto(
    string? Order,
    string? Title,
    DateTime? RealeaseDateBefore,
    DateTime? RealeaseDateAfter,
    decimal? PriceMin,
    decimal? PriceMax,
    string? DeveloperName,
    string? PlatformName
);
