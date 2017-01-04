using System;

using Xamarin.Forms;
using IotHandler.Services;

namespace IotHandler
{
	public partial class NewSensor : ContentPage, IFormDataChanged
	{
		public Sensor sensor = new Sensor();
		public SensorDataAccess database = new SensorDataAccess();
		private SensorTypeFactory sensorTypeFactory = new SensorTypeFactory();

		public NewSensor()
		{
			InitializeComponent();

			foreach (var type in sensorTypeFactory.sensorList)
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

			SensorType createSensorType = sensorTypeFactory.create(selectedValue);

			sensor.Type = createSensorType;

			sensor.SensorTypeId = createSensorType.Id;

			App.sensors.Add(sensor);

			database.Save(sensor);

			Navigation.PopToRootAsync();
		}

		public void OnFormDataChanged(object sender, EventArgs args)
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
