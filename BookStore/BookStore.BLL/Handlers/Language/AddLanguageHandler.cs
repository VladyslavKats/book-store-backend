using AutoMapper;
using BookStore.BLL.Commands.Language;
using BookStore.BLL.Queries.Language;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Language
{
    public class AddLanguageHandler : IRequestHandler<AddLanguageCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public AddLanguageHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddLanguageCommand request, CancellationToken cancellationToken = default) 
        { 
            var language = _mapper.Map<LanguageEntity>(request.Language);
            await _context.Languages.AddAsync(language);
            await _context.CommitAsync();
            return Unit.Value;
        }
    }
}
