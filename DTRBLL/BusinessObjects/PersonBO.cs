using System.ComponentModel.DataAnnotations;

namespace DTRBLL.BusinessObjects
{
    public class PersonBO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
    }
}