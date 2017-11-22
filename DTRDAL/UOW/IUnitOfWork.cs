using System;
using System.Runtime.CompilerServices;
using DTRDAL.Repositories;

[assembly: InternalsVisibleTo("DigitalThesisRegistration")]
[assembly: InternalsVisibleTo("DTRDALTests")]
namespace DTRDAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Complete UnitOfWork
        /// </summary>
        void Complete();

        IStudentRepository StudentRepository { get;  }
    }
}