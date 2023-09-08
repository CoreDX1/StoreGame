﻿using Store.Application.Commons.Bases;
using Store.Application.DTO.Game.Request;
using Store.Application.DTO.Game.Response;
using Store.Infrastructure.Commons.Request;

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
}
