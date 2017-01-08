using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.Generic;
using IotHandler.View;
using IotHandler.Services;
using System.Collections.ObjectModel;

namespace IotHandler
{
	public partial class Login : ContentPage, IFormDataChanged
	{

		private SpinnerLoadingAnimation animation = new SpinnerLoadingAnimation();
		private SensorDataAccess sensorsData = new SensorDataAccess();

		public Login()
		{
			InitializeComponent();

			animation.Rotate(imgLoading, new CancellationToken());

			imgLoading.IsVisible = false;

			btnLogin.IsEnabled = false;
		}

		protected async void OnLogin(object sender, EventArgs args)
		{
			imgLoading.IsVisible = true;
			btnLogin.IsEnabled = false;

			string email = txtEmail.Text;
			string password = txtPassword.Text;

			await FindUser(email, password);
		}

		protected void OnNewUser(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new NewAccountModal());
		}

		private async Task FindUser(string user, string password)
		{
			String userUrl = string.Format(IHerokuService.LOGIN_URL);

			Uri uri = new Uri(userUrl);

			HttpClient client = new HttpClient();

			var requestContent = new Dictionary<string, string>();

			requestContent.Add("email", user);
			requestContent.Add("password", password);

			var response = await client.PostAsync(uri, new FormUrlEncodedContent(requestContent));

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				User userFound = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

				Settings.LoginToken = userFound._Id;

			   	ObservableCollection<Sensor> ob = new ObservableCollection<Sensor>();
				sensorsData.sensors = ob;

				sensorsData.GetSensors(userFound._Id);

				App.sensors = ob;

				redirectToDashboard();

				return;
			}

			imgLoading.IsVisible = false;
			btnLogin.IsEnabled = true;

			await DisplayAlert("Error", "Could not find the requested user", "OK");
		}

		protected void redirectToDashboard()
		{ 
			Application.Current.MainPage = new NavigationPage(new IotHandlerPage())
			{
				BarBackgroundColor = Color.FromHex("#C4C4C4"),
				BarTextColor = Color.White
			};
		}

		public void OnFormDataChanged(object sender, EventArgs args)
		{
			btnLogin.IsEnabled = false;

			var email = txtEmail.Text;
			var password = txtPassword.Text;

			if (email != null && password != null && txtEmail.Text.Length >= 3 && txtPassword.Text.Length >= 3) 
			{
				btnLogin.IsEnabled = true;
			}
		}
	}
}
