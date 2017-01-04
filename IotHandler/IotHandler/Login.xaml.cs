using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.Generic;
using IotHandler.View;
using IotHandler.Services;

namespace IotHandler
{
	public partial class Login : ContentPage, IFormDataChanged
	{

		private SpinnerLoadingAnimation animation = new SpinnerLoadingAnimation();

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
			String userUrl = IHerokuService.USERS_URL + "&email=" + user + "&password=" + password;

			Uri uri = new Uri(userUrl);

			HttpClient client = new HttpClient();

			var response = await client.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				List<User> userFound = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(content);

				if (userFound.Count == 0)
				{
					await DisplayAlert("Error", "Could not find the requested user", "OK");

					imgLoading.IsVisible = false;
					btnLogin.IsEnabled = true;

					return;
				}

				Settings.LoginToken = "123456";

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
