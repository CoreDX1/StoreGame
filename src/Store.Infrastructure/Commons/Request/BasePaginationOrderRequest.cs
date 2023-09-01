namespace Store.Infrastructure.Commons.Request;

public class BasePaginationOrderRequest
{
    public string Order { get; set; } = "asc";

    public bool Records
    {
        get => Order == "asc";
        set => Order = value ? "asc" : "desc";
    }
}
