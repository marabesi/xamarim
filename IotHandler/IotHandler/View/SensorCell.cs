using System;
using Xamarin.Forms;	

namespace IotHandler.View
{
	public class SensorCell : ViewCell
	{

		public SensorCell()
		{
			var image = new Image();
			var cellWrapper = new MR.Gestures.StackLayout();

			StackLayout horizontalLayout = new StackLayout();

			StackLayout ImageLayout = new StackLayout();
			ImageLayout.HorizontalOptions = LayoutOptions.Start;

			Label left = new Label();
			Label right = new Label();

			left.TextColor = Color.FromHex("#37A0AA");
			right.TextColor = Color.FromHex("#C4C4C4");

			left.SetBinding(Label.TextProperty, "Name");
			right.SetBinding(Label.TextProperty, "Description");
			image.SetBinding(Image.SourceProperty, "Type.Image");
			image.WidthRequest = 55;

			cellWrapper.Orientation = StackOrientation.Horizontal;
			cellWrapper.Padding = 10;

			horizontalLayout.Orientation = StackOrientation.Vertical;
			horizontalLayout.VerticalOptions = LayoutOptions.EndAndExpand;

			ImageLayout.Children.Add(image);

			horizontalLayout.Children.Add(left);
			horizontalLayout.Children.Add(right);

			cellWrapper.Children.Add(ImageLayout);
			cellWrapper.Children.Add(horizontalLayout);

			cellWrapper.LongPressing += (s, e) =>
			{
				MessagingCenter.Send(IotHandlerPage.TAG, "REMOVE");
			};

			cellWrapper.Tapping += (s, e) =>
			{
				var currentSensor = (Sensor)BindingContext;
				MessagingCenter.Send<String, object>("LALA", "DETAIL", currentSensor);
			};

			View = cellWrapper;
		}
	}
}
