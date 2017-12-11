using System;
using System.Collections.Generic;
using System.Text;

namespace DTRBLL.BusinessObjects
{
    class UserDBBO
    {
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
    }
}
