namespace Store.Domain.Entities;

public partial class Developer
{
    public int DeveloperId { get; set; }

    public string? Name { get; set; } = null!;

    public string? Website { get; set; }

    public virtual ICollection<Game> Games { get; } = new List<Game>();
}
