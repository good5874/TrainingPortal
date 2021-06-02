using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Services;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.DAL.Repositories;

namespace TrainingPortal.DI
{
    public static class Startup
    {
        public static void BusinessLogicInitializer(this IServiceCollection services)
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
            services.AddSingleton<ILessonService, LessonService>();
            services.AddSingleton<ITestService, TestService>();
            services.AddSingleton<IQuestionService, QuestionService>();
            services.AddSingleton<IUserTestsService, UserTestsService>();

        }

        public static void DataAccessInitializer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
