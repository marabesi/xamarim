using System;
using Xamarin.Forms;
using IotHandler.View;
using IotHandler.Services;

namespace IotHandler
{
	public partial class IotHandlerPage : ContentPage
	{

		public const String TAG = "IotHandlerPage";

		public IotHandlerPage()
		{
			InitializeComponent();

			NavigationPage.SetHasBackButton(this, false);

			SensorView.RowHeight = 67;
			SensorView.ItemTemplate = new DataTemplate(typeof(SensorCell));

            this.onClicked();
            this.OnRemoveAll();
		}

		public void onClicked()
		{
			MessagingCenter.Subscribe<String, object>("LALA", "DETAIL", (sender, obj) => {
				Sensor selectedSensor = (Sensor) obj;
				DetailSensor detailScreen = new DetailSensor(selectedSensor);
				detailScreen.BindingContext = selectedSensor;
				Navigation.PushAsync(detailScreen);
			});
		}

		public void OnRemoveAll()
		{
			MessagingCenter.Subscribe<String>(IotHandlerPage.TAG, "REMOVE", async (sender) => {
				var answer = await DisplayAlert("Are you sure?", "Do you want to remove the selected sensor?", "Yes", "No");

				if (answer)
				{
							
				}
			});
		}

		protected async void OnLogout(object sender, EventArgs args)
		{ 
			var answer = await DisplayAlert("Logging out", "Are you sure ?", "Yes", "No");

			if (answer)
			{
				Settings.LoginToken = "";
				Application.Current.MainPage = new Login();
				App.sensors.Clear();
			}
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
			}
			else
			{
				emptyList.IsVisible = false;
				SensorView.IsVisible = true;
			}
		}
	}
}
