using AutoMapper;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Models.Language;
using BookStore.BLL.Queries.Language;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Language
{
    public class GetLanguageByIdHandler : IRequestHandler<GetLanguageByIdQuery,LanguageDto>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetLanguageByIdHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LanguageDto> Handle(GetLanguageByIdQuery request,
            CancellationToken cancellationToken = default)
        {
            var language = await _context.Languages.GetAsync(request.Id);
            if (language == null)
            {
                throw new EntityDoesNotExistException("Language with such id does not exist");
            }
            return _mapper.Map<LanguageDto>(language);
        }
    }
}
