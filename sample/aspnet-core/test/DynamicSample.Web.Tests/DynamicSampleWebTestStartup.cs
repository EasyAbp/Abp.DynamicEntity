using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace DynamicSample
{
    public class DynamicSampleWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<DynamicSampleWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}