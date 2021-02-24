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
        public static IServiceCollection SetupDevonDependencyInjection(this IServiceCollection services, IConfiguration _)
        {
            // Now is blank as the project does not use devon yet
            return services;
        }
    }
}
