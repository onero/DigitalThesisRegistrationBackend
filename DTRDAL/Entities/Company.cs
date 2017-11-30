using System;
using System.Collections.Generic;
using System.Text;

namespace DTRDAL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
