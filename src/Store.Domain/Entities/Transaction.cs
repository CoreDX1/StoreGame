namespace Store.Domain.Entities;

public partial class Transaction
{
    public int? GameId { get; set; }
    public int TransactionId { get; set; }
    public int? CustomerId { get; set; }
    public DateOnly? TransactionDate { get; set; }
    public decimal TotalAmount { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Game? Game { get; set; }
}
