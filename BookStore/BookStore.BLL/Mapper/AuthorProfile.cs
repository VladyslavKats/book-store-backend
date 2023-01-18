using AutoMapper;
using BookStore.BLL.Models.Author;
using BookStore.DAL.Entities;

namespace BookStore.BLL.Mapper
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorEntity, AuthorDto>();
            CreateMap<AuthorCreateDto, AuthorEntity>();
        }
    }
}
