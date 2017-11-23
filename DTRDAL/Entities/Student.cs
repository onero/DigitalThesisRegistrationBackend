using System;
using System.Collections.Generic;
using System.Text;

namespace DTRDAL.Entities
{
    public class Student: Person
    {
        public Group Group { get; set; }
    }
}
