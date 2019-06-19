using System;
using System.Threading;
using System.Threading.Tasks;
using Shiny.Jobs;
using Shiny.Locations;
using Shiny.Notifications;


namespace TOSample
{
    public class ShinyDelegates : IJob, 
                                  IGeofenceDelegate,
                                  IGpsDelegate
    {
        readonly INotificationManager notifications;


        public ShinyDelegates(INotificationManager notifications)
        {
            this.notifications = notifications;
        }


        public async Task OnReading(IGpsReading reading)
        {
        }


        public async Task OnStatusChanged(GeofenceState newStatus, GeofenceRegion region)
        {
        }


        public async Task<bool> Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            var message = jobInfo.GetParameter<string>("Message");

            // this method will request permission to run notifications (on iOS), if this job is
            // actually run from the background, this method will just return without doing anything
            // be sure to run INotificationManager.RequestAccess when the user is actually using your
            // app
            await this.notifications.Send(new Notification
            {
                Title = "Test",
                Message = message
            });

            // this will tell you the last time the job was run
            //jobInfo.LastRunUtc

            // you can change your parameters
            jobInfo.SetParameter("Message", "I've run, so hello again!");
            return true;
        }
    }
}
