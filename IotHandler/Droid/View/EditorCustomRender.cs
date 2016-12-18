using System;
using System.Collections.Generic;
using System.ComponentModel;
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

[assembly: ExportRenderer(typeof(EditorCustom), typeof(EditorCustomRender))]
namespace IotHandler.Droid
{
	public class EditorCustomRender : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.SetBackgroundColor(global::Android.Graphics.Color.White);
			}

			if (e.NewElement != null)
			{
				var element = e.NewElement as EditorCustom;
				this.Control.Hint = element.Placeholder;
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == EditorCustom.PlaceholderProperty.PropertyName)
			{
				var element = this.Element as EditorCustom;
				this.Control.Hint = element.Placeholder;
			}
		}
	
	}
}
