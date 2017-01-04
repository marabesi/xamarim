using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace IotHandler.Services
{
	// https://forums.xamarin.com/discussion/30603/how-do-you-use-jamesmontemagnos-xamarin-plugins-settings
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get { return CrossSettings.Current; }
		}

		private const string LoginTokenKey = "username_key";

		private static readonly string LoginTokenDefault = string.Empty;

		public static string LoginToken
		{
			get { return AppSettings.GetValueOrDefault<string>(LoginTokenKey, LoginTokenDefault); }
			set { AppSettings.AddOrUpdateValue<string>(LoginTokenKey, value); }
		}
	}
}
