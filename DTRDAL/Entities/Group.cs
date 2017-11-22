using System.Collections.Generic;

namespace DTRDAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public List<int> StudentIds { get; set; }
    }
}