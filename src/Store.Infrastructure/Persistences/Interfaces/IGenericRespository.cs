namespace Store.Infrastructure;

public interface IGenericRespository<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> EditAsync(TEntity entity);
    Task<bool> RemoveAsync(TEntity entity);
}
