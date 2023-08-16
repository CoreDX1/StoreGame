using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure;
using Store.Infrastructure.Persistences.Interfaces;

namespace Store.Infrastructure.Persistences.Repository;

public class GameRepository : IGameRepository
{
    private readonly StoregameContext _context;

    public GameRepository(StoregameContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameDto>> ListGames()
    {
        var game = await _context.Games
            .Select(
                g =>
                    new GameDto
                    {
                        Title = g.Title,
                        DeveloperName = g.Developer!.Name,
                        PlatformName = g.Platform!.Name,
                        ReleaseDate = g.ReleaseDate,
                        Price = g.Price,
                        Stock = g.Stock,
                    }
            )
            .ToListAsync();
        return game;
    }
}
