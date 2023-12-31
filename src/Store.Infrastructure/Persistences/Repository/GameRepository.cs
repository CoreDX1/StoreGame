using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure.Commons.Request;
using Store.Infrastructure.Persistences.Context;
using Store.Infrastructure.Persistences.Interfaces;

namespace Store.Infrastructure.Persistences.Repository;

public class GameRepository : GenericRepository<Game>, IGameRepository
{
    private readonly StoregameContext _dbContext;

    public GameRepository(StoregameContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    private IQueryable<Game> BaseGameQuery() =>
        _dbContext.Games.Include(g => g.Platform).Include(g => g.Developer);

    public async Task<IEnumerable<Game>> GetNameQuery(string name)
    {
        var game = _dbContext.Games
            .AsNoTracking()
            .Where(t => t.Title.ToLower().Contains(name.ToLower()))
            .Select(g => new Game { GameId = g.GameId, Title = g.Title });

        var gameList = await game.ToListAsync();

        if (!gameList.Any())
            return Enumerable.Empty<Game>();

        return gameList;
    }

    public async Task<IEnumerable<Game>> FilterGameAsync(GameFilterProductDto filterProductDto)
    {
        var game = BaseGameQuery().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(filterProductDto.Title))
            game = game.Where(x => x.Title.ToLower().Contains(filterProductDto.Title.ToLower()));

        if (filterProductDto.Records)
            game = game.OrderBy(x => x.Title);
        else
            game = game.OrderBy(x => x.GameId);

        if (
            filterProductDto.RealeaseDateBefore != null
            && filterProductDto.RealeaseDateAfter != null
        )
        {
            var releaseDateBefore = DateOnly.FromDateTime(
                filterProductDto.RealeaseDateBefore.Value
            );
            var releaseDateAfter = DateOnly.FromDateTime(filterProductDto.RealeaseDateAfter.Value);

            game = game.Where(
                product =>
                    product.ReleaseDate >= releaseDateAfter
                    && product.ReleaseDate <= releaseDateBefore
            );
        }

        if (filterProductDto.PriceMax != null)
            game = game.Where(
                product =>
                    product.Price >= filterProductDto.PriceMin
                    && product.Price <= filterProductDto.PriceMax
            );

        if (!string.IsNullOrWhiteSpace(filterProductDto.Developer))
            game = game.Where(name => name.Developer.Name == filterProductDto.Developer);

        if (!string.IsNullOrWhiteSpace(filterProductDto.Platform))
            game = game.Where(g => g.Title == filterProductDto.Platform);

        var gameList = await game.ToListAsync();

        if (!gameList.Any())
            return Enumerable.Empty<Game>();

        return game;
    }

    public override async Task<Game> GetByIdAsync(int id)
    {
        var game = await BaseGameQuery().AsNoTracking().FirstOrDefaultAsync(x => x.GameId == id);
        return game!;
    }

    public async Task<IEnumerable<Game>> GetGemesQuery()
    {
        var query = BaseGameQuery().OrderBy(x => x.GameId);
        var gamesList = await query.ToListAsync();

        if (!gamesList.Any())
            return Enumerable.Empty<Game>();

        return query;
    }

    public async Task<bool> EditGameAsync(Game data)
    {
        Game? game = await GetByIdAsync(data.GameId);

        if (game == null)
            return false;

        var editGame = new Game
        {
            GameId = game!.GameId,
            Title = data.Title,
            Price = data.Price
        };

        var entry = _dbContext.Entry(game);
        entry.CurrentValues.SetValues(editGame);

        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }
}
