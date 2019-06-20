using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Jobs;
using Shiny.Locations;
using Shiny.Notifications;


namespace TOSample
{
    public class ShinyStartup : Shiny.Startup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.UseNotifications(true, androidOpts =>
            {
                androidOpts.SmallIconResourceName = "notification";
            });
            services.UseGps<ShinyDelegates>();
            services.UseGeofencing<ShinyDelegates>();

            // this registers a job against your entire application
            // you can register these at any time by using IJobManager.Schedule
            //  check out - https://allancritchie.net/shinyjobs for more info
            services.RegisterJob(new JobInfo
            {
                // since you can register the same job type against multiple sets
                // of parameters, we must give our job an string identifier
                Identifier = nameof(ShinyDelegates),
                Type = typeof(ShinyDelegates),

                // must have some sort of network
                //RequiredInternetAccess = InternetAccess.Any,

                // pass any args into your job
                Parameters = new Dictionary<string, object>
                {
                    // note that you can pass different types
                    { "Message", "I'm a test notification" },
                    { "Counter", 0 }
                }
            });
        }
    }
}
