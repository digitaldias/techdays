using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using techdays.domain.core.Managers;
using techdays.business;
using techdays.domain.core.Repositories;
using techdays.data.fakes;
using techdays.domain.core.Validators;
using techdays.domain.core.Workers;
using Microsoft.AspNet.Routing;

namespace TechDaysWeb
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseServices(services =>
            {
                services.AddMvc();
                services.AddScoped<ISensorReadingManager, SensorReadingManager>();
                services.AddScoped<ISensorReadingsRepository, FakeSensorReadingsRepository>();
                services.AddScoped<IExceptionHandler, ExceptionHandler>();
                services.AddScoped<ILogger, FakeLogger>();
                services.AddScoped<IStringToGuidConverter, StringToGuidConverter>();
                services.AddScoped<ISensorReadingValidator, SensorReadingValidator>();
            });

            app.UseMvc(routeconfig =>
                routeconfig.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}"));


        }
    }
}
