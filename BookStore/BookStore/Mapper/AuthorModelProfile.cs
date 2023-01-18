using AutoMapper;
using BookStore.API.Models;
using BookStore.BLL.Models.Author;
using BookStore.DAL.Entities;

namespace BookStore.API.Mapper
{
    public class AuthorModelProfile : Profile
    {
        public AuthorModelProfile()
        {
            CreateMap<AuthorDto, AuthorGetModel>();
            CreateMap<AuthorUpdateDto, AuthorEntity>();
        }
    }
}
