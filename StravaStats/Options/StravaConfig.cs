namespace StravaStats.Options
{
    public class StravaConfig
    {
        public const string StravaConfigConst = "StravaConfig";
        public long ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RefreshToken { get; set; }
        public long AthleteId { get; set; }
    }
}
