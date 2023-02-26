using AutoMapper;
using Store.Application.Models.Comments;
using Store.Domain.Entities;
using Store.Domain.Identity;

namespace Store.Application.Common.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentItemDto>();

            CreateMap<CreateCommentDto, Comment>();

        }
    }
}
