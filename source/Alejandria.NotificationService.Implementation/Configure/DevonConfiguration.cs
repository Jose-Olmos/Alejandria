using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.NotificationService.Implementation.Configure
{
    public static class DevonConfiguration
    {
        public static IServiceCollection SetupDevonDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
