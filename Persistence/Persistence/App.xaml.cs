using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;

namespace Persistence
{
	public partial class App : Application
	{

		static FiapDbContext database;
		static ObservableCollection<Student> studentList;

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

		public static ObservableCollection<Student> StudentList
		{
			get 
			{
				if (studentList == null)
				{
					studentList = new ObservableCollection<Student>();
				}

				return studentList;
			}
		}

		public App()
		{
			StudentList.Add(new Student() { Name = "Student1", Email = "student@student1.com" });
			StudentList.Add(new Student() { Name = "Student2", Email = "student@student2.com" });
			StudentList.Add(new Student() { Name = "Student3", Email = "student@student3.com" });

			MainPage = new NavigationPage(new PersistencePage());
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
