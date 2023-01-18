using BookStore.BLL.Models.Authentication;
using MediatR;

namespace BookStore.BLL.Queries.Auth
{
    public class SignInQuery : IRequest<AuthenticateResult>
    {
        public SignInDto Model { get; set; }

        public SignInQuery(SignInDto model)
        {
            Model = model;
        }
    }
}
