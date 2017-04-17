using System;
using System.Collections.Generic;
using IotHandler.Services;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace IotHandler
{
	public partial class DetailSensor : ContentPage
	{

		public DetailSensor()
		{
			InitializeComponent();

			this.RunCounter(new CancellationToken());
		}

		protected void OnRemoveSensor(object sender, EventArgs args)
		{
			Sensor selectedSensor = (Sensor) BindingContext;

			SensorDataAccess dataAccess = new SensorDataAccess();

			dataAccess.DeleteSensor(selectedSensor);

			Navigation.PopToRootAsync();
		}

		public async Task RunCounter(CancellationToken token)
		{
			await Task.Run(async () =>
			{
				for (long i = 0; i < long.MaxValue; i++)
				{
					token.ThrowIfCancellationRequested();

					await Task.Delay(1000);

					Device.BeginInvokeOnMainThread(() =>
					{
						double positionTo = 0;

						Label a = new Label();
						a.Text = i.ToString();

						SensorData.Children.Add(a);

						positionTo = SensorData.HeightRequest;

						ScrollData.ScrollToAsync(0, SensorData.Height, true);
					});
				}
			}, token);
		}
	}
}
