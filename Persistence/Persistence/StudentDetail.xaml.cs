using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Persistence
{
	public partial class StudentDetail : ContentPage
	{

		public Student selectedStudent { get; set; }

		public StudentDetail()
		{
			InitializeComponent();
		}
	}
}
