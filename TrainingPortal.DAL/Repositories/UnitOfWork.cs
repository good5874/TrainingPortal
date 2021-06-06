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
        private SectionRepository sectionRepository;
        private CourseRepository courseRepository;
        private UserCoursesRepository userCoursesRepository;
        private CertificateRepository certificateRepository;
        private LessonRepository lessonRepository;
        private TestRepository testRepository;
        private QuestionRepository questionRepository;
        private UserTestsRepository userTestsRepository;

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

        public ISectionRepository Sections
        {
            get
            {
                if (sectionRepository == null)
                    sectionRepository = new SectionRepository(Conection);
                return sectionRepository;
            }
        }

        public ICourseRepository Courses
        {
            get
            {
                if (courseRepository == null)
                    courseRepository = new CourseRepository(Conection);
                return courseRepository;
            }
        }

        public IUserCoursesRepository UserCourses
        {
            get
            {
                if (userCoursesRepository == null)
                    userCoursesRepository = new UserCoursesRepository(Conection);
                return userCoursesRepository;
            }
        }

        public ICertificateRepository Certificates
        {
            get
            {
                if (certificateRepository == null)
                    certificateRepository = new CertificateRepository(Conection);
                return certificateRepository;
            }
        }

        public ILessonRepository Lessons
        {
            get
            {
                if (lessonRepository == null)
                    lessonRepository = new LessonRepository(Conection);
                return lessonRepository;
            }
        }

        public ITestRepository Tests
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(Conection);
                return testRepository;
            }
        }

        public IQuestionRepository Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(Conection);
                return questionRepository;
            }
        }

        public IUserTestsRepository UserTests
        {
            get
            {
                if (userTestsRepository == null)
                    userTestsRepository = new UserTestsRepository(Conection);
                return userTestsRepository;
            }
        }
    }
}
