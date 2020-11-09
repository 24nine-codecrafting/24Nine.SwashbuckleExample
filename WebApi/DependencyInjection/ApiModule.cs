using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.OptionModels;

namespace WebApi.DependencyInjection
{
    public static class ApiModule
    {
        public static IServiceCollection RegisterApiModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiInfoOptions>(configuration.GetSection(ApiInfoOptions.ApiInfo));

            return services;
        }
    }
}
