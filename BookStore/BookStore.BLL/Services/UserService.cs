using BookStore.BLL.Interfaces;
using BookStore.BLL.Models.Authentication;
using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BookStore.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public UserService(UserManager<User> userManager , IJwtTokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthenticateResult> SignInAsync(SignInDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new AuthenticateResult
                {
                    IsSussecced = false,
                    Errors = new string[] { "User with such email does not exist" }
                };
            }
            if(!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthenticateResult
                {
                    IsSussecced = false,
                    Errors = new string[] { "Incorrect password" }
                };
            };
            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenGenerator.GenerateAsync(user , roles);
            return new AuthenticateResult
            {
                IsSussecced = true,
                Token = token
            };
        }

        public async Task<AuthenticateResult> SignUpAsync(SignUpDto model)
        {
            var userExist = await _userManager.FindByEmailAsync(model.Email);
            if (userExist != null)
            {
                return new AuthenticateResult
                {
                    IsSussecced = false,
                    Errors = new string[] { "Such email is already used" }
                };
            }
            var user = new User
            {
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                return new AuthenticateResult
                {
                    IsSussecced = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenGenerator.GenerateAsync(user, roles);
            return new AuthenticateResult
            {
                IsSussecced = true,
                Token = token
            };
        }
    }
}
