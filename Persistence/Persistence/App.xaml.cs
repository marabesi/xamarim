﻿using Xamarin.Forms;

namespace Persistence
{
	public partial class App : Application
	{

		static FiapDbContext database;

		public static FiapDbContext Database
		{
			get
			{
				if (database == null)
				{
					database = new FiapDbContext();
				}

				return database;
			}
		}

		public App()
		{
			InitializeComponent();

			MainPage = new PersistencePage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
