using Store.Application.Commons.Bases;
using Store.Domain.Entities;

namespace Store.Application.Interface;

public interface IGameApplication
{
    public Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetGameList();
}
