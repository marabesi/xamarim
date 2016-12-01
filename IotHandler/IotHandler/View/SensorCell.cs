using System;
using Xamarin.Forms;	

namespace IotHandler.View
{
	public class SensorCell : ViewCell
	{

		//Label nameLabel, ageLabel, locationLabel;

		//public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(SensorCell), "Name");

		//public string Name { 
		//	get { return (string)GetValue(NameProperty); }
		//	set { SetValue(NameProperty, value); }
		//}

		//protected override void OnBindingContextChanged()
		//{
		//	base.OnBindingContextChanged();

		//	if (BindingContext != null)
		//	{
		//		nameLabel.Text = Name;
		//	}
		//}

		public SensorCell()
		{
			//instantiate each of our views
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


			//cellWrapper.BackgroundColor = Color.FromHex("#eee");
			cellWrapper.Orientation = StackOrientation.Horizontal;
			cellWrapper.Padding = 10;
				
			horizontalLayout.Orientation = StackOrientation.Vertical;
			horizontalLayout.VerticalOptions = LayoutOptions.EndAndExpand;

			ImageLayout.Children.Add(image);

			horizontalLayout.Children.Add(left);
			horizontalLayout.Children.Add(right);

			cellWrapper.Children.Add(ImageLayout);
			cellWrapper.Children.Add(horizontalLayout);

			View = cellWrapper;
		}
	}
}
