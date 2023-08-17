using Microsoft.EntityFrameworkCore;
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

    public override async Task<IEnumerable<GameDto>> GetAll()
    {
        return await _dbContext.Games
            .Select(
                gameEntity =>
                    new GameDto
                    {
                        Title = gameEntity.Title,
                        DeveloperName = gameEntity.Developer!.Name,
                        PlatformName = gameEntity.Platform!.Name,
                        Description = gameEntity.Description,
                        ReleaseDate = gameEntity.ReleaseDate,
                        Price = gameEntity.Price,
                        Stock = gameEntity.Stock,
                    }
            )
            .ToListAsync();
    }
}
