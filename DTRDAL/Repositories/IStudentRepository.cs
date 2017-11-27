using System.Collections.Generic;
using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IStudentRepository: IRespository<Student>
    {
        IEnumerable<Student> GetByIds(List<int> ids);
    }
}