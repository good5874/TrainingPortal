using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
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
    }
}
