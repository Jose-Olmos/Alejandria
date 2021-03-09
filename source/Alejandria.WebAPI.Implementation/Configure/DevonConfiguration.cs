using Alejandria.WebAPI.Implementation.Business.NewsFeedManagment.Handlers;
using Alejandria.WebAPI.Implementation.Data.Database;
using Devon4Net.Domain.UnitOfWork.Common;
using Devon4Net.Domain.UnitOfWork.Enums;
using Devon4Net.Infrastructure.Common.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            services.SetupDatabases(configuration);
            services.SetupHttpHandlers();

            var assemblyToScan = Assembly.GetAssembly(typeof(DevonConfiguration));

            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
                .Where(x => x.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            return services;
        }

        private static IServiceCollection SetupDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupDatabase<AlejandriaContext>(configuration, "Alejandria", DatabaseType.PostgreSQL, migrate: true);
            return services;
        }

        private static IServiceCollection SetupHttpHandlers(this IServiceCollection services)
        {
            services.AddTransient<ISendFeedSyncHandler, SendFeedSyncHandler>();

            return services;
        }
    }
}
