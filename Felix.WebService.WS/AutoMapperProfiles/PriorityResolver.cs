using AutoMapper;
using Felix.WebService.Data.Models.Comment;
using Felix.WebService.DTO.Comment;
using Felix.WebService.Enums;

namespace Felix.WebService.WS.AutoMapperProfiles
{
    public class PriorityResolver : IValueResolver<CommentDTO, Comment, CommentPriorityEnum>
    {
        public CommentPriorityEnum Resolve(CommentDTO source, Comment destination, CommentPriorityEnum destMember, ResolutionContext context)
        {
            switch (source.Priority)
            {
                case "High":
                    return CommentPriorityEnum.High;
                case "Medium":
                    return CommentPriorityEnum.Medium;
                case "Low":
                    return CommentPriorityEnum.Low;
                default:
                    return CommentPriorityEnum.Undefined;
            }
        }
    }
}
