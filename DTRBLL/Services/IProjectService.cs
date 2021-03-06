﻿using System;
using System.Collections.Generic;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Services
{
    public interface IProjectService : IService<ProjectBO>
    {
        IList<ProjectBO> GetAllWithAssignedSupervisor();
    }
}
