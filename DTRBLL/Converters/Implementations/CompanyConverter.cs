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
                Name = bo.Name,
                ContactName = bo.ContactName,
                ContactEmail = bo.ContactEmail,
                ContactPhone = bo.ContactPhone
            };
        }

        public CompanyBO Convert(Company entity)
        {
            if (entity == null) return null;
            return new CompanyBO
            {
                Id = entity.Id,
                Name = entity.Name,
                ContactName = entity.ContactName,
                ContactEmail = entity.ContactEmail,
                ContactPhone = entity.ContactPhone
            };
        }
    }
}
