using Common;
using DataLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class SqlServerConfiguration
    {
        static SqlServerSettings sqlServerSettings;
        static SqlServerConfiguration()
        {
            sqlServerSettings = DependencyHelper.ServiceProvider.GetService<IOptions<SqlServerSettings>>().Value;
        }
        
        public static string ConnectionString
        {
            get
            {
                return sqlServerSettings.ConnectionString;
            }
        }
    }
}
