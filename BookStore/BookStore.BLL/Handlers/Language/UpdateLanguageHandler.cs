using AutoMapper;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Commands.Language;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Language
{
    public class UpdateLanguageHandler : IRequestHandler<UpdateLanguageCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public UpdateLanguageHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLanguageCommand request, 
            CancellationToken cancellationToken = default)
        {
            var languageExist = _context.Languages.GetAsync(request.Language.Id);
            if (languageExist == null)
            {
                throw new EntityDoesNotExistException("Language with such id does not exist");
            }
            var language = _mapper.Map<LanguageEntity>(request.Language);
            await _context.Languages.UpdateAsync(language);
            await _context.CommitAsync();
            return Unit.Value;
        }
    }
}
