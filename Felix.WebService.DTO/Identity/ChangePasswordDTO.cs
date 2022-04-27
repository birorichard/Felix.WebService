namespace Felix.WebService.DTO.Identity
{
    public class ChangePasswordDTO
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
