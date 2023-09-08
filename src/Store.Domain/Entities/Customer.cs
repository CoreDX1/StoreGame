namespace Store.Domain.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();
}
