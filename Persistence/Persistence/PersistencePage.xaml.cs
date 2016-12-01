using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;

namespace Persistence
{
	public partial class PersistencePage : ContentPage
	{

		public PersistencePage()
		{
			BindingContext = App.StudentList;

			InitializeComponent();

			studentsListView.ItemsSource = App.StudentList;

			Content = studentsListView;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			this.Focus();

			//studentsListView.ItemsSource = App.StudentList;
		}

		public void OnSelectedItem(object sender, SelectedItemChangedEventArgs args)
		{
			StudentDetail detailPage = new StudentDetail();
			detailPage.BindingContext = (Student) args.SelectedItem;
				
			Navigation.PushAsync(detailPage);
		}

		private void OnNewStudent(object sender, EventArgs args)
		{
			InsertStudent newStudent = new InsertStudent();

			Navigation.PushAsync(newStudent);
		}
	}
}
