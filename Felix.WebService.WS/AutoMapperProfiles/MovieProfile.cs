using AutoMapper;
using Felix.WebService.Data.Models.Movie;
using Felix.WebService.DTO.Movie;
using System.Linq;

namespace Felix.WebService.WS.AutoMapperProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Cut, CutDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LengthInFrames, opt => opt.Ignore())
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.ShotCount, opt => opt.MapFrom(src => src.ShotCutRels.Count))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                .ForMember(dest => dest.Shots, opt => opt.MapFrom(src => src.ShotCutRels.Select(x => x.Shot)))
                ;
            
            CreateMap<Shot, ShotDTO>().ReverseMap();
        }
    }
}
