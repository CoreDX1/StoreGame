namespace Store.Infrastructure.Commons.Response;

public record GameSearchResponseDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Website { get; set; }
}
