using Store.Application.Commons.Bases;
using Store.Application.DTO.Game.Request;
using Store.Application.DTO.Game.Response;

namespace Store.Application.Interface;

public interface IGameApplication
{
    public Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetGameList();
    public Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetTitleQuery(string name);
    public Task<BaseResponse<GameTypeResponseDto>> GetById(int id);
    public Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetNameOrder(OrderRequestDto order);
}
