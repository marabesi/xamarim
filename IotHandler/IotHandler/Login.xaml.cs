using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.Generic;

namespace IotHandler
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();

			RotateLoadingImage(imgLoading, new CancellationToken());

			imgLoading.IsVisible = false;
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

		private async Task RotateLoadingImage(VisualElement element, CancellationToken cancel)
		{
			while (!cancel.IsCancellationRequested)
			{ 
				await element.RotateTo(360, 1000);
				await element.RotateTo(0, 0);
			}
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

				Application.Current.MainPage = new NavigationPage(new IotHandlerPage())
				{
					BarBackgroundColor = Color.FromHex("#C4C4C4"),
					BarTextColor = Color.White
				};

				return;
			}

			imgLoading.IsVisible = false;
			btnLogin.IsEnabled = true;

			await DisplayAlert("Error", "Could not find the requested user", "OK");
		}
	}
}
