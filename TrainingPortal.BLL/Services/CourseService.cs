using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class CourseService : ICourseService
    {
        IUnitOfWork Database { get; set; }

        public CourseService(IUnitOfWork db)
        {
            Database = db;
        }

        public IEnumerable<Course> GetAll()
        {
            return Database.Courses.GetAll();
        }

        public Course Get(int id)
        {
            return Database.Courses.Get(id);
        }

        public void Create(Course item)
        {
            Database.Courses.Create(item);
        }

        public void Update(Course item)
        {
            Database.Courses.Update(item);
        }

        public void Delete(int id)
        {
            Database.Courses.Delete(id);
        }

        public ValidatedCourseDTO CheckCourse(int courseId, ClaimsPrincipal userClaim)
        {
            ValidatedCourseDTO validatedCourseDTO = new ValidatedCourseDTO();

            var course = Database.Courses.Get(courseId);

            var email = userClaim.FindFirst("Email");
            var user = Database.Users.Get(email.Value);

            var tests = Database.Tests.GetTests(course.CourseId);
            var userTests = Database.UserTests.GetUserTests(user.UserId);


            validatedCourseDTO.NameCourse = course.Name;

            int finishedTests = userTests.Where(e => tests.Any(x => x.TestId == e.TestId) && e.IsFinish == true).Count();

            if (finishedTests == tests.Count())
            {
                validatedCourseDTO.Result = "Курс пройден";
            }
            else
            {
                validatedCourseDTO.Result = "Нужно пройти остальные тесты, чтобы закончить курс";
            }

            SaveResultCourse(finishedTests, tests.Count(), userClaim, course);

            return validatedCourseDTO;
        }

        private void SaveResultCourse(int finishTests, int allTests, ClaimsPrincipal userClaim, Course course)
        {
            var email = userClaim.FindFirst("Email");
            var user = Database.Users.Get(email.Value);

            UserCourses userCoursesTemp = new UserCourses();
            userCoursesTemp.CourseId = course.CourseId;
            userCoursesTemp.UserId = user.UserId;

            if (finishTests == allTests)
            {
                userCoursesTemp.IsFinish = true;
            }
            else
            {
                userCoursesTemp.IsFinish = false;
            }

            var userCourses = Database.UserCourses.Get(userCoursesTemp.CourseId, userCoursesTemp.UserId);

            if (userCourses == null)
            {
                Database.UserCourses.Create(userCoursesTemp);
                if (userCoursesTemp.IsFinish == true)
                {
                    Database.Certificates.Create(new Certificate(course.CourseId, user.UserId, user.FullName, course.Name));
                }
            }
            else
            {
                if (userCourses.IsFinish == false && userCoursesTemp.IsFinish == true)
                {
                    Database.UserCourses.Update(userCoursesTemp);
                    Database.Certificates.Create(new Certificate(course.CourseId, user.UserId, user.FullName, course.Name));
                }
            }
        }

        public IEnumerable<Course> GetCourse(int sectionId)
        {
            return Database.Courses.GetCourse(sectionId);
        }

        public IEnumerable<Course> GetFinishedCourses(int userId)
        {
            return Database.Courses.GetFinishedCourses(userId);
        }

        public IEnumerable<Course> Search(string nameCourse, string nameSection, string targetAudience)
        {
            var courses = new List<Course>();

            var allCourses = Database.Courses.GetAll();
            var sections = Database.Sections.GetAll();

            var CoursesWithSection = allCourses.Select(e => new { course = e, section = sections.FirstOrDefault(x => x.SectionId == e.SectionId) });


            if (!string.IsNullOrEmpty(nameSection))
            {
                CoursesWithSection = CoursesWithSection.Where(e => e.section.Name.Contains(nameSection));
            }

            if (!string.IsNullOrEmpty(nameCourse))
            {
                CoursesWithSection = CoursesWithSection.Where(e => e.course.Name.Contains(nameCourse));
            }

            if (!string.IsNullOrEmpty(targetAudience))
            {
                CoursesWithSection = CoursesWithSection.Where(e => e.course.TargetAudience.Contains(targetAudience));
            }

            return CoursesWithSection.Select(e => e.course).ToList();
        }
    }
}
