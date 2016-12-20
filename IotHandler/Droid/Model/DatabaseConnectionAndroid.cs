using SQLite;
using Xamarin.Forms;
using IotHandler.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionAndroid))]
namespace IotHandler.Droid
{
	public class DatabaseConnectionAndroid : DatabaseConnection
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

