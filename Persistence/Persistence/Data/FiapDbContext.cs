using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace Persistence
{
	public class FiapDbContext
	{
		private SQLiteConnection database;
		static object locker = new object();

		public FiapDbContext()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();

			database.CreateTable<Student>();
		}

		public int Save(Student student)
		{
			lock (locker)
			{
				if (student.Id != 0)
				{
					database.Update(student);

					return student.Id;
				}

				return database.Insert(student);
			}
		}

		public IEnumerable<Student> GetStudents()
		{
			lock (locker)
			{
				return (from s in database.Table<Student>() select s).ToList();
			}
		}

		public Student GetStudent(int id)
		{
			lock (locker)
			{
				return database.Table<Student>().Where(
					s => s.Id == id).FirstOrDefault();
				
			}
		}

		public int Remove(int id)
		{
			return database.Delete<Student>(id);
		}
	}
}
