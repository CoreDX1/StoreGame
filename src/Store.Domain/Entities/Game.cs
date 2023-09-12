namespace Store.Domain.Entities;

/// <summary>
/// Entidad de la tabla Game
/// </summary>
public partial class Game
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
    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
    public virtual Developer Developer { get; set; } = new Developer();
    public virtual Platform? Platform { get; set; }
    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();
    public virtual ICollection<Genre> Genres { get; } = new List<Genre>();
}
