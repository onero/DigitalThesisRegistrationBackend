﻿using System;
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
        ICompanyRepository CompanyRepository { get;  }
        ISupervisorRepository SupervisorRepository { get;  }
        IGroupRepository GroupRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IContractRepository ContractRepository { get; }
        IAppendixRepository AppendixRepository { get; }
        IUserRepository UserRepository { get; }
    }
}