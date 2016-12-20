using System;
using Xamarin.Forms;
using IotHandler.View;
using System.Collections;

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
