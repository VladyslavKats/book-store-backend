using AutoMapper;
using BookStore.BLL.Commands.Language;
using BookStore.BLL.Models.Book;
using BookStore.BLL.Queries.Language;
using BookStore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public LanguagesController(ISender sender, IMapper mapper)
        {
            this._sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200 , Type = typeof(IEnumerable<LanguageGetModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var languages = await _sender.Send(new GetAlllanguagesQuery());
            return Ok(_mapper.Map<IEnumerable<LanguageGetModel>>(languages));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddAsync([FromBody]AddLanguageCommand command)
        {
            await _sender.Send(command);
            return StatusCode(201);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateLanguageCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(LanguageGetModel))]
        public async Task<IActionResult> GetAsync(string id)
        {
            var language = await _sender.Send(new GetLanguageByIdQuery(id));
            return Ok(_mapper.Map<LanguageGetModel>(language));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _sender.Send(new DeleteLanguageByIdCommand(id));
            return StatusCode(204);
        }
    }
}
