using AutoMapper;
using Store.Domain.Entities;

namespace Store.Application.Mappers;

public class GameMappingsProfile : Profile
{
    public GameMappingsProfile()
    {
        CreateMap<Game, GameTypeResponseDto>()
            .ForMember(dest => dest.Developer, opt => opt.MapFrom(src => src.Developer!.Name))
            .ForMember(dest => dest.Platform, opt => opt.MapFrom(src => src.Platform!.Name));
    }
}
