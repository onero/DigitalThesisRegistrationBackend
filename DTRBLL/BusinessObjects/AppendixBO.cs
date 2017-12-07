using System.ComponentModel.DataAnnotations;

namespace DTRBLL.BusinessObjects
{
    public class AppendixBO
    {
        [Required]
        public string Condition { get; set; }
        [Required]
        public string Resources { get; set; }
    }
}