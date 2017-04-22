using System;
using IotHandler;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Views;
using IotHandler.Droid;

[assembly: ExportRenderer(typeof(GestureLabel), typeof(GestureLabelRender))]
namespace IotHandler.Droid
{
	public class GestureLabelRender : ListViewRenderer
	{
		private readonly GestureListener _listener;
		private readonly GestureDetector _detector;

		public GestureLabelRender()
		{
			_listener = new GestureListener();
			_detector = new GestureDetector(_listener);

		}

		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement == null)
			{
				this.GenericMotion -= HandleGenericMotion;
				this.Touch -= HandleTouch;
			}

			if (e.OldElement == null)
			{
				this.GenericMotion += HandleGenericMotion;
				this.Touch += HandleTouch;
			}
		}

		void HandleTouch(object sender, TouchEventArgs e)
		{
			_detector.OnTouchEvent(e.Event);
		}

		void HandleGenericMotion(object sender, GenericMotionEventArgs e)
		{
			_detector.OnTouchEvent(e.Event);
		}
	}
}
