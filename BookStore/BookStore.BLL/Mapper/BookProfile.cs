using AutoMapper;
using BookStore.BLL.Models.Book;
using BookStore.DAL.Entities;

namespace BookStore.BLL.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookEntity, BookDto>().ReverseMap();
            CreateMap<BookCreateDto, BookEntity>();
            CreateMap<BookUpdateDto, BookEntity>();
        }
    }
}
