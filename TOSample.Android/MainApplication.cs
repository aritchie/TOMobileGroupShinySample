using System;
using Shiny;
using Android.App;
using Android.Runtime;
using TOSample;

// this file is needed for shiny to run on android
[Application]
public class YourApplication : Application
{
	public YourApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
	{
	}


	public override void OnCreate()
	{
		base.OnCreate();
		AndroidShinyHost.Init(this, new ShinyStartup());
	}
}