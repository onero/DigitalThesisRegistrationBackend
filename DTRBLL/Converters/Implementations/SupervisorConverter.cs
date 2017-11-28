using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Converters.Implementations
{
    internal class SupervisorConverter : IConverter<Supervisor, SupervisorBO>
    {
        private readonly ProjectConverter _projectConverter = new ProjectConverter();
        public Supervisor Convert(SupervisorBO bo)
        {
            if (bo == null) return null;
            return new Supervisor
            {
                Id = bo.Id,
                FirstName = bo.FirstName,
                LastName = bo.LastName,
                AssignedProjects = bo.AssignedProjects?.Select(_projectConverter.Convert).ToList(),
                WantedProjects = bo.WantedProjects?.Select(_projectConverter.Convert).ToList()
            };
        }

        public SupervisorBO Convert(Supervisor entity)
        {
            if (entity == null) return null;
            return new SupervisorBO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                AssignedProjects = entity.AssignedProjects?.Select(_projectConverter.Convert).ToList(),
                WantedProjects = entity.WantedProjects?.Select(_projectConverter.Convert).ToList()
            };
        }
    }
}
