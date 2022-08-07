using AutoMapper;
using NoBleyzer.Models;
using NoBleyzer.Request.PlayerController;

namespace NoBleyzer.Mappings
{
    public class PlayerProfile: Profile
    {
        public PlayerProfile()
        {
            CreateMap<PostPlayer, Player>()
                .ForMember(
                dest => dest.Nickname,
                opt => opt.MapFrom(src => $"{src.Nickname}")
                );
        }
    }
}
