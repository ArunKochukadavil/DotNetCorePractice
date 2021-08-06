using Common;
using DataLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCorePractice
{
    public static class StartupConfig
    {
        public static IConfigurationBuilder Startup(IWebHostEnvironment env, string path = "")
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(
                    $"appsettings.json",
                    optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables();
            return builder;
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.Configure<SqlServerSettings>(
                configuration.GetSection(nameof(SqlServerSettings)));


            // Rebuild ServiceProvider with all services
            DependencyHelper.ServiceProvider = services.BuildServiceProvider();
        }
    }
}
