using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IotHandler
{
	public partial class NewSensor : ContentPage
	{
		public Sensor sensor = new Sensor();
		public SensorDataAccess database = new SensorDataAccess();

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

			btnSave.IsEnabled = false;

			BindingContext = sensor;
		}

		protected void OnSaveNewSensor(object sender, EventArgs args)
		{
			sensor.Name = txtName.Text;
			sensor.Description = txtDescription.Text;

			var selectedValue = pckType.Items[pckType.SelectedIndex];

			string image = selectedValue.ToUpper() + ".png";

			sensor.Type = new SensorType(1, "testing", image);

			App.sensors.Add(sensor);

			database.Save(sensor);

			Navigation.PopToRootAsync();
		}

		protected void OnFormDataChanged(object sender, EventArgs args)
		{
			btnSave.IsEnabled = false;

			int isSelected = pckType.SelectedIndex;
			string description = txtDescription.Text;
			string name = txtName.Text;

			if (name != null && description != null &&
			    isSelected >= 0 && name.Length > 3 && description.Length > 3)
			{
				btnSave.IsEnabled = true;
			}
		}
	}
}
