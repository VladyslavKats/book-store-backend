using AutoMapper;
using BookStore.BLL.Models.Language;
using BookStore.BLL.Queries.Language;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Language
{
    public class GetAllLanguagesHandler : IRequestHandler<GetAlllanguagesQuery, IEnumerable<LanguageDto>>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetAllLanguagesHandler(IBookStoreUW context , IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<LanguageDto>> Handle(GetAlllanguagesQuery request, 
            CancellationToken cancellationToken = default)
        {
            var languages = await _context.Languages.GetAllAsync();
            return _mapper.Map<IEnumerable<LanguageDto>>(languages);
        }
    }
}
