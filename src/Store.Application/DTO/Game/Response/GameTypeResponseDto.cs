namespace Store.Application;

public class GameTypeResponseDto
{
    public int GameId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int? DeveloperId { get; set; }
    public int? PlatformId { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Imagen { get; set; }
    public string? Developer { get; set; }
    public string? Platform { get; set; }
}
