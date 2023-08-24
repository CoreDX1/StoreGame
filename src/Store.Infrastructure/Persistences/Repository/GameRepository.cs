using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure.Persistences.Interfaces;

namespace Store.Infrastructure.Persistences.Repository;

public class GameRepository : RepositoyBase<GameDto>, IGameRepository
{
    private readonly StoregameContext _dbContext;

    public GameRepository(StoregameContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetGemesQuery()
    {
        IQueryable<Game> query =
            from g in _dbContext.Games
            join p in _dbContext.Platforms on g.PlatformId equals p.PlatformId
            join d in _dbContext.Developers on g.DeveloperId equals d.DeveloperId
            select new Game
            {
                Title = g.Title,
                Description = g.Description,
                Developer = d,
                Platform = p,
                ReleaseDate = g.ReleaseDate,
                Price = g.Price,
                Stock = g.Stock,
                Imagen = g.Imagen
            };

        return await query.ToListAsync();
    }
}
