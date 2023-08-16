using Store.Infrastructure.Persistences.Repository;

namespace Store.Application.Interface;

public interface IGameApplication
{
    public Task<IEnumerable<GameDto>> ListGames();
}
