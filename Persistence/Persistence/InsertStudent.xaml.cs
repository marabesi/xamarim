using System;
using System.Collections.Generic;

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

			//FiapDbContext db = new FiapDbContext();
			//db.Save(student);

			DisplayAlert("Success", "Student has been saved", "OK");

			Navigation.PopAsync(true);
		}
	}
}
