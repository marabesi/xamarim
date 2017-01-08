using Xamarin.Forms;
using System.Collections.ObjectModel;
using IotHandler.Services;

namespace IotHandler
{
	public partial class App : Application
	{
		public static ObservableCollection<Sensor> sensors = new ObservableCollection<Sensor>();

		public App()
		{
			InitializeComponent();

			MainPage = new Login();
		}

		protected override void OnStart()
		{
			SensorDataAccess dataAccess = new SensorDataAccess();
			dataAccess.sensors = sensors;
			dataAccess.GetSensors(Settings.LoginToken);
		}

		protected override void OnSleep()
		{
			sensors = new ObservableCollection<Sensor>();
		}

		protected override void OnResume()
		{
			SensorDataAccess dataAccess = new SensorDataAccess();
			dataAccess.sensors = sensors;
			dataAccess.GetSensors(Settings.LoginToken);
		}
	}
}
