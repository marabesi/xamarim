using System;
using Xamarin.Forms;

namespace IotHandler
{
	public class RequiredBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += OnEntryTextChanged;

			base.OnAttachedTo(bindable);
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= OnEntryTextChanged;

			base.OnDetachingFrom(bindable);
		}

		void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
			bool isValid = args.NewTextValue.Length < 3 ? false : true;

			((Entry)sender).TextColor = isValid ? Color.FromHex("#C4C4C4") : Color.Red;
		}
	}
}
