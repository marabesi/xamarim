using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Messages
{
	public partial class Page2 : ContentPage
	{
		public Page2()
		{
			InitializeComponent();
		}

		private void OnClicked(object sender, EventArgs args)
		{
			var page1 = new Page1();
			MessagingCenter.Send<Page1>(page1, "comming_back");

			Navigation.PopAsync(true);
		}
	}
}
