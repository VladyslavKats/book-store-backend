using AutoMapper;
using BookStore.BLL.Commands.Genre;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Genre
{
    public class DeleteGenreByIdHandler : IRequestHandler<DeleteGenreByIdCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public DeleteGenreByIdHandler(IMapper mapper, IBookStoreUW context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGenreByIdCommand request, CancellationToken cancellationToken = default)
        {
            var genre = await _context.Genres.GetAsync(request.Id);
            if (genre == null)
            {
                throw new EntityDoesNotExistException("Genre with such id does not exist");
            }
            await _context.Genres.DeleteAsync(genre);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
