using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.DAL.Repositories;

namespace TrainingPortal.DAL
{
    public static class Startup
    {
        public static void DataAccessInitializer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
