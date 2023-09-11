using Store.Domain.Entities;
using Store.Infrastructure.Commons.Request;

namespace Store.Infrastructure.Persistences.Interfaces;

public interface IGameRepository : IGenericRespository<Game>
{
    public Task<IEnumerable<Game>> GetGemesQuery();
    public Task<IEnumerable<Game>> FilterGameAsync(GameFilterProductDto filterProductDto);
    public Task<IEnumerable<Game>> GetNameQuery(string name);
    Task<bool> EditGameAsync(Game data);
}
