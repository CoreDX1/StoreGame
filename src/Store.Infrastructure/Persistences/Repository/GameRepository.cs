using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure;
using Store.Infrastructure.Persistences.Interfaces;

namespace Store.Infrastructure.Persistences.Repository;

public class GameRepository : IGameRepository
{
    private readonly StoregameContext _dbContext;

    public GameRepository(StoregameContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GameDto>> GetListOfGamesAsync()
    {
        var gameList = await _dbContext.Games
            .Select(
                gameEntity =>
                    new GameDto
                    {
                        Title = gameEntity.Title,
                        DeveloperName = gameEntity.Developer!.Name,
                        PlatformName = gameEntity.Platform!.Name,
                        ReleaseDate = gameEntity.ReleaseDate,
                        Price = gameEntity.Price,
                        Stock = gameEntity.Stock,
                    }
            )
            .ToListAsync();
        return gameList;
    }
}
