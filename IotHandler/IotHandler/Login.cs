using System;

using Xamarin.Forms;

namespace IotHandler
{
	public class Login : ContentPage
	{
		public Login()
		{
			
		}

		protected void OnFormDataChanged(object sender, EventArgs args)
		{
			
		}

		protected void OnLogin(object sender, EventArgs args)
		{
			Navigation.pushAsync(new IoTHandlerPage());
		}
	}
}

