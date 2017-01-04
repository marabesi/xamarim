using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IotHandler.View
{
	public class SpinnerLoadingAnimation
	{
		public SpinnerLoadingAnimation()
		{
		}

		public async void Rotate(VisualElement element, CancellationToken cancel)
		{
			while (!cancel.IsCancellationRequested)
			{
				await element.RotateTo(360, 1000);
				await element.RotateTo(0, 0);
			}
		}
	}
}
