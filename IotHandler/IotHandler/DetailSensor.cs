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

		public DetailSensor()
		{
			InitializeComponent();

			new Timer((o) => {
				Device.BeginInvokeOnMainThread(() => this.RunCounter(new CancellationToken()));
			}, null, 1000, 3000);
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
				token.ThrowIfCancellationRequested();

					HttpClient client = new HttpClient();

					HttpResponseMessage response = await client.GetAsync("https://thingspeak.com/channels/38265/field/2.json");

					if (response.IsSuccessStatusCode)
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
