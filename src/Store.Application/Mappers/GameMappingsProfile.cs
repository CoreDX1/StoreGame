using AutoMapper;
using Store.Application.DTO.Game.Request;
using Store.Application.DTO.Game.Response;
using Store.Domain.Entities;
using Store.Infrastructure.Commons.Request;

namespace Store.Application.Mappers;

public class GameMappingsProfile : Profile
{
    public GameMappingsProfile()
    {
        CreateMap<Game, GameTypeResponseDto>()
            .ForMember(dest => dest.Developer, opt => opt.MapFrom(src => src.Developer!.Name))
            .ForMember(dest => dest.Platform, opt => opt.MapFrom(src => src.Platform!.Name))
            .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Developer!.Website))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GameId))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Imagen));

        CreateMap<OrderRequestDto, BasePaginationOrderRequest>();
        CreateMap<FilterRequestDto, GameFilterProductDto>();
    }
}
