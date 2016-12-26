using System;
using Xamarin.Forms;	

namespace IotHandler.View
{
	public class SensorCell : ViewCell
	{

		public SensorCell()
		{
			var image = new Image();
			StackLayout cellWrapper = new StackLayout();
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

			//var moreAction = new MenuItem { Text = "Delete", IsDestructive = true };
			//moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
			//moreAction.Clicked += (sender, e) =>
			//{
			//	var mi = ((MenuItem)sender);
			//	//Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter);
			//};

			//this.ContextActions.Add(moreAction);

			View = cellWrapper;
		}
	}
}
