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
			//Uri uri = new Uri("http://www.mocky.io/v2/5862d3320f00000c171755c3"); //user not ok
			Uri uri = new Uri("http://www.mocky.io/v2/5862d03d0f0000af161755bd"); //user ok

			HttpClient client = new HttpClient();
			var response = await client.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				User userFound = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

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
