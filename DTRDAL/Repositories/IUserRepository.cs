﻿using System;
using System.Collections.Generic;
using System.Text;
using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IUserRepository
    {
        bool Create(User ent);
    }
}