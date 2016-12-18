using System;
using Xamarin.Forms;

namespace IotHandler
{
	public class EntryTextChanged : TriggerAction<Entry>
	{
		protected override void Invoke(Entry sender)
		{
			double result;
			bool isValid = Double.TryParse(sender.Text, out result);
			sender.BackgroundColor =
				  isValid ? Color.Default : Color.Red;
		}
	}
}
