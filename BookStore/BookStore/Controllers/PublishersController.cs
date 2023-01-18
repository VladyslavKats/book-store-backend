using AutoMapper;
using BookStore.API.Models;
using BookStore.BLL.Commands.Publisher;
using BookStore.BLL.Queries.Publisher;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public PublishersController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200 , Type = typeof(IEnumerable<PublisherGetModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var publishers = await _sender.Send(new GetAllPublishersQuery());
            return Ok(_mapper.Map<IEnumerable<PublisherGetModel>>(publishers));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddAsync([FromBody]AddPublisherCommand command)
        {
            await _sender.Send(command);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200 ,Type = typeof(PublisherGetModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(string id)
        {
            var publisher = await _sender.Send(new GetPublisherByIdQuery(id));
            return Ok(_mapper.Map<PublisherGetModel>(publisher));
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdatePublisherCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _sender.Send(new DeletePublisherByIdCommand(id));
            return StatusCode(204);
        }
    }
}
