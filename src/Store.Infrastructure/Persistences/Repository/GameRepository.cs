using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure.Commons.Request;
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
        var query = BaseGameQuery();
        var games = query.Where(x => x.Title.ToLower().Contains(name.ToLower()));

        if (games.Count() == 0)
        {
            return null!;
        }

        return await games.ToListAsync();
    }

    public async Task<IEnumerable<Game>> FilterGameAsync(GameFilterProductDto filterProductDto)
    {
        var game = BaseGameQuery();

        if (!string.IsNullOrWhiteSpace(filterProductDto.Title))
        {
            game = game.Where(x => x.Title.ToLower().Contains(filterProductDto.Title.ToLower()));
        }

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

        if (filterProductDto.PriceMax != null && filterProductDto.PriceMin != null)
        {
            game = game.Where(
                product =>
                    product.Price >= filterProductDto.PriceMin
                    && product.Price <= filterProductDto.PriceMax
            );
        }

        if (!string.IsNullOrWhiteSpace(filterProductDto.Developer))
        {
            game = game.Where(name => name.Developer!.Name == filterProductDto.Developer);
        }

        if (!string.IsNullOrWhiteSpace(filterProductDto.Platform))
        {
            game = game.Where(name => name.Title == filterProductDto.Platform);
        }

        var result = await game.ToListAsync();
        return result.Count > 0 ? result : null!;
    }

    public async Task<IEnumerable<Game>> GetTitleQuery(string name)
    {
        IQueryable<Game> game = _dbContext.Games.Where(
            t => t.Title.ToLower().Contains(name.ToLower())
        );
        return await game.ToListAsync();
    }

    public override async Task<Game> GetByIdAsync(int id)
    {
        var game = await BaseGameQuery().FirstOrDefaultAsync(x => x.GameId == id);
        return game!;
    }

    public async Task<IEnumerable<Game>> GetGemesQuery()
    {
        var query = BaseGameQuery().OrderBy(x => x.GameId);
        return await query.ToListAsync();
    }

    public async Task<bool> EditGameAsync(Game data)
    {
        var game = await GetByIdAsync(data.GameId);
        game!.Title = data.Title;
        game.Price = data.Price;
        _dbContext.Update(game);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }
}
