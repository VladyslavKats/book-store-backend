using AutoMapper;
using BookStore.BLL.Commands.Book;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Queries.Book;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Book
{
    public class DeleteBookByIdHandler : IRequestHandler<DeleteBookByIdCommand, Unit>
    {
        private readonly IBookStoreUW _context;

        public DeleteBookByIdHandler(IBookStoreUW context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken = default)
        {
            var bookExists = await _context.Books.GetAsync(request.Id);
            if (bookExists == null)
            {
                throw new EntityDoesNotExistException("Book with such id does not exist");
            }
            await _context.Books.DeleteAsync(request.Id);
            await _context.CommitAsync();
            return Unit.Value;
        }
    }
}
