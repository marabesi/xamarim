using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IotHandler
{
	public partial class NewSensor : ContentPage
	{
		public Sensor sensor = new Sensor();

		public NewSensor()
		{
			InitializeComponent();

			List<SensorType> sensorList = new List<SensorType>();
			sensorList.Add(new SensorType(1, "LED", "led.png"));
			sensorList.Add(new SensorType(2, "DHT11", "dht11.png"));
			sensorList.Add(new SensorType(3, "DHT22", "dht22.png"));
			sensorList.Add(new SensorType(4, "Button", "button.png"));

			foreach (var type in sensorList)
			{
				this.pckType.Items.Add(type.Description);
			}

			BindingContext = sensor;
		}

		protected void OnSaveNewSensor(object sender, EventArgs args)
		{

			sensor.Name = txtName.Text;
			sensor.Description = txtDescription.Text;

			var selectedValue = pckType.Items[pckType.SelectedIndex];

			string image = selectedValue.ToUpper() + ".png";

			sensor.Type = new SensorType(1, "", image);

			App.sensors.Add(sensor);

			Navigation.PopToRootAsync();
		}

		private void EditorOnFocused(object sender, EventArgs args)
		{
			// https://forums.xamarin.com/discussion/20616/placeholder-editor
		}
	}
}
