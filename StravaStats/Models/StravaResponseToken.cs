namespace StravaStats.Models
{
    public class StravaResponseToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public long expires_at { get; set; }
        public long expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
