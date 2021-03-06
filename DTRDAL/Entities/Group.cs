﻿using System.Collections.Generic;

namespace DTRDAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Student> Students { get; set; }
    }
}