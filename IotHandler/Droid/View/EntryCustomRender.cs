using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IotHandler;
using IotHandler.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryCustom), typeof(EntryCustomRender))]
namespace IotHandler.Droid
{
	public class EntryCustomRender : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.SetBackgroundColor(global::Android.Graphics.Color.White);
			}
		}
	}
}
