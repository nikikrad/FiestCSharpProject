using AutoMapper;
using NoBleyzer.Models;
using NoBleyzer.Request.GameController;

namespace NoBleyzer.Mappings
{
    public class GameMapper : Profile
    {
        public GameMapper()
        {
            CreateMap<PostGame, Game>()
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => $"{src.Title}")
                    )
                .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => $"{src.Price}")
                );
        }

    }
}
