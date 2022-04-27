using Felix.WebService.Common.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Felix.WebService.Data.Models.Identity
{
    [Table(nameof(User), Schema = DataConstants.UserSchemaName)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

    }
}
