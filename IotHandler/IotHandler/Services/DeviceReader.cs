using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IotHandler.Services
{
	public class DeviceReader
	{
		public DeviceReader()
		{
		}

		public async Task RunCounter(CancellationToken token)
		{
			await Task.Run(async () =>
			{

				for (long i = 0; i < long.MaxValue; i++)
				{
					token.ThrowIfCancellationRequested();

					await Task.Delay(250);

					Device.BeginInvokeOnMainThread(() =>
					{
						Debug.WriteLine("aaa");
					});
				}
			}, token);
		}
	}
}
