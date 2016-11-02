using System;
using SQLite;
using Xamarin.Forms;
using System.IO;
using Persistence.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Persistence.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android()
		{}

		public SQLiteConnection GetConnection()
		{
			var path = "fiapdb.db3";

			string fullPath = System.Environment.GetFolderPath(
				System.Environment.SpecialFolder.Personal
			);

			var finalPath = Path.Combine(path, fullPath);
			return new SQLiteConnection(finalPath);
		}
	}
}
