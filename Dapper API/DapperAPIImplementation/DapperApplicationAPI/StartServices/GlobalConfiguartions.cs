using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI
{
    public static class GlobalConfiguartions
    {
        public static void SetGlobalConfiguration(IConfiguration configuration)
        {
            ApplicationConfigurations.DBConnection = "Data Source=DESKTOP-MBONB33;Initial Catalog=EmployeeProject;Integrated Security=True";
                //configuration.GetValue<string>("AppSettings:DBConnection");
        }
    }
    public static class ApplicationConfigurations
    {
        public static string DBConnection { get; set; }
        public static string SecretKey { get; set; }
    }
}
