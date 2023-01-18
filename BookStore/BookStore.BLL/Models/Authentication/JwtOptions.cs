namespace BookStore.BLL.Models.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Key { get; set; }

        public string Audience { get; set; }

        public int Duration { get; set; }
    }
}
