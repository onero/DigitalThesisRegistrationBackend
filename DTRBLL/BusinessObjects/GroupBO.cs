using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTRBLL.BusinessObjects
{
    public class GroupBO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string ContactEmail { get; set; }
        public List<StudentBO> Students { get; set; }
    }
}