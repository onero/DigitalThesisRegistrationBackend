using System.ComponentModel.DataAnnotations;

namespace DTRBLL.BusinessObjects
{
    public class UserBO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "Group";
    }
}