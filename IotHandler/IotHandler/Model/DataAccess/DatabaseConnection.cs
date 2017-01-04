using System;

namespace IotHandler
{
	public interface DatabaseConnection
	{
		SQLite.SQLiteConnection DbConnection();
	}
}

