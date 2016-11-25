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

			BindingContext = sensor;
		}

		protected void OnSaveNewSensor(object sender, EventArgs args)
		{

			sensor.Name = txtName.Text;

			App.sensors.Add(sensor);

			Navigation.PopToRootAsync();
		}
	}
}
