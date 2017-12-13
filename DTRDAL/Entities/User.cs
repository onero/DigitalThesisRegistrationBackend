using System;
using System.Collections.Generic;
using System.Text;

namespace DTRDAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
    }
}
