using AutoMapper;
using BookStore.BLL.Commands.Genre;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Genre
{
    public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public UpdateGenreHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken = default)
        {
            var genre = await _context.Genres.GetAsync(request.Genre.Id);
            if (genre == null)
            {
                throw new EntityDoesNotExistException("Genre with such id does not exist");
            }
            var genreToUpdate = _mapper.Map<GenreEntity>(request.Genre);
            await _context.Genres.UpdateAsync(genreToUpdate);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
