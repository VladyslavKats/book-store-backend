using AutoMapper;
using BookStore.BLL.Commands.Book;
using BookStore.BLL.Handlers.Book;
using BookStore.BLL.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public BooksController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200 , Type = typeof(IEnumerable<BookGetModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _sender.Send(new GetAllBooksQuery());
            return Ok(_mapper.Map<IEnumerable<BookGetModel>>(books));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200,Type = typeof(BookGetModel))]
        public async Task<IActionResult> GetAsync(string id)
        {
            var book = await _sender.Send(new GetBookByIdQuery(id));
            return Ok(_mapper.Map<BookGetModel>(book));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddAsync([FromBody]AddBookCommand command)
        {
            await _sender.Send(command);
            return StatusCode(201);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateBookCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _sender.Send(new DeleteBookByIdCommand(id));
            return StatusCode(204);
        }
    }
}
