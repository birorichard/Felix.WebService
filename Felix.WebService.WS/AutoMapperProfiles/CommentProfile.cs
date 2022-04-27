using AutoMapper;
using Felix.WebService.Data.Models.Comment;
using Felix.WebService.DTO.Comment;
using Felix.WebService.Enums;
using System;

namespace Felix.WebService.WS.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.StartFrame, opt => opt.MapFrom(src => src.StartFrame))
                .ForMember(dest => dest.EndFrame, opt => opt.MapFrom(src => src.EndFrame))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedBy.UserName))
                .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy.Id))
                .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy.Name))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.ShotId, opt => opt.MapFrom(src => src.ShotCutRel.ShotId))
                ;

            CreateMap<CommentDTO, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.StartFrame, opt => opt.MapFrom(src => src.StartFrame))
                .ForMember(dest => dest.EndFrame, opt => opt.MapFrom(src => src.EndFrame))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedById))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom<PriorityResolver>())
                ;

            CreateMap<CreateCommentDTO, Comment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.StartFrame, opt => opt.MapFrom(src => src.Frame))
                .ForMember(dest => dest.EndFrame, opt => opt.MapFrom(src => src.Frame))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => CommentPriorityEnum.Medium))
                ;
        }

    }
}
