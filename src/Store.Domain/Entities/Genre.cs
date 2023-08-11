using System;
using System.Collections.Generic;

namespace Store.Domain.Entities;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Game> Games { get; } = new List<Game>();
}
