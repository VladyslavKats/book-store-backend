using AutoMapper;
using BookStore.API.Models;
using BookStore.BLL.Commands.Author;
using BookStore.BLL.Queries.Author;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthorsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorGetModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var authors = await _sender.Send(new GetAllAuthorsQuery());
            return Ok(_mapper.Map<IEnumerable<AuthorGetModel>>(authors));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddAsync([FromBody] AddAuthorCommand command)
        {
            await _sender.Send(command);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorGetModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(string id)
        {
            var author = await _sender.Send(new GetAuthorByIdQuery(id));
            return Ok(_mapper.Map<AuthorGetModel>(author));
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateAuthorCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _sender.Send(new DeleteAuthorByIdCommand(id));
            return StatusCode(204);
        }
    }
}
