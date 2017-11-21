using System;
using System.Collections.Generic;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Entities;

namespace DTRDAL.Repositories.Implementations
{
    class StudentRepository: IStudentRepository
    {
        private readonly DTRContext _context;

        public StudentRepository(DTRContext context)
        {
            _context = context;
        }

        public Student Create(Student ent)
        {
            return _context.Students.Add(ent).Entity;
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
