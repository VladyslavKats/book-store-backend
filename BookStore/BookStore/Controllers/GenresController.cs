using AutoMapper;
using BookStore.API.Models;
using BookStore.BLL.Commands.Genre;
using BookStore.BLL.Queries.Genre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public GenresController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200 , Type = typeof(IEnumerable<GenreGetModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _sender.Send(new GetAllGenresQuery());
            return Ok(_mapper.Map<IEnumerable<GenreGetModel>>(genres));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200 , Type = typeof(GenreGetModel))]
        public async Task<IActionResult> GetAsync(string id)
        {
            var genre = await _sender.Send(new GetGenreByIdQuery(id));
            return Ok(_mapper.Map<GenreGetModel>(genre));
        } 
        
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddAsync([FromBody]AddGenreCommand command)
        {
            await _sender.Send(command);
            return StatusCode(201);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateGenreCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _sender.Send(new DeleteGenreByIdCommand(id));
            return StatusCode(204);
        }
    }
}
