using System;
using System.Collections.Generic;

namespace Store.Domain.Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public int? CustomerId { get; set; }

    public int? GameId { get; set; }

    public int Quantity { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Game? Game { get; set; }
}
