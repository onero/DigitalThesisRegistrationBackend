using System;
using System.Collections.Generic;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Converters.Implementations
{
    internal class SupervisorConverter : IConverter<Supervisor, SupervisorBO>
    {
        public Supervisor Convert(SupervisorBO bo)
        {
            if (bo == null) return null;
            return new Supervisor
            {
                Id = bo.Id,
                FirstName = bo.FirstName,
                LastName = bo.LastName
            };
        }

        public SupervisorBO Convert(Supervisor entity)
        {
            if (entity == null) return null;
            return new SupervisorBO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }
    }
}
