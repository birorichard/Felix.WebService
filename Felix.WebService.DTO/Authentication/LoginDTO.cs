using System.ComponentModel.DataAnnotations;

namespace Felix.WebService.DTO.Authentication
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
