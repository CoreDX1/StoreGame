using AutoMapper;
using Store.Application.Commons.Bases;
using Store.Application.DTO.Game.Response;
using Store.Application.Interface;
using Store.Domain.Entities;
using Store.Infrastructure.Persistences.Interfaces;

namespace Store.Application.Services;

public class GameApplication : IGameApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GameApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GameTypeResponseDto>> GetById(int id)
    {
        var response = new BaseResponse<GameTypeResponseDto>();
        Game game = await _unitOfWork.Game.GetById(id);

        if (game is null)
        {
            response.IsSuccess = false;
            response.Message = "No se encontro el juego";
        }
        else
        {
            response.IsSuccess = true;
            response.Message = "Juego encontrado";
            response.Data = _mapper.Map<GameTypeResponseDto>(game);
        }

        return response;
    }

    public async Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetGameList()
    {
        var response = new BaseResponse<IEnumerable<GameTypeResponseDto>>();
        IEnumerable<Game> games = await _unitOfWork.Game.GetGemesQuery();

        if (games is null)
        {
            response.IsSuccess = false;
            response.Message = "No se encontraron juegos";
        }
        else
        {
            response.IsSuccess = true;
            response.Message = "Juegos encontrados";
            response.Data = _mapper.Map<IEnumerable<GameTypeResponseDto>>(games);
        }
        return response;
    }

    public async Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetNameOrder()
    {
        var response = new BaseResponse<IEnumerable<GameTypeResponseDto>>();
        IEnumerable<Game> games = await _unitOfWork.Game.GetNameOrder();
        if (games is null)
        {
            response.IsSuccess = false;
            response.Message = "No se encontraron juegos";
        }
        else
        {
            response.IsSuccess = true;
            response.Message = "Juegos encontrados";
            response.Data = _mapper.Map<IEnumerable<GameTypeResponseDto>>(games);
        }
        return response;
    }

    public async Task<BaseResponse<IEnumerable<GameTypeResponseDto>>> GetTitleQuery(string name)
    {
        var response = new BaseResponse<IEnumerable<GameTypeResponseDto>>();
        IEnumerable<Game> games = await _unitOfWork.Game.GetNameQuery(name);
        if (games is not null)
        {
            response.IsSuccess = true;
            response.Message = "Juegos encontrados";
            response.Data = _mapper.Map<IEnumerable<GameTypeResponseDto>>(games);
        }
        else
        {
            response.IsSuccess = false;
            response.Message = "No se encontraron juegos";
        }
        return response;
    }
}
