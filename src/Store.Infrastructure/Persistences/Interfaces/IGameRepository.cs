using Store.Domain.Entities;
using Store.Infrastructure.Commons.Request;

namespace Store.Infrastructure.Persistences.Interfaces;

public interface IGameRepository : IGenericRespository<Game>
{
    public Task<IEnumerable<Game>> GetGemesQuery();
    public Task<IEnumerable<Game>> GetNameQuery(string name);
    public Task<IEnumerable<Game>> GetNameOrder(BasePaginationOrderRequest orderRequest);
    public Task<IEnumerable<Game>> PostFilter(GameFilterProductDto filterProductDto);
}
