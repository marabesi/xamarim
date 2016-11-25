using System;
using Xamarin.Forms;

namespace IotHandler
{
	public partial class IotHandlerPage : ContentPage
	{
		public IotHandlerPage()
		{
			InitializeComponent();

			SensorView.ItemsSource = App.sensors;

			Content = SensorView;
		}

		protected void OnNewSensor(object sender, EventArgs args)
		{
			Navigation.PushAsync(new NewSensor());
		}
	}
}
