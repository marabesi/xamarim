﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IotHandler
{
	public partial class DetailSensor : ContentPage
	{

		public DetailSensor()
		{
			InitializeComponent();
		}

		protected void OnRemoveSensor(object sender, EventArgs args)
		{
			Sensor selectedSensor = (Sensor) BindingContext;


			SensorDataAccess dataAccess = new SensorDataAccess();
			dataAccess.DeleteSensor(selectedSensor);

			Navigation.PopToRootAsync();
		}
	}
}