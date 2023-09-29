namespace Store.Application.Commons.Bases;

public class BaseResponse<T>
{
    private T? _data;
    public bool IsSuccess { get; set; }
    public T? Data
    {
        get { return _data; }
        set
        {
            _data = value;
            Total = CalculateTotal();
        }
    }
    public int Total { get; private set; }
    public string? Message { get; set; }

    private int CalculateTotal()
    {
        if (Data == null)
        {
            return 0;
        }

        if (Data is IEnumerable<Object> enumerable)
        {
            return enumerable.Count();
        }

        return 1;
    }
}
