using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private UserRolesRepository userRolesRepository;
        private string Conection { get; set; }
        public UnitOfWork(string Conection)
        {
            this.Conection = Conection;
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(Conection);
                return userRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(Conection);
                return roleRepository;
            }
        }

        public IUserRolesRepository UserRoles
        {
            get
            {
                if (userRolesRepository == null)
                    userRolesRepository = new UserRolesRepository(Conection);
                return userRolesRepository;
            }
        }

        //public IRepository<DataSetDb.SectionsRow> Sections => throw new NotImplementedException();

        //public IRepository<DataSetDb.СoursesRow> Courses => throw new NotImplementedException();

        //public IRepository<DataSetDb.CertificatesRow> Certificates => throw new NotImplementedException();

        //public IRepository<DataSetDb.LessonsRow> Lessons => throw new NotImplementedException();

        //public IRepository<DataSetDb.TestsRow> Tests => throw new NotImplementedException();

        //public IRepository<DataSetDb.QuestionsRow> Questions => throw new NotImplementedException();

    }
}
