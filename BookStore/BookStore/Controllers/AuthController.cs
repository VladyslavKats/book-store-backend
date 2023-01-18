using BookStore.BLL.Models.Authentication;
using BookStore.BLL.Queries.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("sign-in")]
        [ProducesResponseType(200,Type = typeof(AuthenticateResult))]
        [ProducesResponseType(400,Type = typeof(AuthenticateResult))]
        public async Task<IActionResult> SignInAsync([FromBody]SignInQuery query)
        {
            var result = await _sender.Send(query);
            if (result.IsSussecced)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new {Errors = result.Errors });
            }
        }
    }
}
