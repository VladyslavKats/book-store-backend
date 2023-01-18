using AutoMapper;
using BookStore.BLL.Models.Language;
using BookStore.Models;

namespace BookStore.Profiles
{
    public class LanguageModelProfile : Profile
    {
        public LanguageModelProfile()
        {
            CreateMap<LanguageDto, LanguageGetModel>();
        }
    }
}
