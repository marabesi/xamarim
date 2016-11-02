using System;
using SQLite;

namespace Persistence
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
		
	}
}
