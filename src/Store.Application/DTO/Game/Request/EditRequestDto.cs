namespace Store.Application.DTO.Game.Request;

public record EditRequestDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int Price { get; set; }
}
