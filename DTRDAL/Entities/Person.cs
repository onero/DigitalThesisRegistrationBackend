using System;
using System.Collections.Generic;
using System.Text;

namespace DTRDAL.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
