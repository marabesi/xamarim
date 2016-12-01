using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Persistence
{
	public partial class InsertStudent : ContentPage
	{
		public InsertStudent()
		{
			InitializeComponent();
		}

		private void SaveStudent(object sender, EventArgs args)
		{
			var student = new Student();
			student.Name = name.Text;
			student.Email = email.Text;

			App.StudentList.Add(student);

			Navigation.PopToRootAsync(true);
		}
	}
}
