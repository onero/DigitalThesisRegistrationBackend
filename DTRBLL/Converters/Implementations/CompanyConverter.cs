using System;
using System.Collections.Generic;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Converters.Implementations
{
    public class CompanyConverter : IConverter<Company, CompanyBO>
    {
        public Company Convert(CompanyBO bo)
        {
            if (bo == null) return null;
            return new Company
            {
                Id = bo.Id,
                Name = bo.Name
            };
        }

        public CompanyBO Convert(Company entity)
        {
            if (entity == null) return null;
            return new CompanyBO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
