using AutoMapper;
using BookStore.BLL.Handlers.Book;
using BookStore.BLL.Models.Book;

namespace BookStore.API.Mapper
{
    public class BookModelProfile : Profile
    {
        public BookModelProfile()
        {
            CreateMap<BookDto, BookGetModel>();
        }
    }
}
