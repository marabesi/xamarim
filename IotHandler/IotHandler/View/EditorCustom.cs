using System;
using Xamarin.Forms;

namespace IotHandler
{
	public class EditorCustom : Editor
	{
		public static readonly BindableProperty PlaceholderProperty =
	   BindableProperty.Create<EditorCustom, string>(view => view.Placeholder, String.Empty);

		public string Placeholder
		{
			get
			{
				return (string)GetValue(PlaceholderProperty);
			}

			set
			{
				SetValue(PlaceholderProperty, value);
			}
		}
	}
}
