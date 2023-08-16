using Store.Application.Interface;
using Store.Domain.Entities;
using Store.Infrastructure.Persistences.Interfaces;
using Store.Infrastructure.Persistences.Repository;

namespace Store.Application.Services;

public class GameApplication : IGameApplication
{
    private readonly IUnitOfWork _unitOfWork;

    public GameApplication(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GameDto>> GetGameList()
    {
        var response = await _unitOfWork.Game.GetListOfGamesAsync();
        return response;
    }
}
