using AutoMapper;
using NoBleyzer.Models;
using NoBleyzer.Request.GameController;

namespace NoBleyzer.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<PostGame, Game>();
            CreateMap<PlayerAdditional, Player>();
        }
    }
}
