namespace Store.Infrastructure;

public interface IGenericRespository<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(int id);
    Task<bool> Add(TEntity entity);
    Task<bool> Update(TEntity entity);
    Task<bool> Delete(TEntity entity);
}
