using System;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Shiny;
using Shiny.Jobs;


namespace TOSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            iOSShinyHost.Init(new ShinyStartup());
            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(1);
            Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }


        // if you are using jobs, you need this
        public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
            => JobManager.OnBackgroundFetch(completionHandler);
    }
}
