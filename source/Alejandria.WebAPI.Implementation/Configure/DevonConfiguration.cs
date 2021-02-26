using Alejandria.WebAPI.Implementation.Data.Database;
using Devon4Net.Domain.UnitOfWork.Common;
using Devon4Net.Domain.UnitOfWork.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.WebAPI.Implementation.Configure
{
    public static class DevonConfiguration
    {
        /// <summary>
        /// Setup of the dependency injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection SetupDevonDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetUpDatabases(configuration);
            return services;
        }

        private static IServiceCollection SetUpDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupDatabase<AlejandriaContext>(configuration, "Alejandria", DatabaseType.PostgreSQL);
            return services;
        }
    }
}
