using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserRolesRepository UserRoles { get; }
        IRoleRepository Roles { get; }
        //IRepository<DataSetDb.SectionsRow> Sections { get; }
        //IRepository<DataSetDb.СoursesRow> Courses { get; }
        //IRepository<DataSetDb.CertificatesRow> Certificates { get; }
        //IRepository<DataSetDb.LessonsRow> Lessons { get; }
        //IRepository<DataSetDb.TestsRow> Tests { get; }
        //IRepository<DataSetDb.QuestionsRow> Questions { get; }
    }
}
