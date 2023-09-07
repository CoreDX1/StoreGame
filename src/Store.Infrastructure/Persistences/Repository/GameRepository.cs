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

    private IQueryable<Game> BaseGameQuery()
    {
        return from g in _dbContext.Games
            join p in _dbContext.Platforms on g.PlatformId equals p.PlatformId
            join d in _dbContext.Developers on g.DeveloperId equals d.DeveloperId
            select new Game
            {
                GameId = g.GameId,
                Title = g.Title,
                Description = g.Description,
                Developer = d,
                Platform = p,
                ReleaseDate = g.ReleaseDate,
                Price = g.Price,
                Stock = g.Stock,
                Imagen = g.Imagen
            };
    }

    public override async Task<Game> GetById(int id)
    {
        var game = await BaseGameQuery().FirstOrDefaultAsync(x => x.GameId == id);
        return game!;
    }

    public async Task<IEnumerable<Game>> GetNameOrder(BasePaginationOrderRequest orderRequest)
    {
        IQueryable<Game> games = BaseGameQuery();

        if (orderRequest.Records)
            games = games.OrderBy(x => x.Title);
        else
            games = games.OrderBy(x => x.GameId);

        return await games.ToListAsync();
    }

    public async Task<IEnumerable<Game>> GetGemesQuery()
    {
        var query = BaseGameQuery().OrderBy(x => x.GameId);
        return await query.ToListAsync();
    }

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

    public async Task<IEnumerable<Game>> Filter(GameFilterProductDto filterProductDto)
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

        if (!string.IsNullOrWhiteSpace(filterProductDto.DeveloperName))
        {
            game = game.Where(name => name.Developer!.Name == filterProductDto.DeveloperName);
        }

        if (!string.IsNullOrWhiteSpace(filterProductDto.PlatformName))
        {
            game = game.Where(name => name.Title == filterProductDto.PlatformName);
        }

        var result = await game.ToListAsync();
        return result.Count > 0 ? result : null!;
    }
}
