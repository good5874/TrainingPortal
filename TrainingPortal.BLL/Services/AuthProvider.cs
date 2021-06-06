using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using System.Threading.Tasks;
using TrainingPortal.BLL.Infrastructure;

namespace TrainingPortal.BLL.Services
{
    public class AuthProvider : IAuthProvider
    {
        private IUserService userService;
        private IRoleService roleService;
        public AuthProvider(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        private async Task Authenticate(int userId, string userName, string email, HttpContext httpContext)
        {
            var roles = roleService.GetRoles(userId);

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim("Email", email, "string")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
            }

            ClaimsIdentity id = new ClaimsIdentity(claims, "TrainingPortal", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public void Login(string email, string password, HttpContext httpContext)
        {
            var user = userService.Get(email);
            if (user != null && user.Password == password)
            {
                Authenticate(user.UserId, user.UserName, user.Email, httpContext).Wait();
            }
            else
            {
                throw new ValidationException("Неверный логин или пароль", "");
            }
        }

        public void Logout(HttpContext httpContext)
        {
            httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
        }

        public void Registration(string userName, string fullName, string email, string password, HttpContext httpContext)
        {
            User user = userService.Get(email);
            if (user == null)
            {
                userService.Create(new User(0, userName, fullName, email, password));
            }
            else
            {
                throw new ValidationException("Такой пользователь уже существует", "");
            }
        }
    }
}
