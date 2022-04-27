namespace Felix.WebService.DTO.Authentication
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public bool IsAdmin { get; set; }
    }
}
