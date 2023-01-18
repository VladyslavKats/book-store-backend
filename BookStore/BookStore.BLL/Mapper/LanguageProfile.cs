using AutoMapper;
using BookStore.BLL.Models.Language;
using BookStore.DAL.Entities;

namespace BookStore.BLL.Mapper
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageEntity, LanguageDto>().ReverseMap();
            CreateMap<LanguageCreateDto, LanguageEntity>();
            CreateMap<LanguageUpdateDto, LanguageEntity>();
        }
    }
}
