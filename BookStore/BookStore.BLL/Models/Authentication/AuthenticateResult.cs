namespace BookStore.BLL.Models.Authentication
{
    public class AuthenticateResult
    {
        public bool IsSussecced { get; set; }

        public string Token { get; set; }

        public DateTime? ExperiesIn { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
