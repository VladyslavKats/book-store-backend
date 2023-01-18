using AutoMapper;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Models.Genre;
using BookStore.BLL.Queries.Genre;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Genre
{
    public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery,GenreDto>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetGenreByIdHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken = default)
        {
            var genre = await _context.Genres.GetAsync(request.Id);
            if (genre == null)
            {
                throw new EntityDoesNotExistException("Genre with such id does not exist");
            }
            return _mapper.Map<GenreDto>(genre);
        }
    }
}
