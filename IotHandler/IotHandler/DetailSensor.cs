using System;
using System.Collections.Generic;
using IotHandler.Services;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using IotHandler.Model.Json;

namespace IotHandler
{
	public partial class DetailSensor : ContentPage
	{

		private Sensor selectedSensor;

		public DetailSensor(Sensor selectedSensor)
		{
			InitializeComponent();

			this.selectedSensor = selectedSensor;

			if (this.selectedSensor.inOut == Sensor.OUTPUT) 
			{
				new Timer((o) => {
					Device.BeginInvokeOnMainThread(() => this.RunCounter(new CancellationToken()));
				}, null, 1000, 3000);
			}
		}

		protected void OnRemoveSensor(object sender, EventArgs args)
		{
			SensorDataAccess dataAccess = new SensorDataAccess();

			dataAccess.DeleteSensor(this.selectedSensor);

			Navigation.PopToRootAsync();
		}

		public async Task RunCounter(CancellationToken token)
		{
			await Task.Run(async () =>
			{
				token.ThrowIfCancellationRequested();

				HttpClient client = new HttpClient();

				HttpResponseMessage response = await client.GetAsync(this.selectedSensor.Url);

				if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var content = await response.Content.ReadAsStringAsync();

					SensorData collection = JsonConvert.DeserializeObject<SensorData>(content);

					var last = collection.Feeds.Count - 1;
					Feed obj = collection.Feeds[last];

					Device.BeginInvokeOnMainThread(() =>
					{
						double positionTo = 0;

						Label a = new Label();
						a.Text = obj.Field2;

						SensorData.Children.Add(a);

						positionTo = SensorData.HeightRequest;

						ScrollData.ScrollToAsync(0, SensorData.Height, true);
					});
				}
			}, token);
		}
	}
}
