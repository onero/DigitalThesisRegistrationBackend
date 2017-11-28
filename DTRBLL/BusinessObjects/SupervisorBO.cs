using System;
using System.Collections.Generic;
using System.Text;

namespace DTRBLL.BusinessObjects
{
    public class SupervisorBO : PersonBO {
        public List<ProjectBO> AssignedProjects { get; set; }
        public List<ProjectBO> WantedProjects { get; set; }
    }
}
