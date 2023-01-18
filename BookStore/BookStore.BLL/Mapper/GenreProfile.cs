using AutoMapper;
using BookStore.BLL.Models.Genre;
using BookStore.DAL.Entities;

namespace BookStore.BLL.Mapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreEntity, GenreDto>().ReverseMap();
            CreateMap<GenreCreateDto, GenreEntity>();
            CreateMap<GenreUpdateDto, GenreEntity>();
        }
    }
}
