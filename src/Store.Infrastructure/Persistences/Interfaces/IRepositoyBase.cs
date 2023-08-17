namespace Store.Infrastructure;

public interface IRepositoyBase<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
}
