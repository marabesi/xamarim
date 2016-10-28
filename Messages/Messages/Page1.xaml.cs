using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Messages
{
	public partial class Page1 : ContentPage
	{
		public Page1()
		{
			InitializeComponent();
			ActivateMessageCenter();
		}

		public void ActivateMessageCenter()
		{
			MessagingCenter.Subscribe<Page1>(this, "comming_back", (sender) => { message.Text = "Keep going"; });
		}


		private void OnClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync(new Page2());
		}
	}
}
