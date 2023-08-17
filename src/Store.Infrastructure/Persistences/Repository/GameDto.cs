namespace Store.Infrastructure.Persistences.Repository;

public class GameDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? DeveloperName { get; set; }
    public string? PlatformName { get; set; }
    public string? LinkGame { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
}
