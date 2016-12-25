using SQLite;
using Xamarin.Forms;
using IotHandler.Droid;
using System.IO;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionAndroid))]
namespace IotHandler.Droid
{
	public class DatabaseConnectionAndroid : DatabaseConnection
	{
		public SQLiteConnection DbConnection()
		{
			var dbName = "iothandler.db";

			//var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

			var folder = "/sdcard/Android/data/com.iot.handler.iothandler/";

			var path = Path.Combine(folder, dbName);

			Debug.Print(path);

			return new SQLiteConnection(path);
		}
	}
}

