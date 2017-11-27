using System;
using System.Collections.Generic;
using System.Text;

namespace DTRBLL.BusinessObjects
{
    public class ProjectBO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public int WantedSuporvisorId { get; set; }
        public int AssignedSuporvisorId { get; set; }
    }
}
