using AutoMapper;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Models.Genre;
using BookStore.BLL.Queries.Genre;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Genre
{
    public class GetSubGenresHandler : IRequestHandler<GetSubGenresQuery,IEnumerable<GenreDto>>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;


        public GetSubGenresHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetSubGenresQuery request, CancellationToken cancellationToken = default)
        {
            var parentGenre = await _context.Genres
                .GetAsync(request.ParentGenreId , "ChildrenGenres");
            if (parentGenre == null)
            {
                throw new EntityDoesNotExistException("Genre with such id does not exist");
            }
            return _mapper.Map<IEnumerable<GenreDto>>(parentGenre.ChildrenGenres);
        }
    }
}
