using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace IotHandler
{
	public partial class App : Application
	{
		public static ObservableCollection<Sensor> sensors = new ObservableCollection<Sensor>();

		public App()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new IotHandlerPage()) { 
			//	BarBackgroundColor = Color.FromHex("#C4C4C4"), BarTextColor = Color.White
			//};

			MainPage = new Login();
		}

		protected override void OnStart()
		{
			SensorDataAccess dataAccess = new SensorDataAccess();
			dataAccess.sensors = sensors;
			dataAccess.GetSensors();
		}

		protected override void OnSleep()
		{
			sensors = new ObservableCollection<Sensor>();
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
