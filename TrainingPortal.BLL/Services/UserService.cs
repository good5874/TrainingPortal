using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork db)
        {
            Database = db;
        }
        public void Create(User user)
        {
           Database.Users.Create(user);
        }

        public void Delete(int userId)
        {
           Database.Users.Delete(userId);
        }

        public User Get(int userId)
        {
            var user = Database.Users.Get(userId);
            return user;
        }

        public User Get(string email)
        {
            var user = Database.Users.Get(email);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return Database.Users.GetAll();
        }

        public void Update(User user)
        {
            Database.Users.Update(user);
        }
    }
}
