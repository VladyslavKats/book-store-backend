namespace BookStore.BLL.Models.Authentication
{
    public class SignUpDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
