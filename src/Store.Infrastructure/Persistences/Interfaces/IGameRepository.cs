using Store.Infrastructure.Persistences.Repository;

namespace Store.Infrastructure.Persistences.Interfaces;

public interface IGameRepository
{
    public Task<IEnumerable<GameDto>> GetListOfGamesAsync();
}
