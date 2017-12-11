using System;
using System.Collections.Generic;
using System.Text;

namespace DTRDAL.Entities
{
    public class Supervisor : Person
    {
        public int UserId { get; set; }
        public List<Project> AssignedProjects { get; set; }
        public List<Project> WantedProjects { get; set; }
    }
}
