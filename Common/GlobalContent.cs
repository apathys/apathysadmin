using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection; 
using System; 

namespace Common
{
    public class GlobalContent
    {
        public static IConfiguration Configuration { get; set; } // 获取配置信息

        public static IServiceProvider ServiceProvider { get; set; } //配置服务提供者

        public static IWebHostEnvironment HostEnvironment { get; set; }

        public static SystemConfig SystemConfig { get; set; }

        public static IServiceCollection Services { get; set; }


    }
}
