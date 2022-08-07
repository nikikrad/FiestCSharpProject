using AutoMapper;
using NoBleyzer.Models;
using NoBleyzer.Request.OSController;

namespace NoBleyzer.Mappings

{
    public class OSProfiler:Profile
    {
        public OSProfiler()
        {
            CreateMap<PostOS, OS>()
                .ForMember(
                dest => dest.NameOS,
                opt => opt.MapFrom(src => $"{src.NameOS}")
                );
        }   
    }
}
