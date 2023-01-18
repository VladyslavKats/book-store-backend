using AutoMapper;
using BookStore.BLL.Models.Publisher;
using BookStore.DAL.Entities;

namespace BookStore.BLL.Mapper
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<PublisherEntity,PublisherDto>();
            CreateMap<PublisherCreateDto, PublisherEntity>();
            CreateMap<PublisherUpdateDto, PublisherEntity>();
        }
    }
}
