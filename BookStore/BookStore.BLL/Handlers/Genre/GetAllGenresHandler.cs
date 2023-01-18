using AutoMapper;
using BookStore.BLL.Models.Genre;
using BookStore.BLL.Queries.Genre;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Genre
{
    public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreUW _context;

        public GetAllGenresHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken = default)
        {
            var genres = await _context.Genres.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDto>>(genres);
        }
    }
}
