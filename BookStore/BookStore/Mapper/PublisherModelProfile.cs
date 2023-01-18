using AutoMapper;
using BookStore.API.Models;
using BookStore.BLL.Models.Publisher;

namespace BookStore.API.Mapper
{
    public class PublisherModelProfile : Profile
    {
        public PublisherModelProfile()
        {
            CreateMap<PublisherDto, PublisherGetModel>();
        }
    }
}
