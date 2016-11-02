using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence
{
	public class StudentViewModel
	{

		public Student student { get; set; }

		public List<Student> students
		{
			get 
			{
				return App.Database.GetStudents().ToList();
			}
		}

	}
}
