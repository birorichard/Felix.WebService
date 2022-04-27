using Felix.WebService.Services.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Felix.WebService.Services
{
    public class UserContextAccessor
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public UserContextAccessor(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;

        public int UserId => User.GetId();
    }
}
