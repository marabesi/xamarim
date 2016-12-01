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

			MainPage = new NavigationPage(new IotHandlerPage()) { 
				BarBackgroundColor = Color.FromHex("#C4C4C4"), BarTextColor = Color.White
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
