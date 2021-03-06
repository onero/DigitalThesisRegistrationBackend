﻿using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Converters.Implementations
{
    internal class StudentConverter : IConverter<Student, StudentBO>
    {
        public Student Convert(StudentBO bo)
        {
            if (bo == null) return null;
            return new Student
            {
                Id = bo.Id,
                FirstName = bo.FirstName,
                LastName = bo.LastName,
                GroupId = bo.GroupId,
                IsInGroup = bo.IsInGroup
            };
        }

        public StudentBO Convert(Student entity)
        {
            if (entity == null) return null;
            return new StudentBO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                GroupId = entity.GroupId,
                IsInGroup = entity.IsInGroup
            };
        }
    }
}