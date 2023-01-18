using AutoMapper;
using BookStore.BLL.Commands.Genre;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Genre
{
    public class AddGenreHandler : IRequestHandler<AddGenreCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public AddGenreHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddGenreCommand request, CancellationToken cancellationToken = default)
        {
            var genre = _mapper.Map<GenreEntity>(request.Genre);
            await CheckParentGenreExist(genre);
            await _context.Genres.AddAsync(genre);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }

        private async Task CheckParentGenreExist(GenreEntity genre)
        {
            if (!string.IsNullOrEmpty(genre.ParentGenreId))
            {
                var parent = await _context.Genres.GetAsync(genre.ParentGenreId);
                if (parent == null)
                {
                    throw new EntityDoesNotExistException("Parent genre with such id does not exist");
                }
            }
        }
    }
}
