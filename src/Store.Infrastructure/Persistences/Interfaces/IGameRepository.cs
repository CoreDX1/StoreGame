using Store.Domain.Entities;
using Store.Infrastructure.Persistences.Repository;

namespace Store.Infrastructure.Persistences.Interfaces;

public interface IGameRepository : IRepositoyBase<GameDto>
{
    public Task<IEnumerable<Game>> GetGemesQuery();
}
