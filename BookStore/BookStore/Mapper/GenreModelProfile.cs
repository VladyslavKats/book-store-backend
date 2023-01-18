using AutoMapper;
using BookStore.API.Models;
using BookStore.BLL.Models.Genre;

namespace BookStore.API.Mapper
{
    public class GenreModelProfile : Profile
    {
        public GenreModelProfile()
        {
            CreateMap<GenreDto, GenreGetModel>();
        }
    }
}
