using System;
using System.IO;
using IotHandler;
using IotHandler.iOS;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionIos))]
namespace IotHandler.iOS
{
	public class DatabaseConnectionIos : DatabaseConnection
	{
		public SQLiteConnection DbConnection()
		{
			var dbName = "iothandler.db";

			var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

			var path = Path.Combine(folder, dbName);

			return new SQLiteConnection(path);
		}
	}
}
