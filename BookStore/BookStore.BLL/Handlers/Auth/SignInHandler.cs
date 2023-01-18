using BookStore.BLL.Interfaces;
using BookStore.BLL.Models.Authentication;
using BookStore.BLL.Queries.Auth;
using MediatR;

namespace BookStore.BLL.Handlers.Auth
{
    public class SignInHandler : IRequestHandler<SignInQuery, AuthenticateResult>
    {
        private readonly IUserService _userService;

        public SignInHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AuthenticateResult> Handle(SignInQuery request, CancellationToken cancellationToken = default)
        {
            var result = await _userService.SignInAsync(request.Model);
            return result;
        }
    }
}
