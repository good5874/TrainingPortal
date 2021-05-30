using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Services;
using TrainingPortal.DAL;

namespace TrainingPortal.BLL
{
    public static class Startup
    {
        public static void BusinessLogicInitializer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });

            services.AddScoped<IAuthentication, Authentication>();

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IUserRolesService, UserRoleService>();
            services.AddSingleton<ISectionService, SectionService>();
            services.AddSingleton<ICourseService, CourseService>();

            services.DataAccessInitializer(configuration);
        }
    }
}
