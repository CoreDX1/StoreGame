﻿namespace Store.Application.DTO.Game.Response;

public class GameTypeResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Imagen { get; set; }
    public string? DeveloperName { get; set; }
    public string? PlatformName { get; set; }
    public string? Website { get; set; }
}
