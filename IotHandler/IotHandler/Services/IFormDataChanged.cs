using System;

namespace IotHandler.Services
{
	public interface IFormDataChanged
	{
		void OnFormDataChanged(object sender, EventArgs args);
	}
}
