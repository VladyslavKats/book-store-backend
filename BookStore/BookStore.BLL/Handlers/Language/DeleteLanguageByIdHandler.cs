using BookStore.BLL.Commands.Language;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Queries.Language;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Language
{
    public class DeleteLanguageByIdHandler : IRequestHandler<DeleteLanguageByIdCommand, Unit>
    {
        private readonly IBookStoreUW _context;
      
        public DeleteLanguageByIdHandler(IBookStoreUW context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLanguageByIdCommand request, 
            CancellationToken cancellationToken = default)
        {
            var languageExist = await _context.Languages.GetAsync(request.Id);
            if (languageExist == null)
            {
                throw new EntityDoesNotExistException("Language with such id does not exist");
            }
            await _context.Languages.DeleteAsync(request.Id);
            await _context.CommitAsync();
            return Unit.Value;
        }
    }
}
