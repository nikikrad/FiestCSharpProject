using AutoMapper;
using NoBleyzer.Models;
using NoBleyzer.Request.PCController;

namespace NoBleyzer.Mappings
{
    public class PCMapper: Profile
    {
        public PCMapper()
        {
            CreateMap<PostPC, PC>()
                .ForMember(

                dest => dest.Processor,
                opt => opt.MapFrom(src => $"{src.Processor}")
                )
                .ForMember(
                dest => dest.VideoCard,
                opt => opt.MapFrom(src => $"{src.VideoCard}")
                );
        }
    }
}
