using System;
using Xamarin.Forms;
using IotHandler.View;

namespace IotHandler
{
	public partial class IotHandlerPage : ContentPage
	{
		public IotHandlerPage()
		{
			InitializeComponent();

			SensorView.RowHeight = 67;
			SensorView.ItemTemplate = new DataTemplate(typeof(SensorCell));
			SensorView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				DetailSensor detailScreen = new DetailSensor();
				detailScreen.BindingContext = (Sensor) e.Item;

				Navigation.PushAsync(detailScreen);
			};

			App.sensors.Add(new Sensor(
			 	"My beautiful sensor",
				"this sensor is in the main room",
				"/dev/null",
				0,
				new SensorType(1, "rola", "icon.png")
			));

			App.sensors.Add(new Sensor(
				 "Hello there",
				"just a fucking sensor",
				"/dev/null",
				0,
				new SensorType(1, "rola", "icon.png")
			));
		}

		protected void OnNewSensor(object sender, EventArgs args)
		{
			Navigation.PushAsync(new NewSensor());
		}

		protected override void OnAppearing()
		{ 
			base.OnAppearing();

			SensorView.ItemsSource = App.sensors;

			if (App.sensors.Count == 0)
			{
				emptyList.IsVisible = true;
				SensorView.IsVisible = false;

				Content = emptyList;
			}
			else
			{
				emptyList.IsVisible = false;
				SensorView.IsVisible = true;

				Content = SensorView;
			}
		}
	}
}
