using System;
using System.Collections.Generic;
using Xamarin.Forms;
using IotHandler.View;
using System.Threading;
using System.Net.Http;
using Xamarin.Forms;

namespace IotHandler
{
	public partial class NewAccountModal : ContentPage
	{
		private SpinnerLoadingAnimation animation = new SpinnerLoadingAnimation();

		public NewAccountModal()
		{
			InitializeComponent();

			animation.Rotate(imgLoading, new CancellationToken());

			imgLoading.IsVisible = false;
		}

		protected async void OnNewAccount(object sender, EventArgs args)
		{
			imgLoading.IsVisible = true;

			String userUrl = IHerokuService.USERS_URL;

			Uri uri = new Uri(userUrl);

			HttpClient client = new HttpClient();

			var requestContent = new Dictionary<string, string>();

			requestContent.Add("name", txtName.Text);
			requestContent.Add("email", txtEmail.Text);
			requestContent.Add("password", txtPassword.Text);

			var response = await client.PostAsync(uri, new FormUrlEncodedContent(requestContent));

			imgLoading.IsVisible = false;

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				User newUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);

				await DisplayAlert("Success", "Your user has been created, now you can login", "Great!");

				await Navigation.PopModalAsync();

				return;
			}

			await DisplayAlert("Error", "Something went wrong", "Ill try again later : (");
		}
	}
}
