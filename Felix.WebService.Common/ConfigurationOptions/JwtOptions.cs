namespace Felix.WebService.Common.ConfigurationOptions
{
    /// <summary>
    /// Type for JWT setup and configuration
    /// </summary>
    public class JwtOptions
    {
        public const string Jwt = "Jwt";
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTimeInMinutes { get; set; }
        public int RefreshTokenLifeTimeInMinutes { get; set; }
    }
}
