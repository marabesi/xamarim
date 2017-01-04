using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IotHandler.Services;
using Xamarin.Forms;

namespace IotHandler.Droid
{
	[Activity(Label = "IotHandler.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

			String CurrentToken = Settings.LoginToken;

			if (!CurrentToken.Equals(""))
			{
				Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new IotHandlerPage())
				{
					BarBackgroundColor = Color.FromHex("#C4C4C4"),
					BarTextColor = Color.White
				};
			}
		}
	}
}
