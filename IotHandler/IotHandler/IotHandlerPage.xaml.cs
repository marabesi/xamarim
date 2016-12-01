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

			SensorView.ItemsSource = App.sensors;

			Content = SensorView;
		}

		protected void OnNewSensor(object sender, EventArgs args)
		{
			Navigation.PushAsync(new NewSensor());
		}
	}
}
