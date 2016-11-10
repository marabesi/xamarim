using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Persistence
{
	public class StudentViewModel
	{

		public Student student { get; set; }

		//public List<Student> students
		//{
		//	get 
		//	{
		//		return App.Database.GetStudents().ToList();
		//	}
		//}

		public ObservableCollection<Student> students
		{
			get
			{
				ObservableCollection<Student> studentList = new ObservableCollection<Student>();
				studentList.Add(new Student() { Name = "Student1", Email = "student@student1.com" });
				studentList.Add(new Student() { Name = "Student2", Email = "student@student2.com" });
				studentList.Add(new Student() { Name = "Student3", Email = "student@student3.com" });

				return studentList;
			}
		}

	}
}
