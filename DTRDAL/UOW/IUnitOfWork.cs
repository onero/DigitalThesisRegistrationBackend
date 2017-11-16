using System;
using System.Runtime.CompilerServices;

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
    }
}