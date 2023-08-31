using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Interfaces;

public interface IGameRepository : IGenericRespository<Game>
{
    public Task<IEnumerable<Game>> GetGemesQuery();
    public Task<IEnumerable<Game>> GetNameQuery(string name);
    public Task<IEnumerable<Game>> GetNameOrder();
}
