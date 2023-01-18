using BookStore.BLL.Models.Authentication;

namespace BookStore.BLL.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResult> SignInAsync(SignInDto model);

        Task<AuthenticateResult> SignUpAsync(SignUpDto model);
    }
}
