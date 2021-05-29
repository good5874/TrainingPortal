using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IAuthentication
    {
        void Login(string email, string password, HttpContext httpContext);
        void Registration(string userName, string email, string password, HttpContext httpContext);

        void Logout(HttpContext httpContext);
    }
}
