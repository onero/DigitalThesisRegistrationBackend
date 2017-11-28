using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTRBLL.BusinessObjects
{
    public class CompanyBO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string ContactName { get; set; }
        [Required]
        [MinLength(2)]
        public string ContactEmail { get; set; }
        [Required]
        [MinLength(2)]
        public int ContactPhone { get; set; }
    }
}
