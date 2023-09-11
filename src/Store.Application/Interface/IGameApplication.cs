using Store.Application.Commons.Bases;
using Store.Application.DTO.Game.Request;
using Store.Application.DTO.Game.Response;

namespace Store.Application.Interface;

public interface IGameApplication
{
    /// <summary>
    /// Gets a list of games.
    /// </summary>
    Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GameListAsync();
    Task<BaseResponse<GameTypeResponseDto>> GameByIdAsync(int id);
    Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> FilterGamesAsync(
        FilterRequestDto filterProductDto
    );

    Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetTitleQuery(string name);
    Task<BaseResponse<bool>> EditGameAsync(int gameId, EditRequestDto data);
}
