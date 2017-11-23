using System;
using System.Collections.Generic;
using System.Text;

namespace DTRDAL.Entities
{
    public class Student: Person
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
