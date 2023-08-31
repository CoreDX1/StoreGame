using Microsoft.EntityFrameworkCore;

namespace Store.Infrastructure.Persistences.Repository;

public class GenericRepository<TEntity> : IGenericRespository<TEntity>
    where TEntity : class
{
    private readonly StoregameContext _db;
    private readonly DbSet<TEntity> _entity;

    public GenericRepository(StoregameContext dbContext)
    {
        _db = dbContext;
        _entity = _db.Set<TEntity>();
    }

    public Task<bool> Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        var getAll = await _entity.ToListAsync();
        return getAll;
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        var getById = await _entity.FindAsync(id);
        return getById!;
    }

    public Task<bool> Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
