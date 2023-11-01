using Store.Domain.Entities;
using Store.Infrastructure.Commons.Request;

namespace Store.Infrastructure.Persistences.Interfaces;

public interface IGameRepository : IGenericRespository<Game>
{
    Task<IEnumerable<Game>> GetGemesQuery();
    Task<IEnumerable<Game>> FilterGameAsync(GameFilterProductDto filterProductDto);
    Task<IEnumerable<Game>> GetNameQuery(string name);
    Task<bool> EditGameAsync(Game data);
}
