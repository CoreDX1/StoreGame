using Microsoft.EntityFrameworkCore;

namespace Store.Infrastructure.Persistences.Repository;

public class RepositoyBase<TEntity> : IRepositoyBase<TEntity>
    where TEntity : class
{
    private readonly StoregameContext _db;
    private readonly DbSet<TEntity> _entity;

    public RepositoyBase(StoregameContext dbContext)
    {
        _db = dbContext;
        _entity = _db.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        var getAll = await _entity.ToListAsync();
        return getAll;
    }
}
