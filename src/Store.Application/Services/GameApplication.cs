using AutoMapper;

using Store.Application.Commons.Bases;
using Store.Application.DTO.Game.Request;
using Store.Application.DTO.Game.Response;
using Store.Application.Interface;
using Store.Domain.Entities;
using Store.Infrastructure.Commons.Request;
using Store.Infrastructure.Persistences.Interfaces;
using Store.Utilities.Static;

namespace Store.Application.Services;

public class GameApplication : IGameApplication
{
    // Declaracion de dos campos privados de una clase
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GameApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GameTypeResponseDto>> GameByIdAsync(int id)
    {
        var response = new BaseResponse<GameTypeResponseDto>();
        var game = await _unitOfWork.Game.GetByIdAsync(id);

        if (game is null)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
        }
        else
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_QUERY;
            response.Data = _mapper.Map<GameTypeResponseDto>(game);
        }

        return response;
    }

    public async Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GameListAsync()
    {
        var response = new BaseResponse<IEnumerable<GameTypeResponseDto>>();
        IEnumerable<Game> games = await _unitOfWork.Game.GetGemesQuery();

        if (games is null)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
        }
        else
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_QUERY;
            response.Data = _mapper.Map<IEnumerable<GameTypeResponseDto>>(games);
        }

        return response;
    }

    public async Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> FilterGamesAsync(
        FilterRequestDto filterProductDto
    )
    {
        var response = new BaseResponse<IEnumerable<GameTypeResponseDto>>();
        var filter = _mapper.Map<GameFilterProductDto>(filterProductDto);
        var games = await _unitOfWork.Game.FilterGameAsync(filter);

        if (games is not null)
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_QUERY;
            response.Data = _mapper.Map<IEnumerable<GameTypeResponseDto>>(games);
        }
        else
        {
            response.IsSuccess = false;
            response.Message = "No se encontraron juegos";
        }

        return response;
    }

    public async Task<BaseResponse<IEnumerable<GameSearchReponseDto>>> GetTitleQuery(string name)
    {
        var response = new BaseResponse<IEnumerable<GameSearchReponseDto>>();
        var games = await _unitOfWork.Game.GetNameQuery(name);

        if (games is null)
        {
            response.IsSuccess = false;
            response.Message = "No se encontraron juegos";
            return response;
        }
        else
        {
            response.IsSuccess = true;
            response.Message = "Juegos encontrados";
            response.Data = _mapper.Map<IEnumerable<GameSearchReponseDto>>(games);
        }

        return response;
    }

    public async Task<BaseResponse<bool>> EditGameAsync(int gameId, EditRequestDto data)
    {
        var response = new BaseResponse<bool>();
        var gameById = await GameByIdAsync(gameId);

        if (gameById.Data is null)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            return response;
        }

        var game = _mapper.Map<Game>(data);
        game.GameId = gameId;
        response.Data = await _unitOfWork.Game.EditGameAsync(game);

        if (!response.Data)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
        }
        else
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }

        return response;
    }
}
