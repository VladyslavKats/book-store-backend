using BookStore.DAL.Entities;

namespace BookStore.BLL.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateAsync(User user, IEnumerable<string> roles);
    }
}
