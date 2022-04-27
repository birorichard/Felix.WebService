using System;

namespace Felix.WebService.DTO.Authentication
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string RefreshToken { get; set; }

    }
}
